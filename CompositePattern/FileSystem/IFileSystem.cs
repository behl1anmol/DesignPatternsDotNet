namespace CompositePattern.FileSystem;

public interface IFileSystem
{
    public string? Name { get; set; }
    public void Ls(int indent = 0);
    
}