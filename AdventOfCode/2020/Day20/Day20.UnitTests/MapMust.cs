using Xunit;
using AdventOfCode2020.Day20.Logic;

namespace AdventOfCode2020.Day20.UnitTests
{
    public class MapMust
    {
        [Fact]
        public void DetectCornersCorrectly_WhenMapHasWidthOfOne()
        {
            var map = new Map(PuzzleData.ThreeTileMap, 1, 2);

            map.ClassifyEdge();
            Assert.Collection(map.Corners,
                p1 => Assert.Equal(1951, p1.Id),
                p2 => Assert.Equal(3079, p2.Id));
        }

        [Fact]
        public void DetectCornersCorrectly_WhenMapHasHeightOfOne()
        {
            var map = new Map(PuzzleData.ThreeTileMap, 2, 1);

            map.ClassifyEdge();
            Assert.Collection(map.Corners,
                p1 => Assert.Equal(1951, p1.Id),
                p2 => Assert.Equal(3079, p2.Id));
        }

        [Fact]
        public void DetectBordersCorrectly_WhenMapHasWidthOfOne()
        {
            var map = new Map(PuzzleData.ThreeTileMap, 1, 2);

            map.ClassifyEdge();
            Assert.Collection(map.Borders, p1 => Assert.Equal(2311, p1.Id));
        }

        [Fact]
        public void DetectBordersCorrectly_WhenMapHasHeightOfOne()
        {
            var map = new Map(PuzzleData.ThreeTileMap, 2, 1);

            map.ClassifyEdge();
            Assert.Collection(map.Borders, p1 => Assert.Equal(2311, p1.Id));
        }

        [Fact]
        public void DetectCornersCorrectlyFromSampleData()
        {
            var map = new Map(PuzzleData.SAMPLE_DATA, 3, 3);

            map.ClassifyEdge();
            Assert.Collection(map.Corners,
                p1 => Assert.Equal(1951, p1.Id),
                p2 => Assert.Equal(1171, p2.Id),
                p3 => Assert.Equal(2971, p3.Id),
                p4 => Assert.Equal(3079, p4.Id));
        }

        [Fact]
        public void DetectBordersCorrectlyFromSampleData()
        {
            var map = new Map(PuzzleData.SAMPLE_DATA, 3, 3);

            map.ClassifyEdge();
            Assert.Collection(map.Borders,
                p1 => Assert.Equal(2311, p1.Id),
                p2 => Assert.Equal(1489, p2.Id),
                p3 => Assert.Equal(2473, p3.Id),
                p4 => Assert.Equal(2729, p4.Id));
        }

        [Fact]
        public void CalculateCornersMultipliedCorrectlyFromSampleData()
        {
            var map = new Map(PuzzleData.SAMPLE_DATA, 3, 3);

            map.ClassifyEdge();
            Assert.Equal(20899048083289UL, map.CornersMultiplied);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var map = new Map(PuzzleData.PUZZLE_DATA, 12, 12);
            map.ClassifyEdge();
            Assert.Collection(map.Corners,
                p1 => Assert.Equal(3413, p1.Id),
                p2 => Assert.Equal(3607, p2.Id),
                p3 => Assert.Equal(3371, p3.Id),
                p4 => Assert.Equal(2617, p4.Id));

            Assert.Equal(108603771107737UL, map.CornersMultiplied);
        }

        [Fact]
        public void GenerateCornersCorrectly_WhenUsingSampleData()
        {
            var map = new Map(PuzzleData.SAMPLE_DATA, 3, 3);
            map.ClassifyEdge();

            Assert.Collection(map.Corners,
                p1 => Assert.Collection(p1.InnerSide.Keys,
                    s1 => Assert.Equal("#.##...##.", s1),
                    s2 => Assert.Equal(".#####..#.", s2)),
                p2 => Assert.Collection(p2.InnerSide.Keys,
                    s1 => Assert.Equal("####...##.", s1),
                    s2 => Assert.Equal(".#..#.....", s2)),
                p3 => Assert.Collection(p3.InnerSide.Keys,
                    s1 => Assert.Equal("#...##.#.#", s1),
                    s2 => Assert.Equal("...#.#.#.#", s2)),
                p4 => Assert.Collection(p4.InnerSide.Keys,
                    s1 => Assert.Equal("..#.###...", s1),
                    s2 => Assert.Equal("#..##.#...", s2)));
        }

