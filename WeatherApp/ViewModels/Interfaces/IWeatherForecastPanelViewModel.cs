using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Dtos;

namespace WeatherApp.ViewModels.Interfaces
{
    public interface IWeatherForecastPanelViewModel
    {
        ICommand GetWeatherData { get; }
        ConsolidatedWeather ConsolidatedWeather { get; }
    }
}