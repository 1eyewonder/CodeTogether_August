using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.ViewModels;
using WeatherApp.Enums;
using WeatherApp.ViewModels.Interfaces;

namespace WeatherApp.ViewModels
{
    public class LoginViewModel : MvxViewModel, ILoginViewModel
    {
        private IApplicationViewModel _applicationViewModel;
        private string _email;
        private string _password;

        public LoginViewModel(IApplicationViewModel applicationViewModel)
        {
            LoginCommand = new RelayCommand(Login);
            ApplicationViewModel = applicationViewModel;
        }
        public IApplicationViewModel ApplicationViewModel
        {
            get => _applicationViewModel;
            set => SetProperty(ref _applicationViewModel, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        
        public ICommand LoginCommand { get; }

        private async Task Login()
        {
            // Login then change pages to...
            await Task.Delay(0);
            ApplicationViewModel.CurrentPage = EApplicationPage.LocationPage;
            ApplicationViewModel.NavBarMaxWidth = 50;
        }
    }
}