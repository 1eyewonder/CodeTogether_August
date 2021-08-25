using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WeatherApp.Dtos;

namespace WeatherApp.ViewModels.Interfaces
{
    public interface ILocationForecastViewModel
    {
        Location Location { get; }
        Location ParentLocation { get; }
        TimeZone TimeZone { get; }
        ObservableCollection<IDailyForecastViewModel> FiveDayForecast { get; }
        ObservableCollection<WeatherSource> Sources { get; }
        ICommand RemoveCommand { get; }
    }
}