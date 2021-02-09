using ViewModels;
namespace Services.GeoCoding
{
    public interface IGeoCodingService
    {
        GeoCodingModel.Root GetGeoCoordinates(string url);
    }
}
