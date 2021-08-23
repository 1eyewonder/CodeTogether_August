using System;
using Newtonsoft.Json;

namespace WeatherApp.Dtos
{
    public record TimeZone
    {
        [JsonProperty("timezone_name")]
        public string Name { get; init; }
        
        [JsonProperty("sun_rise")]
        public DateTime Sunrise { get; init; }
        
        [JsonProperty("sun_set")]
        public DateTime Sunset { get; init; }
        
        [JsonProperty("time")]
        public DateTime Time { get; init; }
    }
}