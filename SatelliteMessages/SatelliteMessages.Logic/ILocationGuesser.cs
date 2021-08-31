using System.Collections.Generic;

namespace SatelliteMessages.Logic
{
    public interface ILocationGuesser
    {
        (double X, double Y) GetLocation(List<SatelliteLocation> satellites, double acceptedOffset);
    }
}