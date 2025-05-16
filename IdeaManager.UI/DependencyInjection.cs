using IdeaManager.UI.ViewModels;
using IdeaManager.UI.Views;
using Microsoft.Extensions.DependencyInjection;

namespace IdeaManager.UI
{

    //Enregistrer composant de linterface utilisateur dnas conteneur des services pour etre auto instancier avec depend. injecter
    public static class DependencyInjection
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services)
        {
            // Vue principale (racine)
            services.AddSingleton<MainWindow>();

            // Vues (secondaire)
            services.AddSingleton<DashboardView>();
            services.AddTransient<IdeaFormView>();
            services.AddTransient<IdeaListView>();

            // ViewModels
            services.AddTransient<DashboardViewModel>();
            services.AddTransient<IdeaFormViewModel>();
            services.AddTransient<IdeaListViewModel>();

            return services;
        }
    }
}