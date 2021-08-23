using System.Collections.Generic;

namespace WeatherApp.Dtos
{
    public record ConsolidatedWeather
    {
        public Location Location { get; init; }
        public Location ParentLocation { get; init; }
        public TimeZone TimeZone { get; init; }
        public List<Weather> WeatherForecast { get; init; }
        public List<WeatherSource> Sources { get; init; }
    }
}