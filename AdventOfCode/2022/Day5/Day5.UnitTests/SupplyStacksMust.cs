using Day5.Logic;
using static Day5.UnitTests.Constants;

namespace Day5.UnitTests;

public class SupplyStacksMust
{
    [Fact]
    public void LoadSampleInputCorrectly()
    {
        const string input = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 ";
        var sut = SupplyStacks.CreateForFirstPuzzle(input);
        Assert.Equal("NDP", sut.TopCrates);
    }

    [Fact]
    public void LoadPuzzleInputCorrectly()
    {
        const string input = @"            [M] [S] [S]            
        [M] [N] [L] [T] [Q]        
[G]     [P] [C] [F] [G] [T]        
[B]     [J] [D] [P] [V] [F] [F]    
[D]     [D] [G] [C] [Z] [H] [B] [G]
[C] [G] [Q] [L] [N] [D] [M] [D] [Q]
[P] [V] [S] [S] [B] [B] [Z] [M] [C]
[R] [H] [N] [P] [J] [Q] [B] [C] [F]
 1   2   3   4   5   6   7   8   9 ";

        var sut = SupplyStacks.CreateForFirstPuzzle(input);
        Assert.Equal("GGMMSSQFG", sut.TopCrates);
    }

    [Fact]
    public void ExecuteInstructionCorrectly()
    {
        const string input = @"    [D]    
[N] [C]    
[Z] [M] [P]
move 1 from 2 to 1";

        var sut = SupplyStacks.CreateForFirstPuzzle(input);
        Assert.Equal("DCP", sut.TopCrates);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = SupplyStacks.CreateForFirstPuzzle(SAMPLE_INPUT);
        Assert.Equal("CMZ", sut.TopCrates);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = SupplyStacks.CreateForFirstPuzzle(PUZZLE_INPUT);
        Assert.Equal("TLNGFGMFN", sut.TopCrates);
    }

    [Fact]
    public void ExecuteInstructionCorrectly_WhenUsingCrateMover9001()
    {
        const string input = @"    [D]    
[N] [C]    
[Z] [M] [P]
move 1 from 2 to 1";

        var sut = SupplyStacks.CreateForSecondPuzzle(input);
        Assert.Equal("DCP", sut.TopCrates);
    }

    [Fact]
    public void ExecuteMultipleMoveCorrectly_WhenUsingCrateMover9001()
    {
        const string input = @"[D]        
[N] [C]    
[Z] [M] [P]
 1   2   3 
move 3 from 1 to 3";

        var sut = SupplyStacks.CreateForSecondPuzzle(input);
        Assert.Equal("CD", sut.TopCrates);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = SupplyStacks.CreateForSecondPuzzle(SAMPLE_INPUT);
        Assert.Equal("MCD", sut.TopCrates);
    }

    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = SupplyStacks.CreateForSecondPuzzle(PUZZLE_INPUT);
        Assert.Equal("FGLQJCMBD", sut.TopCrates);
    }
}