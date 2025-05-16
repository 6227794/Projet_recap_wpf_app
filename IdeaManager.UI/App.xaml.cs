using IdeaManager.Data;
using IdeaManager.Services;
using IdeaManager.UI.ViewModels;
using IdeaManager.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;

namespace IdeaManager.UI;

public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    protected override void OnStartup(StartupEventArgs e)
    {
        var services = new ServiceCollection();



        services.AddDataServices("Data Source=ideas.db");
        services.AddDomainServices();
        services.AddUIServices();

        ServiceProvider = services.BuildServiceProvider();

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

}