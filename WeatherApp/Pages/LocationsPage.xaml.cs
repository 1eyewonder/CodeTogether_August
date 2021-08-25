using System.Windows;
using System.Windows.Controls;
using WeatherApp.Dtos;
using WeatherApp.ViewModels.Interfaces;

namespace WeatherApp.Pages
{
    public partial class LocationsPage : Page
    {
        private readonly IWeatherForecastPanelViewModel _weatherForecastPanelViewModel;

        public LocationsPage(ILocationFinderViewModel locationFinderViewModel, IWeatherForecastPanelViewModel weatherForecastPanelViewModel)
        {
            _weatherForecastPanelViewModel = weatherForecastPanelViewModel;
            DataContext = locationFinderViewModel;
            InitializeComponent();
        }

        private void AddLocation(object sender, RoutedEventArgs e)
        {
            if ((sender as Button)?.DataContext is Location location) 
                _weatherForecastPanelViewModel.AddLocation(location);
        }
    }
}