using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeatherApp.Dtos;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _httpClient;
        private readonly IJsonParsingService _jsonParsingService;
        private readonly ILogger<LocationService> _logger;

        public LocationService(ILogger<LocationService> logger, 
            HttpClient httpClient,
            IJsonParsingService jsonParsingService)
        {
            _logger = logger;
            _httpClient = httpClient;
            _jsonParsingService = jsonParsingService;
        }

        public async Task<List<Location>> GetLocationBySearchString(string searchString)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"{_httpClient.BaseAddress}api/location/search/?query={searchString}");

                response.EnsureSuccessStatusCode();

                var jArray = JsonConvert.DeserializeObject<JArray>(
                    await response.Content.ReadAsStringAsync());

                return _jsonParsingService.GetLocations(jArray);
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e,
                    "{Method} encountered an API exception: {Message}",
                    nameof(GetLocationBySearchString),
                    e.Message);
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e,
                    "{Method} encountered an uncaught exception: {Message}",
                    nameof(GetLocationBySearchString),
                    e.Message);
                throw;
            }
        }

        public async Task<List<Location>> GetLocationByLattLong(float latitude, float longitude)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"{_httpClient.BaseAddress}api/location/search/?lattlong={latitude},{longitude}");

                response.EnsureSuccessStatusCode();

                var jArray = JsonConvert.DeserializeObject<JArray>(
                    await response.Content.ReadAsStringAsync());

                return _jsonParsingService.GetLocations(jArray);
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e,
                    "{Method} encountered an API exception: {Message}",
                    nameof(GetLocationBySearchString),
                    e.Message);
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e,
                    "{Method} encountered an uncaught exception: {Message}",
                    nameof(GetLocationBySearchString),
                    e.Message);
                throw;
            }
        }
    }
}