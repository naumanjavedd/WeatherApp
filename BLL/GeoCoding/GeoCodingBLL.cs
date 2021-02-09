using Common.GeoCoding;
using Services.GeoCoding;
using static ViewModels.GeoCodingModel;

namespace BLL.GeoCoding
{
    public class GeoCodingBLL : IGeoCodingBLL
    {
        private IGeoCodingService geoCodingService;
        public GeoCodingBLL(IGeoCodingService geocodingService)
        {
            geoCodingService = geocodingService;
        }
        public Coordinates GetCoordinates(string address)
        {
            Coordinates coordinates = new Coordinates();
            var url = URLBuilder.GenerateGeoCodingURL(address);
            var result = geoCodingService.GetGeoCoordinates(url);
            if (result != null)
            {
                if (result.result != null)
                {
                    if (result.result.addressMatches.Count > 0)
                    {
                        if (result.result.addressMatches[0].coordinates != null)
                        {
                            coordinates.x = result.result.addressMatches[0].coordinates.x;
                            coordinates.y = result.result.addressMatches[0].coordinates.y;
                        }
                    }
                }
            }
            return coordinates;
        }
    }
}
