using System.Reflection;
using MvvmCross.ViewModels;
using WeatherApp.Enums;
using WeatherApp.ViewModels.Interfaces;

namespace WeatherApp.ViewModels
{
    public class ApplicationViewModel : MvxViewModel, IApplicationViewModel
    {
        private EApplicationPage _applicationPage;
        private bool _hasError;
        private int _navBarMaxWidth;
        
        public string VersionName { get; } = Assembly.GetExecutingAssembly().GetName().Version?.ToString();

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
    }
}