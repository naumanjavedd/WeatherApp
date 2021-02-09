using BLL.GeoCoding;
using Common.GeoCoding;
using Services.Weather;
using ViewModels;

namespace BusinessLogic.Weather
{
    public class WeatherBLL : IWeatherBLL
    {
        private IWeatherService weatherService;
        private IGeoCodingBLL geoCodingBLL;
        public WeatherBLL(IWeatherService weatherService, IGeoCodingBLL geoCodingBLL)
        {
            this.weatherService = weatherService;
            this.geoCodingBLL = geoCodingBLL;
        }

        public string GetWeatherForecast(decimal lon, decimal lat)
        {
            string response = "";
            string requestUrl = URLBuilder.WeatherAPIURL + lon + "," + lat;
            var result = weatherService.GetWeatherByCoordinates(requestUrl);
            if(result != null)
            {
                if (result.properties != null)
                {
                    response = result.properties.forecast;
                }
            }
            return response;
        }        
        public WeatherForecastModel.Root GetWeatherDetails(string address)
        {
            WeatherForecastModel.Root weatherDetails = new WeatherForecastModel.Root();
            if(address != null)
            {
                var coordinates = geoCodingBLL.GetCoordinates(address);
                if (coordinates.x != 0 && coordinates.y != 0)
                {
                    var forecastUrl = GetWeatherForecast(coordinates.y, coordinates.x);
                    weatherDetails = weatherService.GetWeatherDetails(forecastUrl);
                }
            }

            return weatherDetails;
        }
    }
}
