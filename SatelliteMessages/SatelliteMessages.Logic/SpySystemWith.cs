using System.Collections.Generic;

namespace SatelliteMessages.Logic
{
    public partial class SpySystem
    {
        public static class With
        {
            public static Builder StandardConfiguration(Builder builder) =>
                builder
                    .ConnectingTo(new List<(double X, double Y)>() { (-500, -200), (100, -100), (500, 100) })
                    .Using(new LowQualityMessageMerger())
                    .Using(new EuclideanLocationGuesser())
                    .WithToleranceOf(0.00001);

            public static Builder StandardConfiguration() =>
                StandardConfiguration(new Builder());

            public static Builder MoreTolerantConfiguration(Builder builder) =>
                builder
                    .ConnectingTo(new List<(double X, double Y)>() { (-500, -200), (100, -100), (500, 100) })
                    .Using(new LowQualityMessageMerger())
                    .Using(new EuclideanLocationGuesser())
                    .WithToleranceOf(0.01);

            public static Builder MoreTolerantConfiguration() =>
                MoreTolerantConfiguration(new Builder());
        }
    }
}