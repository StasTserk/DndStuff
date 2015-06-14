using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace Providers.FormatProviders
{
    class DescriptionTooltipConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tooltipString = value.ToString();

            var regex = new Regex(@"(\s)*(\n)(\s)*");

            return regex.IsMatch(tooltipString) ? regex.Replace(tooltipString, @"&#x0a;") : tooltipString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
