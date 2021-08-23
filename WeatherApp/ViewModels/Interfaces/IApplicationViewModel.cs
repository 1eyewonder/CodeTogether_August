using WeatherApp.Enums;

namespace WeatherApp.ViewModels.Interfaces
{
    public interface IApplicationViewModel
    {
        string VersionName { get; }
        EApplicationPage CurrentPage { get; set; }
        bool HasError { get; set; }
        int NavBarMaxWidth { get; set; }
    }
}