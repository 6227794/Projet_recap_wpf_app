using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


//Gestion de la listes d'idées
namespace IdeaManager.UI.ViewModels
{

    //Heritage pour INotifyPropertyChanged (DataBinding)
    public partial class IdeaListViewModel : ObservableObject
    {

        //Injections des dependances
        private readonly IIdeaService _ideaService;

        [ObservableProperty]
        private ObservableCollection<Idea> ideas = new();

        //Lier au btn dans vue
        public IAsyncRelayCommand<Idea> ApproveCommand { get; }
        public IAsyncRelayCommand<Idea> RejectCommand { get; }

        //Constructeur
        public IdeaListViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;

            ApproveCommand = new AsyncRelayCommand<Idea>(async idea =>
            {

                //Si idee passer elle peut etre rejeter ou approuver
                if (idea != null)
                {
                    await _ideaService.ApprovedIdeaAsync(idea);
                    await LoadIdeasAsync();
                }
            });

            RejectCommand = new AsyncRelayCommand<Idea>(async idea =>
            {
                if (idea != null)
                {
                    await _ideaService.RejectIdeaAsync(idea);
                    await LoadIdeasAsync();
                }
            });

        }

        //Chargement des idees
        public async Task LoadIdeasAsync()
        {
            var ideasFromDb = await _ideaService.GetAllAsync();
            Ideas = new ObservableCollection<Idea>(ideasFromDb);
        }
    }
}