using System.Windows.Controls;
using WeatherApp.ViewModels.Interfaces;

namespace WeatherApp.Pages
{
    public partial class WeatherPage : Page
    {
        public WeatherPage(IWeatherForecastPanelViewModel weatherForecastPanelViewModel)
        {
            DataContext = weatherForecastPanelViewModel;
            InitializeComponent();
        }
    }
}