using System;
using Xunit;
using Day19.Logic;

namespace Day19.UnitTests
{
    public class ScannerMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidData(string invalidData)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Scanner(invalidData));
            Assert.Equal("Invalid data", exception.Message);
        }

        [Theory]
        [InlineData(@"--- scanner 0 ---
-1,-1,1
-2,-2,2
-3,-3,3
-2,-3,1
5,6,-4
8,0,7")]
        [InlineData(@"--- scanner 0 ---
1,-1,1
2,-2,2
3,-3,3
2,-1,3
-5,4,-6
-8,-7,0")]
        [InlineData(@"--- scanner 0 ---
-1,-1,-1
-2,-2,-2
-3,-3,-3
-1,-3,-2
4,6,5
-7,0,8")]
        [InlineData(@"--- scanner 0 ---
1,1,-1
2,2,-2
3,3,-3
1,3,-2
-4,-6,5
7,0,8")]
        [InlineData(@"--- scanner 0 ---
1,1,1
2,2,2
3,3,3
3,1,2
-6,-4,-5
0,7,-8")]
        public void ParseDataCorrectly(string data)
        {
            var sut = new Scanner(data);
            Assert.Equal(6, sut.Beacons.Count);
        }

        [Fact]
        public void FindAcombinationForTheSecondEquivalence()
        {
            const string data = @"--- scanner 0 ---
-1,-1,1
-2,-2,2
-3,-3,3
-2,-3,1
5,6,-4
8,0,7";

            var sut = new Scanner(data);
            sut.RotateOnZaxis(180);
            sut.RotateOnXaxis(270);

            Assert.Collection(sut.Beacons,
                p1 => Assert.Equal((1, -1, 1), p1),
                p1 => Assert.Equal((2, -2, 2), p1),
                p1 => Assert.Equal((3, -3, 3), p1),
                p1 => Assert.Equal((2, -1, 3), p1),
                p1 => Assert.Equal((-5, 4, -6), p1),
                p2 => Assert.Equal((-8, -7, 0), p2));
        }

        [Fact]
        public void FindAcombinationForTheThirdEquivalence()
        {
            const string data = @"--- scanner 0 ---
-1,-1,1
-2,-2,2
-3,-3,3
-2,-3,1
5,6,-4
8,0,7";

            var sut = new Scanner(data);
            sut.RotateOnYaxis(90);

            Assert.Collection(sut.Beacons,
                p1 => Assert.Equal((-1,-1,-1), p1),
                p2 => Assert.Equal((-2,-2,-2), p2),
                p3 => Assert.Equal((-3,-3,-3), p3),
                p4 => Assert.Equal((-1,-3,-2), p4),
                p5 => Assert.Equal((4,6,5), p5),
                p6 => Assert.Equal((-7,0,8), p6));
        }

        [Fact]
        public void FindAcombinationForTheFourthEquivalence()
        {
            const string data = @"--- scanner 0 ---
-1,-1,1
-2,-2,2
-3,-3,3
-2,-3,1
5,6,-4
8,0,7";

            var sut = new Scanner(data);
            sut.RotateOnYaxis(270);
            sut.RotateOnXaxis(180);

            Assert.Collection(sut.Beacons,
                p1 => Assert.Equal((1, 1, -1), p1),
                p2 => Assert.Equal((2, 2, -2), p2),
                p3 => Assert.Equal((3, 3, -3), p3),
                p4 => Assert.Equal((1, 3, -2), p4),
                p5 => Assert.Equal((-4, -6, 5), p5),
                p6 => Assert.Equal((7, 0, 8), p6));
        }

        [Fact]
        public void FindAcombinationForTheFifthEquivalence()
        {
            const string data = @"--- scanner 0 ---
-1,-1,1
-2,-2,2
-3,-3,3
-2,-3,1
5,6,-4
8,0,7";

            var sut = new Scanner(data);
            sut.RotateOnZaxis(90);
            sut.RotateOnXaxis(270);
            sut.RotateOnZaxis(180);

            Assert.Collection(sut.Beacons,
                p1 => Assert.Equal((1, 1, 1), p1),
                p2 => Assert.Equal((2, 2, 2), p2),
                p3 => Assert.Equal((3, 3, 3), p3),
                p4 => Assert.Equal((3, 1, 2), p4),
                p5 => Assert.Equal((-6, -4, -5), p5),
                p6 => Assert.Equal((0, 7, -8), p6));
        }

        [Fact]
        public void CalculateEuclideanDistanceBetweenTwoBeaconsCorrectly()
        {
            var scanner0 = new Scanner("--- scanner 0 ---\n-618,-824,-621\n-537,-823,-458");
            var distance0 = scanner0.CalculateDistanceBetweenBeaconsWithIndex(0, 1);

            var scanner1 = new Scanner("--- scanner 1 ---\n686,422,578\n605,423,415");
            var distance1 = scanner1.CalculateDistanceBetweenBeaconsWithIndex(0, 1);

            Assert.Equal(distance0, distance1);
        }

        [Fact]
        public void CalculateEuclideanDistancesBetweenBothBeaconsInAlist()
        {
            var sut = new Scanner("--- scanner 0 ---\n-618,-824,-621\n-537,-823,-458");
            sut.CalculateDistances();
            Assert.Collection(sut.Distances,
                p1 => Assert.Equal(182.01922975334227, p1.Distance));
        }

        [Fact]
        public void CalculateEuclideanDistanceBetweenThreeBeaconsInAlist()
        {
            var sut = new Scanner("--- scanner 0 ---\n-618,-824,-621\n-537,-823,-458\n-447,-329,318");
            sut.CalculateDistances();
            Assert.Collection(sut.Distances,
                p1 => Assert.Equal(182.01922975334227, p1.Distance),
                p2 => Assert.Equal(1075.1683589094314, p2.Distance),
                p3 => Assert.Equal(924.2899977820814, p3.Distance));
        }

        [Fact]
        public void Initialize()
        {
            const string data = @"--- scanner 0 ---
404,-588,-901
528,-643,409
-838,591,734
390,-675,-793
-537,-823,-458
-485,-357,347
-345,-311,381
-661,-816,-575
-876,649,763
-618,-824,-621
553,345,-567
474,580,667
-447,-329,318
-584,868,-557
544,-627,-890
564,392,-477
455,729,728
-892,524,684
-689,845,-530
423,-701,434
7,-33,-71
630,319,-379
443,580,662
-789,900,-551
459,-707,401

--- scanner 1 ---
686,422,578
605,423,415
515,917,-361
-336,658,858
95,138,22
-476,619,847
-340,-569,-846
567,-361,727
-460,603,-452
669,-402,600
729,430,532
-500,-761,534
-322,571,750
-466,-666,-811
-429,-592,574
-355,545,-477
703,-491,-529
-328,-685,520
413,935,-424
-391,539,-444
586,-435,557
-364,-763,-893
807,-499,-711
755,-354,-619
553,889,-390";

            var sut = new NavigationSystem(data);
            sut.CalculateDistances();
            sut.FindPossibleIntersectingBeacons();

            Assert.Equal((68,-1246,-43), sut.ScannerPositions[1]);
        }
    }
}