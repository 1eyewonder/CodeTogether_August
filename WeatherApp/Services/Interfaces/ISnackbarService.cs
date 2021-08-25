using System;
using WeatherApp.CustomEventArgs;

namespace WeatherApp.Services.Interfaces
{
    public interface ISnackbarService
    {
        delegate void SnackEventHandler(object sender, SnackbarEventArgs arg);
        event SnackEventHandler AddSnackEvent;
        void AddSnack(string message);
    }
}