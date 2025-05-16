using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IdeaManager.UI.ViewModels;

namespace IdeaManager.UI.Views
{
    /// <summary>
    /// Logique d'interaction pour IdeaFormView.xaml
    /// </summary>
    public partial class IdeaFormView : Page
    {

        //Construit contenu defini dans fichier .xaml 
        public IdeaFormView(IdeaFormViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void OnBackClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService?.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

    }
}