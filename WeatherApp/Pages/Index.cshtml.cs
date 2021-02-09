using BusinessLogic.Weather;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace WeatherApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IWeatherBLL _weatherBLL;
        public IEnumerable<WeatherForecastModel.Period> Forecast { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public bool FirstTime { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IWeatherBLL weatherBLL)
        {
            _logger = logger;
            _weatherBLL = weatherBLL;
        }
        //4600 Silver Hill Rd, Suitland, MD 20746
        public void OnGet(string SearchTermss)
        {
            FirstTime = true;
            if (string.IsNullOrEmpty(SearchTerm))
            {
                FirstTime = false;
            }
            Forecast = new List<WeatherForecastModel.Period>();
            var response = _weatherBLL.GetWeatherDetails(SearchTerm);
            if (response != null)
            {
                if (response.properties != null)
                {
                    Forecast = response.properties.periods;
                }
            }
        }

        public void OnPostGetWeatherForecast(string SearchTermss)
        {
            FirstTime = true;
            if (string.IsNullOrEmpty(SearchTerm))
            {
                FirstTime = false;
            }
            Forecast = new List<WeatherForecastModel.Period>();
            var response = _weatherBLL.GetWeatherDetails(SearchTerm);
            if (response != null)
            {
                if (response.properties != null)
                {
                    Forecast = response.properties.periods;
                }
            }
        }
    }
}
