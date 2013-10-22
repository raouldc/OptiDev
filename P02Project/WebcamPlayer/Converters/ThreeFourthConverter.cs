///////////////////////////////////////////////////////////////////////////////
//
// This class was copied from
// Geert van Horrik's implementation in his blog.
// http://blog.catenalogic.com/post/2009/01/08/WPF-Webcam-Control-part-2.aspx
// 
// All the api and methods related to Windows Image Aquisition (WIA) were
// implemented by Tamir Khason and edited by Geert van Horrik
// 
// Those API are in WebcamPlayer folder
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Data;
using System.Diagnostics;

namespace P02Project.WebcamPlayer.Converters
{
    /// <summary>
    /// Converts a double to 3/4 of its value
    /// </summary>
    [ValueConversion(typeof(double), typeof(double))]
    public class ThreeFourthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Declare variables
            double width;

            try
            {
                // Get value
                width = (double)value;
            }
            catch (Exception)
            {
                // Trace
                Trace.TraceError("Failed to cast '{0}' to Double", value);

                // Return 0
                return 0;
            }

            // Convert
            return (width > 0) ? (width / 4) * 3 : 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
