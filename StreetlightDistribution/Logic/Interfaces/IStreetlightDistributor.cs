using StreetlightDistribution.Model.DTO;

namespace StreetlightDistribution.Logic.Interfaces
{
    public interface IStreetlightDistributor
    {
        StreetlightResponse DistributeStreetlights(StreetlightRequest request);
    }
}
