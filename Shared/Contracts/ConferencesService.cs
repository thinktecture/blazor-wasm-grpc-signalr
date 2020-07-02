using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using ConfTool.Shared.DTO;

namespace Shared.Contracts
{
    [ServiceContract]
    public interface IConferencesService
    {
        Task<IEnumerable<ConferenceOverview>> ListConferencesAsync();
    }
}