using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Dtos;

namespace WeatherApp.ViewModels.Interfaces
{
    public interface IWeatherForecastPanelViewModel
    {
        ObservableCollection<ILocationForecastViewModel> Weathers { get; }
        Task AddLocation(Location location);
        void RemoveLocation(Location location);
        Task Refresh();
    }
}