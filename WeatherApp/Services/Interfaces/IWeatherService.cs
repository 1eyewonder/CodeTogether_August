using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Dtos;

namespace WeatherApp.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<ConsolidatedWeather> GetWeatherById(int id);
        Task<ConsolidatedWeather> GetWeatherByIdAndDate(int id, DateTime date);
    }
}