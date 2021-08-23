using System.Windows.Controls;
using WeatherApp.ViewModels.Interfaces;

namespace WeatherApp.Pages
{
    public partial class LoginPage : Page
    {
        public LoginPage(ILoginViewModel loginViewModel)
        {
            DataContext = loginViewModel;
            InitializeComponent();
        }
    }
}