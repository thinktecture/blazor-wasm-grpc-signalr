using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ConfTool.Server.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shared.Contracts;

namespace ConfTool.Server.gRPC
{
    public class ConferencesService : IConferencesService
    {
        private readonly ILogger<ConferencesService> _logger;
        private readonly ConferencesDbContext _conferencesDbContext;
        private readonly IMapper _mapper;

        public ConferencesService(ILogger<ConferencesService> logger, ConferencesDbContext conferencesDbContext, IMapper mapper)
        {
            _logger = logger;
            _conferencesDbContext = conferencesDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Shared.DTO.ConferenceOverview>> ListConferencesAsync()
        {
            var conferences = await _conferencesDbContext.Conferences.ToListAsync();
            var confs = _mapper.Map<IEnumerable<Shared.DTO.ConferenceOverview>>(conferences);

            return confs;
        }
    }
}
