using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using WeatherApp.Dtos;

namespace WeatherApp.Services.Interfaces
{
    public interface IJsonParsingService
    {
        List<Location> GetLocations(JArray array);
        ConsolidatedWeather GetWeather(JObject obj);
    }
}