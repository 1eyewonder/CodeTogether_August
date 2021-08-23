using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using WeatherApp.Dtos;
using WeatherApp.Services.Interfaces;
using TimeZone = WeatherApp.Dtos.TimeZone;

namespace WeatherApp.Services
{
    public class JsonParsingService : IJsonParsingService
    {
        private readonly ILogger<IJsonParsingService> _logger;
        private readonly IMapper _mapper;

        public JsonParsingService(ILogger<JsonParsingService> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public List<Location> GetLocations(JArray array)
        {
            return array is not null
                ? array.Select(x => _mapper.Map<Location>(x))
                    .ToList()
                : new List<Location>();
        }

        public ConsolidatedWeather GetWeather(JObject obj)
        {
            if (obj == null)
            {
                return new ConsolidatedWeather
                {
                    WeatherForecast = new List<Weather>(),
                    Sources = new List<WeatherSource>()
                };
            }

            var location = _mapper.Map<Location>(obj);
            var timezone = obj.ToObject<TimeZone>();
            var parent = _mapper.Map<Location>(obj["parent"]);

            var weather = (obj["consolidated_weather"] as JArray)
                ?.ToObject<List<Weather>>();

            var sources = (obj["sources"] as JArray)
                ?.ToObject<List<WeatherSource>>();

            return new ConsolidatedWeather
            {
                Location = location,
                ParentLocation = parent,
                TimeZone = timezone,
                WeatherForecast = weather,
                Sources = sources
            };
        }
    }
}