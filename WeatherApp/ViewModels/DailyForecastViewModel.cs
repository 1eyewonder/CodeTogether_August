using System;
using System.IO;
using MvvmCross.ViewModels;
using WeatherApp.Dtos;
using WeatherApp.ViewModels.Interfaces;

namespace WeatherApp.ViewModels
{
    public class DailyForecastViewModel : MvxViewModel, IDailyForecastViewModel
    {
        private Weather _weather;
        
        public DailyForecastViewModel(Weather weather)
        {
            Weather = weather;
        }
        
        public Weather Weather
        {
            get => _weather;
            private init => _weather = value;
        }

        public string ImagePath => $"{Directory.GetCurrentDirectory()}/Images/{Weather.StateAbbreviation}.png";
    }
}