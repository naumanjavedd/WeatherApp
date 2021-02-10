using ViewModels;

namespace BusinessLogic.Weather
{
    public interface IWeatherBLL
    {
        string GetWeatherForecast(decimal lat, decimal lon);
        WeatherForecastModel.Root GetWeatherDetails(string address);
    }
}
