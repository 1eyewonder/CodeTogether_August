using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.ViewModels;
using WeatherApp.Dtos;
using WeatherApp.ViewModels.Interfaces;

namespace WeatherApp.ViewModels
{
    public class LocationForecastViewModel : MvxViewModel, ILocationForecastViewModel
    {
        private readonly ObservableCollection<IDailyForecastViewModel> _fiveDayForecast;
        private readonly ObservableCollection<WeatherSource> _sources;
        private readonly ConsolidatedWeather _weatherData;
        private readonly IWeatherForecastPanelViewModel _weatherForecastPanelViewModel;

        public LocationForecastViewModel(ConsolidatedWeather weatherData, 
            IWeatherForecastPanelViewModel weatherForecastPanelViewModel)
        {
            _weatherData = weatherData;
            _weatherForecastPanelViewModel = weatherForecastPanelViewModel;
            Sources = new ObservableCollection<WeatherSource>(_weatherData.Sources);
            RemoveCommand = new RelayCommand(RemoveLocationFromWeatherPanel);

            FiveDayForecast =
                new ObservableCollection<IDailyForecastViewModel>(
                    _weatherData.WeatherForecast.Select(x =>
                        new DailyForecastViewModel(x)));
        }

        public Location Location => _weatherData.Location;

        public Location ParentLocation => _weatherData.ParentLocation;

        public TimeZone TimeZone => _weatherData.TimeZone;

        public ObservableCollection<IDailyForecastViewModel> FiveDayForecast
        {
            get => _fiveDayForecast;
            private init => SetProperty(ref _fiveDayForecast, value);
        }

        public ObservableCollection<WeatherSource> Sources
        {
            get => _sources;
            private init => SetProperty(ref _sources, value);
        }
        
        public ICommand RemoveCommand { get; }

        private async Task RemoveLocationFromWeatherPanel()
        {
            await Task.Delay(0);
            _weatherForecastPanelViewModel.RemoveLocation(Location);
        }
    }
}