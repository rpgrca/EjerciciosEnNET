using System.Collections.Generic;

namespace SatelliteMessages.Logic
{
    public partial class SpySystem
    {
        public class Builder
        {
            private List<(double X, double Y)> _satellites;
            private double _acceptedOffset;
            private IMessageMerger _messageMerger;
            private ILocationGuesser _locationGuesser;

            public Builder WithToleranceOf(double offset)
            {
                _acceptedOffset = offset;
                return this;
            }

            public Builder Using(IMessageMerger messageMerger)
            {
                _messageMerger = messageMerger;
                return this;
            }

            public Builder Using(ILocationGuesser locationGuesser)
            {
                _locationGuesser = locationGuesser;
                return this;
            }

            public Builder ConnectingTo(List<(double X, double Y)> satellites)
            {
                _satellites = satellites;
                return this;
            }

            public SpySystem Build() => new(_satellites, _messageMerger, _locationGuesser, _acceptedOffset);
        }
    }
}