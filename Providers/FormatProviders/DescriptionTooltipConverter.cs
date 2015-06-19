using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace Providers.FormatProviders
{
    public class DescriptionTooltipConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tooltipString = value as string;

            tooltipString = Regex.Replace(tooltipString, @"\s\s+", "\n");

            return tooltipString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
