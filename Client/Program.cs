using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfTool.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            //builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSingleton(services =>
            {
                // Get the service address from appsettings.json
                var config = services.GetRequiredService<IConfiguration>();
                var backendUrl = config["BackendUrl"];

                // Create a channel with a GrpcWebHandler that is addressed to the backend server.
                //
                // GrpcWebText is used because server streaming requires it. If server streaming is not used in your app
                // then GrpcWeb is recommended because it produces smaller messages.
                var httpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());

                return GrpcChannel.ForAddress(backendUrl, new GrpcChannelOptions { HttpHandler = httpHandler });
            });

            await builder.Build().RunAsync();
        }
    }
}
