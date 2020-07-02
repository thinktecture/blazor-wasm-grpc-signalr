﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using ProtoBuf.Grpc.Client;
using Shared.Contracts;

namespace ConfTool.Client.Services
{
    public class ConferencesService
    {
        private IConferencesService _client;
        private IConfiguration _config;
        private string _baseUrl;
        private HubConnection _hubConnection;

        public EventHandler ConferenceListChanged;

        public ConferencesService(IConfiguration config, GrpcChannel channel)
        {
            _config = config;
            _baseUrl = _config["BackendUrl"];
            _client = channel.CreateGrpcService<IConferencesService>();
        }

        public async Task Init()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(new Uri(_baseUrl), "conferencesHub"))
                .Build();

            _hubConnection.On("NewConferenceAdded", () =>
            {
                ConferenceListChanged?.Invoke(this, null);
            });

            await _hubConnection.StartAsync();
        }

        public async Task<IEnumerable<ConfTool.Shared.DTO.ConferenceOverview>> ListConferences()
        {
            var result = await _client.ListConferencesAsync();

            return result;
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
