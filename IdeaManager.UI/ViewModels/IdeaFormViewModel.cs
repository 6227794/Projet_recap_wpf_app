
using System;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;

namespace IdeaManager.UI.ViewModels
{
    //Formulaire de soumission d'idee
    public partial class IdeaFormViewModel : ObservableObject
    { //RelayCommand

        //injection service et dependances
        private readonly IIdeaService _ideaService;

        public IdeaFormViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
        }

        //Creation auto. de porprieter 
        [ObservableProperty] private string title = string.Empty;
        [ObservableProperty] private string description = string.Empty;
        [ObservableProperty] private string errorMessage = string.Empty;


        //Transformee auto en commande WPF
        [RelayCommand]
        private async Task SubmitAsync()
        {
            try
            {
                var idea = new Idea { Title = Title, Description = Description };
                await _ideaService.SubmitIdeaAsync(idea);
                ErrorMessage = string.Empty;
                MessageBox.Show("Ideas saved !");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
