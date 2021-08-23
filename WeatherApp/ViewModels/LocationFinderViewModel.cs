using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.ViewModels;
using WeatherApp.Dtos;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.ViewModels
{
    public class LocationFinderViewModel : MvxViewModel
    {
        private readonly ILocationService _locationService;

        public LocationFinderViewModel(ILocationService locationService)
        {
            _locationService = locationService;
            FindLocationsCommand = new RelayCommand(FindLocations);
        }

        public ICommand FindLocationsCommand { get; }

        private bool _searchByText;
        public bool SearchByText
        {
            get => _searchByText;
            set => SetProperty(ref _searchByText, value);
        }

        private float _latitude;
        public float Latitude
        {
            get => _latitude;
            set => SetProperty(ref _latitude, value);
        }

        private float _longitude;
        public float Longitude
        {
            get => _longitude;
            set => SetProperty(ref _longitude, value);
        }
        
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        private ObservableCollection<Location> _locations;
        public ObservableCollection<Location> Locations
        {
            get => _locations;
            set => SetProperty(ref _locations, value);
        }

        private async Task FindLocations()
        {
            List<Location> locationList;
            if (SearchByText)
            {
                locationList = await _locationService.GetLocationBySearchString(SearchText);
            }
            else
            {
                locationList = await _locationService.GetLocationByLattLong(Latitude, Longitude);
            }

            Locations = new ObservableCollection<Location>(locationList);
        }
    }
}