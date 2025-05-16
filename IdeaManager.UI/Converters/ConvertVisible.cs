using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using IdeaManager.Core.Enums;


//Utiliser pour le databinding
namespace IdeaManager.UI.Converters
{
    public class ConvertVisible : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)

            //Si valeur type IdeaStatus (retour Visible), sinon element cacher
        {
            if (value is IdeaStatus status)
            {
                return status == IdeaStatus.Pending ? Visibility.Visible : Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        //One way binding 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}