using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.ViewModels;
using WeatherApp.Dtos;
using WeatherApp.Helpers;
using WeatherApp.Services.Interfaces;
using WeatherApp.ViewModels.Interfaces;

namespace WeatherApp.ViewModels
{
    public class WeatherForecastPanelViewModel : MvxViewModel, IWeatherForecastPanelViewModel
    {
        private readonly ILocationService _locationService;
        private readonly IWeatherService _weatherService;
        
        public WeatherForecastPanelViewModel(ILocationService locationService, IWeatherService weatherService)
        {
            _locationService = locationService;
            _weatherService = weatherService;
            GetWeatherData = new RelayCommand(GetData);
        }
        
        private ConsolidatedWeather _consolidatedWeather;
        public ConsolidatedWeather ConsolidatedWeather
        {
            get => _consolidatedWeather;
            private set => SetProperty(ref _consolidatedWeather, value);
        }

        public ICommand GetWeatherData { get; }

        private async Task GetData()
        {
            ConsolidatedWeather = await _weatherService.GetWeatherById(44418);
        }
    }
}