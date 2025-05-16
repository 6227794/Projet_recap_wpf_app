using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using IdeaManager.UI.ViewModels;

namespace IdeaManager.UI.Views
{
    public partial class ProjectListView : Page
    {
        private readonly ProjectListViewModel _viewModel;

        public ProjectListView(ProjectListViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;

            Loaded += async (_, __) => await _viewModel.LoadApprovedIdeasAsync();
        }

        private void OnBackClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService?.CanGoBack == true)
                NavigationService.GoBack();
        }
    }
}