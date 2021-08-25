using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MvvmCross.ViewModels;
using WeatherApp.Dtos;
using WeatherApp.Services.Interfaces;
using WeatherApp.ViewModels.Interfaces;

namespace WeatherApp.ViewModels
{
    public class WeatherForecastPanelViewModel : MvxViewModel, IWeatherForecastPanelViewModel
    {
        private readonly ILogger<WeatherForecastPanelViewModel> _logger;
        private readonly ISnackbarService _snackbarService;
        private readonly IWeatherService _weatherService;
        private ObservableCollection<ILocationForecastViewModel> _weathers;

        public WeatherForecastPanelViewModel(ILogger<WeatherForecastPanelViewModel> logger,
            IWeatherService weatherService,
            ISnackbarService snackbarService)
        {
            _logger = logger;
            _weatherService = weatherService;
            _snackbarService = snackbarService;
            Weathers = new ObservableCollection<ILocationForecastViewModel>();
        }

        public ObservableCollection<ILocationForecastViewModel> Weathers
        {
            get => _weathers;
            private set => SetProperty(ref _weathers, value);
        }

        public async Task AddLocation(Location location)
        {
            try
            {
                // We do not want to add duplicates
                if (Weathers.Select(weather => weather.Location)
                    .Any(x => x.Id == location.Id))
                {
                    _snackbarService.AddSnack($"{location.Name} already exists in the weather panel.");
                    _logger.LogTrace("{Location} already exists in the weather panel", location.Name);
                    return;
                }

                var weather = await _weatherService.GetWeatherById(location.Id);
                if (weather is null) return;

                Weathers.Add(new LocationForecastViewModel(weather, this));
                _snackbarService.AddSnack($"Successfully added {location.Name} to the weather panel");
            }
            catch (Exception)
            {
                _snackbarService.AddSnack($"Something went wrong adding {location.Name} to the weather panel");
                throw;
            }
        }

        public void RemoveLocation(Location location)
        {
            try
            {
                var weather = Weathers
                    .ToList()
                    .Find(x => x.Location == location);

                if (weather is null) return;

                Weathers.Remove(weather);
                _snackbarService.AddSnack($"Successfully removed {location.Name} from the weather panel");
            }
            catch (Exception)
            {
                _snackbarService.AddSnack($"Something went wrong removing {location.Name} from the weather panel");
                throw;
            }
        }

        public async Task Refresh()
        {
            try
            {
                List<ILocationForecastViewModel> weathers = new();
                foreach (var weather in Weathers)
                    weathers.Add(new LocationForecastViewModel(
                        await _weatherService.GetWeatherById(weather.Location.Id), 
                        this));

                Weathers = new ObservableCollection<ILocationForecastViewModel>(weathers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}