using Day7.Logic.Visitors;

namespace Day7.Logic;

public class Finder : IVisitable
{
    private readonly string _input;
    private readonly List<Directory> _root;
    private Directory _currentDirectory;

    public Finder(string input)
    {
        _input = input;
        _currentDirectory = new Directory("/");
        _root = new List<Directory> { _currentDirectory };

        foreach (var line in input.Split("\n"))
        {
            if (line[0] == '$')
            {
                if (line.StartsWith("$ cd "))
                {
                    var directoryName = line[5..];

                    _currentDirectory = directoryName switch
                    {
                        ".." => _currentDirectory.Parent,
                        "/" => _root.Single(),
                        _ => _currentDirectory.Directories.Single(d => d.Name == directoryName)
                    };
                }
            }
            else if (line.StartsWith("dir "))
            {
                var directoryName = line[4..];
                var directory = new Directory(directoryName, _currentDirectory);
                _currentDirectory.Directories.Add(directory);
            }
            else
            {
                var fields = line.Split(" ");
                _currentDirectory.AddFile(new File(int.Parse(fields[0])));
            }
        }
    }

    public int GetSumOfTotalDirectoriesOfAtMost100000()
    {
        var smallDirectorySizes = new List<int>();
        var total = 0;

        foreach (var directory in _root)
        {
            total += GetSumOfTotalDirectoriesOfAtMost(directory, smallDirectorySizes, t => t <= 100000);
        }

        return smallDirectorySizes.Sum();
    }

    private int GetSumOfTotalDirectoriesOfAtMost(Directory directory, List<int> smallDirectorySizes, Func<int, bool> condition)
    {
        var total = 0;

        foreach (var current in directory.Directories)
        {
            total += GetSumOfTotalDirectoriesOfAtMost(current, smallDirectorySizes, condition);
        }

        total += directory.GetSizeOfFiles();
        if (condition(total))
        {
            smallDirectorySizes.Add(total);
        }

        return total;
    }

    public int GetSmallestDirectoryToDeleteToFreeEnoughSpace()
    {
        var directorySizeVisitor = new DirectorySizeVisitor();
        Accept(directorySizeVisitor);

        var largeDirectorySizes = new List<int>();
        var requiredSpace = 30_000_000 - (70_000_000 - directorySizeVisitor.Size);
        var total = 0;

        foreach (var directory in _root)
        {
            total += GetSumOfTotalDirectoriesOfAtLeast(directory, largeDirectorySizes, requiredSpace);
        }

        return largeDirectorySizes.OrderBy(p => p).First();
    }

    private int GetSumOfTotalDirectoriesOfAtLeast(Directory directory, List<int> largeDirectorySizes, int requiredSpace)
    {
        var total = 0;

        foreach (var current in directory.Directories)
        {
            total += GetSumOfTotalDirectoriesOfAtLeast(current, largeDirectorySizes, requiredSpace);
        }

        total += directory.GetSizeOfFiles();
        if (total >= requiredSpace)
        {
            largeDirectorySizes.Add(total);
        }

        return total;
    }

    public void Accept(IVisitor visitor)
    {
        foreach (var directory in _root)
        {
            directory.Accept(visitor);
        }
    }
}
