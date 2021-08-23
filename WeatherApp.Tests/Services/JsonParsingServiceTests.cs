using System.Collections.Generic;
using System.IO;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json.Linq;
using WeatherApp.Dtos;
using WeatherApp.Helpers;
using WeatherApp.MappingProfiles;
using WeatherApp.Services;
using Xunit;
using Xunit.Abstractions;

namespace WeatherApp.Tests.Services
{
    public class JsonParsingServiceTests : TestBase
    {
        public JsonParsingServiceTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public void GetLocations_WithValidJArray_ReturnsListOfLocations()
        {
            // Arrange
            var jArray = JArray.Parse(
                File.ReadAllText($"{Directory.GetCurrentDirectory()}/Locations.json"));

            var mockLogger = new Mock<ILogger<JsonParsingService>>();

            var mapper = new Mapper(new MapperConfiguration(x =>
                x.AddProfile(new LocationProfile())));

            var jsonParsingService = new JsonParsingService(
                mockLogger.Object, mapper);

            // Act
            var testLocations = jsonParsingService.GetLocations(jArray);

            // Assess
            OutputHelper.WriteLine($"Expected: list of locations with matching data: {jArray.ToJson()}");
            OutputHelper.WriteLine($"Actual: {testLocations.ToJson()}");

            // Assert
            Assert.NotEmpty(testLocations);
            Assert.IsType<List<Location>>(testLocations);
        }

        [Fact]
        public void GetLocations_WithNullJArray_ReturnsEmptyLocationList()
        {
            // Arrange
            JArray jArray = null;

            var mockLogger = new Mock<ILogger<JsonParsingService>>();

            var mapper = new Mapper(new MapperConfiguration(x =>
                x.AddProfile(new LocationProfile())));

            var jsonParsingService = new JsonParsingService(
                mockLogger.Object, mapper);

            // Act
            var testLocations = jsonParsingService.GetLocations(jArray);

            // Assess
            OutputHelper.WriteLine($"Expected: Empty list of locations {new List<Location>().ToJson()}");
            OutputHelper.WriteLine($"Actual: {testLocations.ToJson()}");

            // Assert
            Assert.Empty(testLocations);
            Assert.IsType<List<Location>>(testLocations);
        }

        [Fact]
        public void GetWeather_WithValidJsonObject_ReturnsConsolidatedWeather()
        {
            // Arrange
            var jObject = JObject.Parse(
                File.ReadAllText($"{Directory.GetCurrentDirectory()}/ConsolidatedWeather.json"));

            var mockLogger = new Mock<ILogger<JsonParsingService>>();

            var mapper = new Mapper(new MapperConfiguration(x =>
                x.AddProfile(new LocationProfile())));

            var jsonParsingService = new JsonParsingService(
                mockLogger.Object, mapper);

            // Act
            var weather = jsonParsingService.GetWeather(jObject);

            // Assess
            OutputHelper.WriteLine($"Expected: Consolidated weather with matching properties: {jObject.ToJson()}");
            OutputHelper.WriteLine($"Actual: {weather.ToJson()}");

            // Assert
            Assert.IsType<ConsolidatedWeather>(weather);
            Assert.NotNull(weather);
        }

        [Fact]
        public void GetWeather_WithNullJsonObject_ReturnsEmptyConsolidatedWeather()
        {
            // Arrange
            JObject jObject = null;

            var mockLogger = new Mock<ILogger<JsonParsingService>>();

            var mapper = new Mapper(new MapperConfiguration(x =>
                x.AddProfile(new LocationProfile())));

            var jsonParsingService = new JsonParsingService(
                mockLogger.Object, mapper);

            // Act
            var weather = jsonParsingService.GetWeather(jObject);

            // Assess
            OutputHelper.WriteLine("Expected: Consolidated weather with matching properties: " +
                                   $"{new ConsolidatedWeather { WeatherForecast = new List<Weather>(), Sources = new List<WeatherSource>() }.ToJson()}");
            OutputHelper.WriteLine($"Actual: {weather.ToJson()}");

            // Assert
            Assert.IsType<ConsolidatedWeather>(weather);
            Assert.Empty(weather.Sources);
            Assert.Empty(weather.WeatherForecast);
        }
    }
}