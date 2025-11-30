using CompositePattern.FileSystem;
using Microsoft.Extensions.DependencyInjection;

namespace CompositePattern;

public class App
{
    private readonly IServiceProvider _serviceProvider;
    public App(IServiceProvider serviceProvider)
    {
        this._serviceProvider = serviceProvider;
    }
    
    private IDirectory CreateDirectory(string name)
    {
        var directory = _serviceProvider.GetRequiredService<IDirectory>();
        directory.Name = name;
        return directory;
    }
    
    private IFile CreateFile(string name)
    {
        var file = _serviceProvider.GetRequiredService<IFile>();
        file.Name = name;
        return file;
    }
    
    public void Run()
    {
        var root = CreateDirectory("root");
        var home = CreateDirectory("home");
        var user = CreateDirectory("user");
        var documents = CreateDirectory("documents");
        var photos = CreateDirectory("photos");
        
        var file1 = CreateFile("file1.txt");
        var file2 = CreateFile("file2.txt");
        var photo1 = CreateFile("photo1.jpg");
        var photo2 = CreateFile("photo2.jpg");
        
        root.Add(home);
        home.Add(user);
        user.Add(documents);
        user.Add(photos);
        
        documents.Add(file1);
        documents.Add(file2);
        
        photos.Add(photo1);
        photos.Add(photo2);
        
        root.Ls();
    }
}