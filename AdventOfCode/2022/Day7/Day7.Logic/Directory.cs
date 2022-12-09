using Day7.Logic.Visitors;

namespace Day7.Logic;

public class Directory : IVisitable
{
    public string Name { get; }
    public Directory Parent { get; }
    public List<Directory> Directories { get; }
    public List<File> Files { get; }

    public Directory(string name, Directory parent)
    {
        Name = name;
        Parent = parent;
        Directories = new List<Directory>();
        Files = new List<File>();
    }

    public Directory(string name)
    {
        Name = name;
        Parent = this;
        Directories = new List<Directory>();
        Files = new List<File>();
    }

    public void AddFile(File file) =>
        Files.Add(file);

    internal int GetSizeOfFiles() =>
        Files.Sum(p => p.Size);

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
        foreach (var file in Files)
        {
            file.Accept(visitor);
        }

        foreach (var directory in Directories)
        {
            directory.Accept(visitor);
        }
    }
}