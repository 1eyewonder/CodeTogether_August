using Xunit.Abstractions;

namespace WeatherApp.Tests
{
    public class TestBase
    {
        public ITestOutputHelper OutputHelper { get; }

        public TestBase(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
        }
    }
}