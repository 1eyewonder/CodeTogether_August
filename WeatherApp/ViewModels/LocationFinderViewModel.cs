using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.ViewModels;
using WeatherApp.Dtos;
using WeatherApp.Services.Interfaces;
using WeatherApp.ViewModels.Interfaces;

namespace WeatherApp.ViewModels
{
    public class LocationFinderViewModel : MvxViewModel, ILocationFinderViewModel
    {
        private readonly ILocationService _locationService;
        private readonly ISnackbarService _snackbarService;

        private float _latitude;

        private ObservableCollection<Location> _locations;

        private float _longitude;

        private bool _searchByText;

        private string _searchText;

        public LocationFinderViewModel(ILocationService locationService,
            ISnackbarService snackbarService)
        {
            _locationService = locationService;
            _snackbarService = snackbarService;

            SearchByText = true;
            FindLocationsCommand = new RelayCommand(FindLocations);
        }

        public ICommand FindLocationsCommand { get; }

        public bool SearchByText
        {
            get => _searchByText;
            set => SetProperty(ref _searchByText, value);
        }

        public float Latitude
        {
            get => _latitude;
            set => SetProperty(ref _latitude, value);
        }

        public float Longitude
        {
            get => _longitude;
            set => SetProperty(ref _longitude, value);
        }

        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        public ObservableCollection<Location> Locations
        {
            get => _locations;
            set => SetProperty(ref _locations, value);
        }

        private async Task FindLocations()
        {
            List<Location> locationList;
            if (SearchByText)
                locationList = await _locationService.GetLocationBySearchString(SearchText);
            else
                locationList = await _locationService.GetLocationByLattLong(Latitude, Longitude);

            Locations = new ObservableCollection<Location>(locationList);
            _snackbarService.AddSnack($"Found {Locations.Count} locations");
        }
    }
}