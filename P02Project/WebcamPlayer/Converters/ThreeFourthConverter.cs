#region

using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

#endregion

namespace P02Project.WebcamPlayer.Converters
{
    /// <summary>
    ///     Converts a double to 3/4 of its value
    /// </summary>
    [ValueConversion(typeof (double), typeof (double))]
    public class ThreeFourthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Declare variables
            double width;

            try
            {
                // Get value
                width = (double) value;
            }
            catch (Exception)
            {
                // Trace
                Trace.TraceError("Failed to cast '{0}' to Double", value);

                // Return 0
                return 0;
            }

            // Convert
            return (width > 0) ? (width/4)*3 : 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}