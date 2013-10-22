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

using System.Windows.Input;

namespace P02Project.WebcamPlayer.Input
{
    /// <summary>
    /// Class defining all commands to capture images
    /// </summary>
    public static class CaptureImageCommands
    {
        #region Constructor & destructor
        static CaptureImageCommands()
        {
            // Capture Image
            CaptureImage = new RoutedUICommand("Capture image", "CaptureImage", typeof(CaptureImageCommands));

            // Remove Image
            RemoveImage = new RoutedUICommand("Remove image", "RemoveImage", typeof(CaptureImageCommands));

            // Clear All Images
            ClearAllImages = new RoutedUICommand("Clear all images", "ClearAllImages", typeof(CaptureImageCommands));
        }
        #endregion

        /// <summary>
        /// Captures an image
        /// </summary>
        public static RoutedUICommand CaptureImage { get; private set; }

        /// <summary>
        /// Removes an image
        /// </summary>
        public static RoutedUICommand RemoveImage { get; private set; }

        /// <summary>
        /// Clears all images
        /// </summary>
        public static RoutedUICommand ClearAllImages { get; private set; }
    }
}
