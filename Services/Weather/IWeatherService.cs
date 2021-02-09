using ViewModels;

namespace Services.Weather
{
    public interface IWeatherService
    {
        WeatherAPIModel.Root GetWeatherByCoordinates(string baseUrl);
        WeatherForecastModel.Root GetWeatherDetails(string baseUrl);
    }
}
