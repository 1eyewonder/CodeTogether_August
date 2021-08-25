using System.Windows;
using WeatherApp.Enums;
using WeatherApp.ViewModels;
using WeatherApp.ViewModels.Interfaces;

namespace WeatherApp
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IApplicationViewModel applicationViewModel)
        {
            DataContext = applicationViewModel;
            InitializeComponent();
        }

        private void NavigateToLocations(object sender, RoutedEventArgs e)
        {
            ((ApplicationViewModel)DataContext).CurrentPage = EApplicationPage.LocationPage;
        }

        private void NavigateToWeather(object sender, RoutedEventArgs e)
        {
            ((ApplicationViewModel)DataContext).CurrentPage = EApplicationPage.WeatherPage;
        }
    }
}