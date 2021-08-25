using System;
using WeatherApp.Dtos;

namespace WeatherApp.ViewModels.Interfaces
{
    public interface IDailyForecastViewModel
    {
        Weather Weather { get; }
        string ImagePath { get; }
    }
}