        [Fact]
        public void GenerateBordersCorrectly_WhenUsingSampleData()
        {
            var map = new Map(PuzzleData.SAMPLE_DATA, 3, 3);
            map.ClassifyEdge();
            Assert.Collection(map.Borders,
                p1 => Assert.Collection(p1.InnerSide.Keys,
                    s1 => Assert.Equal("..##.#..#.", s1),
                    s2 => Assert.Equal("...#.##..#", s2),
                    s3 => Assert.Equal(".#####..#.", s3)),
                p2 => Assert.Collection(p2.InnerSide.Keys,
                    s1 => Assert.Equal(".....#..#.", s1),
                    s2 => Assert.Equal("###.##.#..", s2),
                    s3 => Assert.Equal("#...##.#.#", s3)),
                p3 => Assert.Collection(p3.InnerSide.Keys,
                    s1 => Assert.Equal("...###.#..", s1),
                    s2 => Assert.Equal("..###.#.#.", s2),
                    s3 => Assert.Equal("####...##.", s3)),
                p4 => Assert.Collection(p4.InnerSide.Keys,
                    s1 => Assert.Equal("...#.#.#.#", s1),
                    s2 => Assert.Equal("#..#......", s2),
                    s3 => Assert.Equal("#.##...##.", s3)));
        }

        [Fact]
        public void ReassembleSampleMapCorrectly()
        {
            var map = new Map(PuzzleData.SAMPLE_DATA, 3, 3);
            map.ClassifyEdge();
            map.ReformEdge();

            var reassembledMap = map.GetReassembledMap();
            Assert.Equal(1951, reassembledMap[0,0].Id);
            Assert.Equal(2729, reassembledMap[0,1].Id);
            Assert.Equal(2971, reassembledMap[0,2].Id);
            Assert.Equal(2311, reassembledMap[1,0].Id);
            Assert.Equal(1427, reassembledMap[1,1].Id);
            Assert.Equal(1489, reassembledMap[1,2].Id);
            Assert.Equal(3079, reassembledMap[2,0].Id);
            Assert.Equal(2473, reassembledMap[2,1].Id);
            Assert.Equal(1171, reassembledMap[2,2].Id);
        }

        [Fact]
        public void FindAllMonstersInSampleData()
        {
            var sut = new Map(PuzzleData.SAMPLE_DATA, 3, 3);
            sut.ClassifyEdge();
            sut.ReformEdge();
            sut.Crop();
            sut.FindMonsters();
            Assert.Equal(2, sut.MonstersFoundInMap);
        }

        [Fact]
        public void FindWaterRoughnessInSampleData()
        {
            var map = new Map(PuzzleData.SAMPLE_DATA, 3, 3);
            map.ClassifyEdge();
            map.ReformEdge();
            map.Crop();
            map.FindMonsters();
            Assert.Equal(273, map.WaterRoughness);
        }

        [Fact]
        public void FindAllMonstersInSecondPuzzle_WhenMapIsCorrectlyAligned()
        {
            var sut = new Map(PuzzleData.SECOND_PUZZLE_SOLUTION_MAP_WITH_HEADER, 1, 1);
            sut.ClassifyEdge();
            sut.ReformEdge();
            sut.FindMonsters();
            Assert.Equal(22, sut.MonstersFoundInMap);
        }

        [Fact]
        public void FindAllMonstersInSecondPuzzle_WhenMapIsCompletelyShuffled()
        {
            var sut = new Map(PuzzleData.SECOND_PUZZLE_SOLUTION_MAP_WITH_HEADER, 1, 1);
            sut.ClassifyEdge();
            sut.ReformEdge();
            sut.FlipVertically();

            sut.FindMonsters();
            Assert.Equal(22, sut.MonstersFoundInMap);
        }

        [Fact]
        public void FindWaterRoughnessInPuzzle_WhenPuzzleFitsInASingleTile()
        {
            var sut = new Map(PuzzleData.SECOND_PUZZLE_SOLUTION_MAP_WITH_HEADER, 1, 1);
            sut.ClassifyEdge();
            sut.ReformEdge();
            sut.FindMonsters();
            Assert.Equal(2129, sut.WaterRoughness);
        }

        [Fact]
        public void FindAllMonstersInSecondPuzzle()
        {
            var sut = new Map(PuzzleData.PUZZLE_DATA, 12, 12);
            sut.ClassifyEdge();
            sut.ReformEdge();
            sut.Crop();

            sut.FindMonsters();
            Assert.Equal(22, sut.MonstersFoundInMap);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new Map(PuzzleData.PUZZLE_DATA, 12, 12);
            sut.ClassifyEdge();
            sut.ReformEdge();
            sut.Crop();

            sut.FindMonsters();
            Assert.Equal(2129, sut.WaterRoughness);
        }
    }
}