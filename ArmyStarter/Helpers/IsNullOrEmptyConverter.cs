using System;
using Windows.UI.Xaml.Data;

namespace ArmyStarter.Helpers
{
    class IsNullOrEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!bool.Parse((string)parameter))
            {
                return !string.IsNullOrEmpty((string)value);
            }
            return string.IsNullOrEmpty((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
