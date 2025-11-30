
using CompositePattern;
using CompositePattern.FileSystem;
using Microsoft.Extensions.DependencyInjection;
using Directory = CompositePattern.FileSystem.Directory;
using File = CompositePattern.FileSystem.File;

var builder = new ServiceCollection();

builder.AddTransient<IDirectory, Directory>();
builder.AddTransient<IFile,File>();
builder.AddScoped<App>();
var serviceProvider = builder.BuildServiceProvider();

var app = serviceProvider.GetRequiredService<App>();
app.Run();