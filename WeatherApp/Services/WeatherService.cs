using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeatherApp.Dtos;
using WeatherApp.Exceptions;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IJsonParsingService _jsonParsingService;
        private readonly ILogger<WeatherService> _logger;

        public WeatherService(ILogger<WeatherService> logger, HttpClient httpClient,
            IJsonParsingService jsonParsingService)
        {
            _logger = logger;
            _httpClient = httpClient;
            _jsonParsingService = jsonParsingService;
        }

        public async Task<ConsolidatedWeather> GetWeatherById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"{_httpClient.BaseAddress}api/location/{id}");

                response.EnsureSuccessStatusCode();

                var jObject = JsonConvert.DeserializeObject<JObject>(
                    await response.Content.ReadAsStringAsync());

                return _jsonParsingService.GetWeather(jObject);
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e,
                    "{Method} encountered an API exception: {Message}",
                    nameof(GetWeatherById),
                    e.Message);
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e,
                    "{Method} encountered an uncaught exception: {Message}",
                    nameof(GetWeatherByIdAndDate),
                    e.Message);
                throw;
            }
        }

        public async Task<ConsolidatedWeather> GetWeatherByIdAndDate(int id, DateTime date)
        {
            try
            {
                if (date.Date > DateTime.Now)
                {
                    _logger.LogDebug("The forecast cannot be requested beyond today");
                    throw new WeatherServiceException("The forecast cannot be requested beyond today");
                }

                var response = await _httpClient.GetAsync(
                    $"{_httpClient.BaseAddress}api/location/{id}/{date}");

                response.EnsureSuccessStatusCode();

                var jObject = JsonConvert.DeserializeObject<JObject>(
                    await response.Content.ReadAsStringAsync());

                return _jsonParsingService.GetWeather(jObject);
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e,
                    "{Method} encountered an API exception: {Message}",
                    nameof(GetWeatherById),
                    e.Message);
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e,
                    "{Method} encountered an uncaught exception: {Message}",
                    nameof(GetWeatherByIdAndDate),
                    e.Message);
                throw;
            }
        }
    }
}