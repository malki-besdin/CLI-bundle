//band bundel --output D:\folder\band.txt
using System.CommandLine;

var bundleOption = new Option<FileInfo>("--output", "File path and name");
var bundleCommand = new Command("bundel", "Bundel code files to a single file");
bundleCommand.AddOption(bundleOption);
bundleCommand.SetHandler((output) =>
{
    try
    {
        File.Create(output.FullName);
        Console.WriteLine("File is creating!!!!");
    }
    catch (DirectoryNotFoundException ex)
    {
        Console.WriteLine("Error: file path is invalid"+ex);
    }
}, bundleOption);

var rootCommand = new RootCommand("Root command File Bundler CLI");
rootCommand.AddCommand(bundleCommand);
rootCommand.InvokeAsync(args);