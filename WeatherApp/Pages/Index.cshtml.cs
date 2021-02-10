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

        public string SearchTerms = "";
        public IndexModel(ILogger<IndexModel> logger, IWeatherBLL weatherBLL)
        {
            _logger = logger;
            _weatherBLL = weatherBLL;
        }

        public void OnGet(string SearchTermss)
        {

        }

        public void OnPostGetWeatherForecast()
        {
            Forecast = new List<WeatherForecastModel.Period>();
            var searchString = Request.Form["address"];
            this.SearchTerms = searchString;
            var response = _weatherBLL.GetWeatherDetails(searchString);
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
