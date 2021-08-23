using Xunit.Abstractions;

namespace WeatherApp.Test.Services
{
    public class LocationServiceTests
    {
        public LocationServiceTests(ITestOutputHelper testOutputHelper)
        {
            
        }

        public async Task GetLocationBySearchString_WithValidSearch_ReturnsListOfLocations()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<LocationService>>();
        }
        
    }
}