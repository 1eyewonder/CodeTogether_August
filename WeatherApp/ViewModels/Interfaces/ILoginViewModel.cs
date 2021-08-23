using System.Windows.Input;

namespace WeatherApp.ViewModels.Interfaces
{
    public interface ILoginViewModel
    {
        IApplicationViewModel ApplicationViewModel { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        ICommand LoginCommand { get; }
    }
}