using System;
using System.IO;
using System.Reflection;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherApp.Helpers;
using WeatherApp.MappingProfiles;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;
using WeatherApp.ViewModels;
using WeatherApp.ViewModels.Interfaces;

namespace WeatherApp
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IServiceProvider ServiceProvider { get; set; }
        private IConfiguration Configuration { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);
            ConfigureHttp(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();
            Current.Resources.Add("Services", ServiceProvider);
            
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Configuration
            services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));
            services.AddAutoMapper(Assembly.GetAssembly(typeof(LocationProfile)));
            
            // Services
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<IJsonParsingService, JsonParsingService>();
            
            // View models
            services.AddSingleton<IApplicationViewModel, ApplicationViewModel>();
            services.AddScoped<ILoginViewModel, LoginViewModel>();
            services.AddScoped<IWeatherForecastPanelViewModel, WeatherForecastPanelViewModel>();

            services.AddTransient(typeof(MainWindow));
        }

        /// <summary>
        /// Configure unique http client per service
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <remarks>Useful for configuring multiple APIs</remarks>
        private void ConfigureHttp(IServiceCollection services)
        {
            services.AddHttpClient<ILocationService, LocationService>(x =>
            {
                x.BaseAddress = new Uri(Configuration.GetSetting<string>(nameof(AppSettings.WeatherApiUrl)));
            });
            
            services.AddHttpClient<IWeatherService, WeatherService>(x =>
            {
                x.BaseAddress = new Uri(Configuration.GetSetting<string>(nameof(AppSettings.WeatherApiUrl)));
            });
        }
    }
}