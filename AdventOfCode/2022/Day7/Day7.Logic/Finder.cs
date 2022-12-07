namespace Day7.Logic;

public class Directory
{
    public string Name { get; }
    public Directory Parent { get; }
    public List<Directory> Directories { get; }
    public List<(string, int)> Files { get; }

    public Directory(string name, Directory parent)
    {
        Name = name;
        Parent = parent;
        Directories = new List<Directory>();
        Files = new List<(string, int)>();
    }

    public Directory(string name)
    {
        Name = name;
        Parent = this;
        Directories = new List<Directory>();
        Files = new List<(string, int)>();
    }
}


public class Finder
{
    private readonly string _input;
    private readonly List<Directory> _fileSystem;
    private Directory _currentDirectory;

    public Finder(string input)
    {
        _input = input;
        _currentDirectory = new Directory("/");
        _fileSystem = new List<Directory> { _currentDirectory };

        foreach (var line in input.Split("\n"))
        {
            if (line[0] == '$')
            {
                if (line.StartsWith("$ cd "))
                {
                    var directoryName = line[5..];

                    if (directoryName == "..")
                    {
                        _currentDirectory = _currentDirectory.Parent;
                    }
                    else if (_currentDirectory.Name != directoryName)
                    {
                        var targetDirectory = _currentDirectory.Directories.SingleOrDefault(d => d.Name == directoryName);
                        if (targetDirectory is null)
                        {
                            targetDirectory = new Directory(directoryName);
                            _currentDirectory.Directories.Add(targetDirectory);
                        }

                        _currentDirectory = targetDirectory;
                    }
                }
            }
            else if (line.StartsWith("dir "))
            {
                var directoryName = line[4..];
                var directory = new Directory(directoryName);
                _currentDirectory.Directories.Add(directory);
            }
        }
    }

    public int GetDirectoryCount(string target)
    {
        var total = 0;

        foreach (var directory in _fileSystem)
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

}
