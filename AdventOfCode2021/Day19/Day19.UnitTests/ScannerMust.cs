using System;
using Xunit;
using Day19.Logic;
using static Day19.UnitTests.Constants;

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
/*
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
*/
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
        public void LocateScannersAroundScanner0_WhenThereAreTwoScanners()
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

            Assert.Collection(sut.GetScannerPositions(),
                p1 => Assert.Equal((0, 0, 0), p1),
                p2 => Assert.Equal((68,-1246,-43), p2));
        }

        [Fact]
        public void LocateScannersAroundScanner0_WhenThereAreThreeScanners()
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
553,889,-390

--- scanner 4 ---
727,592,562
-293,-554,779
441,611,-461
-714,465,-776
-743,427,-804
-660,-479,-426
832,-632,460
927,-485,-438
408,393,-506
466,436,-512
110,16,151
-258,-428,682
-393,719,612
-211,-452,876
808,-476,-593
-575,615,604
-485,667,467
-680,325,-822
-627,-443,-432
872,-547,-609
833,512,582
807,604,487
839,-516,451
891,-625,532
-652,-548,-490
30,-46,-14";

            var sut = new NavigationSystem(data);
            sut.CalculateDistances();
            sut.FindPossibleIntersectingBeacons();

            Assert.Collection(sut.GetScannerPositions(),
                p1 => Assert.Equal((0, 0, 0), p1),
                p2 => Assert.Equal((68,-1246,-43), p2),
                p3 => Assert.Equal((-20,-1133,1061), p3));
        }

        [Fact]
        public void LocateAllScanners()
        {
            var sut = new NavigationSystem(SAMPLE_COORDINATES);
            sut.CalculateDistances();
            sut.FindPossibleIntersectingBeacons();

            Assert.Collection(sut.GetScannerPositions(),
                p0 => Assert.Equal((0, 0, 0), p0),
                p1 => Assert.Equal((68,-1246,-43), p1),
                p2 => Assert.Equal((1105,-1205,1229), p2),
                p3 => Assert.Equal((-92,-2380,-20), p3),
                p4 => Assert.Equal((-20,-1133,1061), p4));
        }

        [Fact]
        public void LocateAllBeacons()
        {
            var sut = new NavigationSystem(SAMPLE_COORDINATES);
            sut.CalculateDistances();
            sut.FindPossibleIntersectingBeacons();
            sut.ConsolidateBeacons();

            Assert.Equal(79, sut.Beacons.Count);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new NavigationSystem(REAL_COORDINATES);
            sut.CalculateDistances();
            sut.FindPossibleIntersectingBeacons();
            sut.ConsolidateBeacons();

            Assert.NotEqual(402, sut.Beacons.Count);
            Assert.Equal(330, sut.Beacons.Count);
        }

        [Fact]
        public void CalculateManhattanDistance()
        {
            var sut = new NavigationSystem(SAMPLE_COORDINATES);
            sut.CalculateDistances();
            sut.FindPossibleIntersectingBeacons();
            sut.ConsolidateBeacons();

            Assert.Equal(3621, sut.GetLargestManhattanDistanceBetweenScanners());
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new NavigationSystem(REAL_COORDINATES);
            sut.CalculateDistances();
            sut.FindPossibleIntersectingBeacons();
            sut.ConsolidateBeacons();

            Assert.Equal(9634, sut.GetLargestManhattanDistanceBetweenScanners());
        }
    }
}