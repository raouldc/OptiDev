///////////////////////////////////////////////////////////////////////////////
//
// Some of the functionalities in this file have been adapted from
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using P02Project.WebcamPlayer.Input;
using CatenaLogic.Windows.Presentation.WebcamPlayer;
using System.Collections.ObjectModel;
using System.IO;



namespace P02Project
{
	/// <summary>
	/// Interaction logic for Webcam.xaml
	/// </summary>
	public partial class Webcam : UserControl
	{

        #region Variables
        private int numb = 0;
        private readonly String MYDOC_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        #endregion

        #region Constructor & destructor
        public Webcam()
		{
			this.InitializeComponent();
            // Subscribe command bindings
            CommandBindings.Add(new CommandBinding(P02Project.WebcamPlayer.Input.CaptureImageCommands.CaptureImage,
                new ExecutedRoutedEventHandler(CaptureImage_Executed), new CanExecuteRoutedEventHandler(CaptureImage_CanExecute)));
            CommandBindings.Add(new CommandBinding(P02Project.WebcamPlayer.Input.CaptureImageCommands.RemoveImage,
                new ExecutedRoutedEventHandler(RemoveImage_Executed)));
            CommandBindings.Add(new CommandBinding(P02Project.WebcamPlayer.Input.CaptureImageCommands.ClearAllImages,
                new ExecutedRoutedEventHandler(ClearAllImages_Executed)));

            // Create default device
            SelectedWebcamMonikerString = (CapDevice.DeviceMonikers.Length > 0) ? CapDevice.DeviceMonikers[0].MonikerString : "";
        }
        #endregion



        #region Command bindings
        /// <summary>
        /// Determines whether the CaptureImage command can be executed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void CaptureImage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Check if there is a valid webcam
            e.CanExecute = (SelectedWebcam != null);
        }

        /// <summary>
        /// Invoked when the CaptureImage command is executed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void CaptureImage_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //// Store current image in the webcam
            BitmapSource bitmap = webcamPlayer.CurrentBitmap;

            FileStream stream = new FileStream(MYDOC_PATH + "\\test"+numb+".jpg", FileMode.Create);
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            //TiffBitmapEncoder encoder = new TiffBitmapEncoder();
            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));
           // MessageBox.Show(myPalette.Colors.Count.ToString());
            encoder.Save(stream);
            stream.Close();
            numb++;

            if (bitmap != null)
            {
                SelectedImages.Add(bitmap);
            }
        }

        /// <summary>
        /// Invoked when the RemoveImage command is executed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void RemoveImage_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Store current image in the webcam
            BitmapSource bitmap = e.Parameter as BitmapSource;
            if (bitmap != null)
            {
                SelectedImages.Remove(bitmap);
            }
        }

        /// <summary>
        /// Invoked when the ClearAllImages command is executed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void ClearAllImages_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Clear all images
            SelectedImages.Clear();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Wrapper for the WebcamRotation dependency property
        /// </summary>
        public double WebcamRotation
        {
            get { return (double)GetValue(WebcamRotationProperty); }
            set { SetValue(WebcamRotationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WebcamRotation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WebcamRotationProperty =
            DependencyProperty.Register("WebcamRotation", typeof(double), typeof(Webcam), new UIPropertyMetadata(180d));

        /// <summary>
        /// Wrapper for the SelectedWebcam dependency property
        /// </summary>
        public CapDevice SelectedWebcam
        {
            get { return (CapDevice)GetValue(SelectedWebcamProperty); }
            set { SetValue(SelectedWebcamProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedWebcam.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedWebcamProperty =
            DependencyProperty.Register("SelectedWebcam", typeof(CapDevice), typeof(Webcam), new UIPropertyMetadata(null));

        /// <summary>
        /// Wrapper for the SelectedWebcamMonikerString dependency property
        /// </summary>
        public string SelectedWebcamMonikerString
        {
            get { return (string)GetValue(SelectedWebcamMonikerStringProperty); }
            set { SetValue(SelectedWebcamMonikerStringProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedWebcamMonikerString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedWebcamMonikerStringProperty = DependencyProperty.Register("SelectedWebcamMonikerString", typeof(string),
            typeof(Webcam), new UIPropertyMetadata("", new PropertyChangedCallback(SelectedWebcamMonikerString_Changed)));

        /// <summary>
        /// Wrapper for the SelectedImages dependency property
        /// </summary>
        public ObservableCollection<BitmapSource> SelectedImages
        {
            get { return (ObservableCollection<BitmapSource>)GetValue(SelectedImagesProperty); }
            set { SetValue(SelectedImagesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedImages.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedImagesProperty = DependencyProperty.Register("SelectedImages", typeof(ObservableCollection<BitmapSource>),
            typeof(Webcam), new UIPropertyMetadata(new ObservableCollection<BitmapSource>()));
        #endregion

        #region Methods
        /// <summary>
        /// Invoked when the SelectedWebcamMonikerString dependency property has changed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private static void SelectedWebcamMonikerString_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get typed sender
            Webcam typedSender = sender as Webcam;
            if (typedSender != null)
            {
                // Get new value
                string newMonikerString = e.NewValue as string;

                // Update the device
                if (typedSender.SelectedWebcam == null)
                {
                    // Create it
                    typedSender.SelectedWebcam = new CapDevice("");
                }

                // Now set the moniker string
                typedSender.SelectedWebcam.MonikerString = newMonikerString;
            }
        }
        #endregion
    }
	
}