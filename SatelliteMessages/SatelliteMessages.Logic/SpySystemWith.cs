using System.Collections.Generic;

namespace SatelliteMessages.Logic
{
    public static class SpySystemWith
    {
        public static SpySystem.Builder StandardConfiguration(SpySystem.Builder builder) =>
            builder
                .ConnectingTo(new List<(double X, double Y)>() { (-500, -200), (100, -100), (500, 100) })
                .Using(new LowQualityMessageMerger())
                .WithToleranceOf(0.00001);

        public static SpySystem.Builder StandardConfiguration() =>
            StandardConfiguration(new SpySystem.Builder());

        public static SpySystem.Builder MoreTolerantConfiguration(SpySystem.Builder builder) =>
            builder
                .ConnectingTo(new List<(double X, double Y)>() { (-500, -200), (100, -100), (500, 100) })
                .Using(new LowQualityMessageMerger())
                .WithToleranceOf(0.01);

        public static SpySystem.Builder MoreTolerantConfiguration() =>
            MoreTolerantConfiguration(new SpySystem.Builder());
    }
}