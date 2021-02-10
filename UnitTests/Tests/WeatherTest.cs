using BLL.GeoCoding;
using BusinessLogic.Weather;
using Moq;
using NUnit.Framework;
using Services.GeoCoding;
using Services.Weather;

namespace UnitTests.Tests
{
    [TestFixture]

    class WeatherTest
    {
        private IWeatherBLL WeatherBLL = null;
        private IGeoCodingBLL GeoCodingBLL = null;
        private Mock<WeatherService> MockWeatherService = null;
        private Mock<GeoCodingService> MockGeoCodingService = null;
        private decimal OrignalX = -70.96932M;
        private decimal OriginalY = 42.093243M;
        private string OriginalForecastURL = "https://api.weather.gov/gridpoints/TOP/31,80/forecast";
        private string CorrectAddress = "777 Brockton Avenue, Abington MA 2351";
        private string InCorrectAddress = "jsfkjfhzs";
        [SetUp]
        public void SetUp()
        {
            MockWeatherService = new Mock<WeatherService>() { CallBase = true };
            MockGeoCodingService = new Mock<GeoCodingService>() { CallBase = true };
            GeoCodingBLL = new GeoCodingBLL(MockGeoCodingService.Object);
            WeatherBLL = new WeatherBLL(MockWeatherService.Object, GeoCodingBLL);
        }

        [Test]
        public void Check_If_Weather_Forecast_Works_With_Correct_Address()
        {
            var rs = WeatherBLL.GetWeatherForecast(OrignalX, OriginalY);
            Assert.IsTrue(rs != null);
        }

        [Test]
        public void Check_If_Weather_Forecast_Works_With_In_Correct_Address()
        {
            var rs = WeatherBLL.GetWeatherForecast(0, 0);
            Assert.IsTrue(rs == null || rs == "");
        }
        [Test]
        public void Check_If_Weather_Details_Works_With_Correct_Address()
        {
            var rs = WeatherBLL.GetWeatherDetails(CorrectAddress);
            Assert.IsTrue(rs != null);
        }

        [Test]
        public void Check_If_Weather_Details_Works_With_In_Correct_Address()
        {
            var rs = WeatherBLL.GetWeatherDetails(InCorrectAddress);
            Assert.IsTrue(rs == null || rs.properties == null);
        }

    }

}
