
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conference;
using Grpc.Net.Client;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfTool.Client.Services
{
    public class ConferencesService
    {
        private Conference.Conferences.ConferencesClient _client;
        private IConfiguration _config;
        private string _baseUrl;
        private HubConnection _hubConnection;

        public EventHandler ConferenceListChanged;

        public ConferencesService(IConfiguration config, GrpcChannel channel)
        {
            _config = config;
            _baseUrl = _config["BackendUrl"];
            _client = new Conference.Conferences.ConferencesClient(channel);
        }

        public async Task Init()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(new Uri(_baseUrl), "conferencesHub"))
                .AddMessagePackProtocol()
                .Build();

            _hubConnection.On("NewConferenceAdded", () =>
            {
                ConferenceListChanged?.Invoke(this, null);
            });

            await _hubConnection.StartAsync();
        }

        public async Task<List<ConferenceOverview>> ListConferences()
        {
            var result = await _client.ListConferencesAsync(new ListConferencesRequest());
            
            var confs = result.Conferences.ToList();

            return confs;
        }

        /*
        public async Task<ConferenceDetails> GetConferenceDetails(Guid id)
        {
            var result = await _httpClient.GetJsonAsync<ConferenceDetails>(_conferencesUrl + id);

            return result;
        }

        public async Task<ConferenceDetails> AddConference(ConferenceDetails conference)
        {
            var result = await _httpClient.PostJsonAsync<ConferenceDetails>(
                _conferencesUrl, conference);

            return result;
        }

        public async Task<dynamic> GetStatistics()
        {
            var result = await _httpClient.GetJsonAsync<dynamic>(_statisticsUrl);

            return result;
        }
        */
    }
}
