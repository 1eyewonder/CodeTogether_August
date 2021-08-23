using System.Collections.ObjectModel;
using System.Windows.Input;
using WeatherApp.Dtos;

namespace WeatherApp.ViewModels.Interfaces
{
    public interface ILocationFinderViewModel
    {
        bool SearchByText { get; set; }
        string SearchText { get; set; }
        float Latitude { get; set; }
        float Longitude { get; set; }
        ObservableCollection<Location> Locations { get; set; }
        ICommand FindLocationsCommand();
    }
}