using ViewModels;

namespace BusinessLogic.Weather
{
    public interface IWeatherBLL
    {
        string GetWeatherForecast(decimal lon, decimal lat);
        WeatherForecastModel.Root GetWeatherDetails(string address);
    }
}
