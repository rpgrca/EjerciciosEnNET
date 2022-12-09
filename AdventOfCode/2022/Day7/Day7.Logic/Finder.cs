namespace Day7.Logic;

public class Finder
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
                _currentDirectory.AddFileSize(int.Parse(fields[0]));
            }
        }
    }

    public int GetDirectoryCount()
    {
        var total = 0;

        foreach (var directory in _root)
        {
            total += GetDirectoryCount(directory);
        }

        return total;
    }

    private int GetDirectoryCount(Directory directory)
    {
        var total = 1;

        foreach (var current in directory.Directories)
        {
            total += GetDirectoryCount(current);
        }

        return total;
    }

    public int GetFileCount()
    {
        var total = 0;
        foreach (var directory in _root)
        {
            total += GetFileCount(directory);
        }

        return total;
    }

    private int GetFileCount(Directory directory)
    {
        var total = directory.Files.Count;

        foreach (var current in directory.Directories)
        {
            total += GetFileCount(current);
        }

        return total;
    }

    public int GetDirectorySize()
    {
        var total = 0;

        foreach (var directory in _root)
        {
            total += GetDirectorySize(directory);
        }

        return total;
    }

    private int GetDirectorySize(Directory directory)
    {
        var total = directory.GetSizeOfFiles();

        foreach (var current in directory.Directories)
        {
            total += GetDirectorySize(current);
        }

        return total;
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
        var largeDirectorySizes = new List<int>();
        var requiredSpace = 30_000_000 - (70_000_000 - GetDirectorySize());
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
}
