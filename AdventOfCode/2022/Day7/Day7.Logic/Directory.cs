namespace Day7.Logic;

public class Directory
{
    public string Name { get; }
    public Directory Parent { get; }
    public List<Directory> Directories { get; }
    public List<int> Files { get; }

    public Directory(string name, Directory parent)
    {
        Name = name;
        Parent = parent;
        Directories = new List<Directory>();
        Files = new List<int>();
    }

    public Directory(string name)
    {
        Name = name;
        Parent = this;
        Directories = new List<Directory>();
        Files = new List<int>();
    }

    public void AddFileSize(int size) => Files.Add(size);

    internal int GetSizeOfFiles() => Files.Sum();
}