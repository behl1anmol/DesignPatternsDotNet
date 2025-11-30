namespace CompositePattern.FileSystem;

public class File : IFile
{
    public string? Name { get; set; }

    public File()
    {
        
    }
    public File(string name)
    {
        Name = name;
    }
    
    public void Ls(int indent)
    {
        Console.WriteLine($"{new string(' ', indent)}{Name}");
    }
}