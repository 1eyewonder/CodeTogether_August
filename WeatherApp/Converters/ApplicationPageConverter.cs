using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WeatherApp.Enums;
using WeatherApp.Pages;
using WeatherApp.ViewModels.Interfaces;

namespace WeatherApp.Converters
{
    public class ApplicationPageConverter : BaseValueConverter<ApplicationPageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var services = (IServiceProvider)App.Current.Resources["Services"];

            switch ((EApplicationPage)value)
            {
                case EApplicationPage.LoginPage:
                    return new LoginPage(services.GetService<ILoginViewModel>());

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}