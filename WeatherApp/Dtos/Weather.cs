using System;
using Newtonsoft.Json;

namespace WeatherApp.Dtos
{
    public record Weather
    {
        [JsonProperty("id")]
        public long Id { get; init; }
        
        /// <summary>
        /// Date that the forecast or observation pertains to
        /// </summary>
        [JsonProperty("applicable_date")]
        public DateTime Date { get; init; }
        
        /// <summary>
        /// Text description of the weather state
        /// </summary>
        [JsonProperty("weather_state_name")]
        public string State { get; init; }
        
        /// <summary>
        /// One or two letter abbreviation of the weather state
        /// </summary>
        [JsonProperty("weather_state_abbr")]
        public string StateAbbreviation { get; init; }
        
        /// <summary>
        /// Wind speed in mph
        /// </summary>
        [JsonProperty("wind_speed")]
        public float WindSpeed { get; init; }
        
        /// <summary>
        /// Wind direction in degrees
        /// </summary>
        [JsonProperty("wind_direction")]
        public float WindDirection { get; init; }
        
        /// <summary>
        /// Wind direction by compass point
        /// </summary>
        [JsonProperty("wind_direction_compass")]
        public string WindDirectionCompass { get; init; }
        
        /// <summary>
        /// Temperature in centigrade
        /// </summary>
        [JsonProperty("the_temp")]
        public int Temperature { get; init; }
        
        /// <summary>
        /// Minimum temperature in centigrade
        /// </summary>
        [JsonProperty("min_temp")]
        public int MinTemperature { get; init; }
        
        /// <summary>
        /// Maxmimum temperature in centigrade
        /// </summary>
        [JsonProperty("max_temp")]
        public int MaxTemperature { get; init; }
        
        /// <summary>
        /// Air pressure in mbar
        /// </summary>
        [JsonProperty("air_pressure")]
        public float AirPressure { get; init; }
        
        /// <summary>
        /// Humidity in percentage
        /// </summary>
        [JsonProperty("humidity")]
        public float Humidity { get; init; }
        
        /// <summary>
        /// Visibility in miles
        /// </summary>
        [JsonProperty("visibility")]
        public float Visibility { get; init; }
        
        /// <summary>
        /// Our interpretation of the level to which the forecasters agree with each other
        /// - 100% being a complete consensus
        /// </summary>
        [JsonProperty("predictability")]
        public int Predictability { get; init; }
    }
}