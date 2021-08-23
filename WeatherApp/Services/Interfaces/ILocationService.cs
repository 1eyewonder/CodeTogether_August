using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Dtos;

namespace WeatherApp.Services.Interfaces
{
    public interface ILocationService
    {
        Task<List<Location>> GetLocationBySearchString(string searchString);
        Task<List<Location>> GetLocationByLattLong(float latitude, float longitude);
    }
}