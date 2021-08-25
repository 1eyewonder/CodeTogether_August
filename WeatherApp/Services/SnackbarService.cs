using WeatherApp.CustomEventArgs;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class SnackbarService : ISnackbarService
    {
        public event ISnackbarService.SnackEventHandler AddSnackEvent;

        public void AddSnack(string message)
        {
            AddSnackEvent?.Invoke(this, new SnackbarEventArgs(message));
        }
    }
}