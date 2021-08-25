using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using WeatherApp.Enums;

namespace WeatherApp.ViewModels.Interfaces
{
    public interface IApplicationViewModel
    {
        string VersionName { get; }
        EApplicationPage CurrentPage { get; set; }
        bool HasError { get; set; }
        int NavBarMaxWidth { get; set; }
        SnackbarMessageQueue Snackbar { get; set; }
    }
}