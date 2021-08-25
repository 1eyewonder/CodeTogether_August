using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using MvvmCross.ViewModels;
using WeatherApp.Enums;
using WeatherApp.CustomEventArgs;
using WeatherApp.Services.Interfaces;
using WeatherApp.ViewModels.Interfaces;

namespace WeatherApp.ViewModels
{
    public class ApplicationViewModel : MvxViewModel, IApplicationViewModel
    {
        private SnackbarMessageQueue _snackbar;
        private EApplicationPage _applicationPage;
        private bool _hasError;
        private int _navBarMaxWidth;

        public ApplicationViewModel(ISnackbarService snackbarService, 
            SnackbarMessageQueue snackbar)
        {
            _snackbar = snackbar;
            snackbarService.AddSnackEvent += AddSnack;
            LogoutCommand = new RelayCommand(Logout);
            CurrentPage = EApplicationPage.LoginPage;
        }
        
        public string VersionName { get; } = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
        
        public SnackbarMessageQueue Snackbar
        {
            get => _snackbar;
            set => SetProperty(ref _snackbar, value);
        }
        
        public EApplicationPage CurrentPage
        {
            get => _applicationPage;
            set => SetProperty(ref _applicationPage, value);
        }

        public bool HasError
        {
            get => _hasError;
            set => SetProperty(ref _hasError, value);
        }

        public int NavBarMaxWidth
        {
            get => _navBarMaxWidth;
            set => SetProperty(ref _navBarMaxWidth, value);
        }
        
        public ICommand LogoutCommand { get; }

        private void AddSnack(object sender, SnackbarEventArgs args)
        {
            Snackbar.Enqueue(args.Message);
        }

        private async Task Logout()
        {
            await Task.Delay(1000);
            CurrentPage = EApplicationPage.LoginPage;
            NavBarMaxWidth = 0;
        }
    }
}