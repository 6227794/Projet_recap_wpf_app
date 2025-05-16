using System;
using System.Windows;
using System.Windows.Controls;
using IdeaManager.UI.ViewModels;
using IdeaManager.Core.Entities;

namespace IdeaManager.UI.Views
{
    public partial class IdeaListView : Page
    {
        private readonly IdeaListViewModel _viewModel;

        public IdeaListView(IdeaListViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            Loaded += IdeaListView_Loaded;
        }


        //Affichage dynamique
        private async void IdeaListView_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await _viewModel.LoadIdeasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des idées : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnBackClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService?.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

        //btn lier au view model
        private async void OnApproveClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Idea idea)
            {
                if (_viewModel.ApproveCommand.CanExecute(idea))
                {
                    await _viewModel.ApproveCommand.ExecuteAsync(idea);
                }
            }
        }

        private async void OnRejectClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Idea idea)
            {
                if (_viewModel.RejectCommand.CanExecute(idea))
                {
                    await _viewModel.RejectCommand.ExecuteAsync(idea);
                }
            }
        }
    }
}