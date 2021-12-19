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
        public void RotateScanner90DegreesClockwiseOnXaxis()
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

            /*
                 z                                       z            
                 |                                       7
                 |  -7                                   |    
                 |  /                                    |  /
                 | /                                     | /
        -8_______0/__________ x                 _________0/________8_ x
                 /                                       /
                /                                       /
               /                                       /
              /                                       /
             y                                       y

            1,-1,1
2,-2,2
3,-3,3
2,-1,3
-5,4,-6
-8,0,7";
8,-7,0*/
        }
    }
}
