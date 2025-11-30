namespace CompositePattern.FileSystem;

public interface IDirectory : IFileSystem
{
    public List<IFileSystem> FileSystemList { get; }
    public void Add(IFileSystem fs); 
}