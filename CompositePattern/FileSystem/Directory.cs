namespace CompositePattern.FileSystem;

public class Directory: IDirectory
{
    public string? Name { get; set; }
    public List<IFileSystem> FileSystemList { get; } = new List<IFileSystem>();

    public Directory()
    {
        
    }
    public Directory(string name)
    {
        Name = name;
    }

    public void Ls(int indent)
    {
        Console.WriteLine($"{new string(' ', indent)}{Name}");
        foreach (var item in this.FileSystemList)
        {
            item.Ls(indent+1);
        }
    }

    public void Add(IFileSystem fs)
    {
        FileSystemList.Add(fs);
    }
    
}