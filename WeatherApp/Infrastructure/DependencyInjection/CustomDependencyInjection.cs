using BLL.GeoCoding;
using BusinessLogic.Weather;
using Microsoft.Extensions.DependencyInjection;
using Services.GeoCoding;
using Services.Weather;

namespace WebApplication.Infrastructure
{
    public static class CustomDependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<IWeatherBLL, WeatherBLL>();

            services.AddScoped<IGeoCodingService, GeoCodingService>();
            services.AddScoped<IGeoCodingBLL, GeoCodingBLL>();
        }
    }
}
