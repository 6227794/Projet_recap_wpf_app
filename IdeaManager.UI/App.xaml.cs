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

        var dbPath = @"C:\Users\seddi\OneDrive\Bureau\entrepriseLab\Projet_recap_wpf_app\IdeaManager.Data\ideas.db";

        services.AddDataServices($"Data Source={dbPath}");
        services.AddDomainServices();
        services.AddUIServices();

        services.AddTransient<ProjectListView>();
        services.AddTransient<ProjectListViewModel>();

        ServiceProvider = services.BuildServiceProvider();

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

}