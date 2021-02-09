using static ViewModels.GeoCodingModel;

namespace BLL.GeoCoding
{
    public interface IGeoCodingBLL
    {
       Coordinates GetCoordinates(string address);
    }
}
