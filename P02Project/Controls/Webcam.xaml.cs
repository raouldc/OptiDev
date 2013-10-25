#region

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using CatenaLogic.Windows.Presentation.WebcamPlayer;
using P02Project.Utils;
using P02Project.WebcamPlayer.Input;

#endregion

namespace P02Project
{
    /// <summary>
    ///     Interaction logic for Webcam.xaml
    /// </summary>
    public partial class Webcam : UserControl, Animatiable
    {
        #region Variables

        private readonly String DEFAULT_TWEET = "Compose new Tweet...";
        private readonly String MYDOC_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private readonly int NUMB_LIMIT_PHOTOS = 9;
        private readonly Storyboard _sbIn;
        private int numb;

        #endregion

        /// <summary>
        ///     create a new webcam event
        /// </summary>

        #region Constructor & destructor
        public Webcam()
        {
            InitializeComponent();

            //SelectedImages.Clear();
            // Subscribe command bindings
            CommandBindings.Add(new CommandBinding(CaptureImageCommands.CaptureImage,
                CaptureImage_Executed, CaptureImage_CanExecute));
            CommandBindings.Add(new CommandBinding(CaptureImageCommands.RemoveImage,
                RemoveImage_Executed));
            CommandBindings.Add(new CommandBinding(CaptureImageCommands.ClearAllImages,
                ClearAllImages_Executed));

            _tweetBtn.Background = new SolidColorBrush((Color) ColorConverter.ConvertFromString("#FF146290"));
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            _tweetBtn.Effect = dShdow;

            // Create default device
            SelectedWebcamMonikerString = (CapDevice.DeviceMonikers.Length > 0)
                ? CapDevice.DeviceMonikers[0].MonikerString
                : "";


            _sbIn = new Storyboard();
            Util.FadeIn(_sbIn, _selectedImg);
            Util.FadeIn(_sbIn, _tweetTxt);
            Util.FadeIn(_sbIn, _imagesBox);
            Util.FadeIn(_sbIn, webcamPlayer);
        }

        #region Command bindings

        /// <summary>
        ///     Determines whether the CaptureImage command can be executed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void CaptureImage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Check if there is a valid webcam
            e.CanExecute = (SelectedWebcam != null);
        }

        /// <summary>
        ///     Invoked when the CaptureImage command is executed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void CaptureImage_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //// Store current image in the webcam
            BitmapSource bitmap = webcamPlayer.CurrentBitmap;

            if (bitmap != null)
            {
                // if the images in the SelectedImages pool are more than the limit, remove the first one
                if (SelectedImages.Count >= NUMB_LIMIT_PHOTOS)
                {
                    SelectedImages.RemoveAt(0);
                }
                SelectedImages.Add(bitmap);

                // create a new name with the incremented numb (e.g. test0.jpg, test1.jpg, ...)
                String filename = MYDOC_PATH + "\\test" + numb + ".jpg";
                numb++;
                // call a helper method to write this bitmap to this filename.
                writeThisImageTo(bitmap, filename);

                _selectedImg.Source = bitmap;
            }
        }

        /// <summary>
        ///     Invoked when the RemoveImage command is executed
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
        ///     Invoked when the ClearAllImages command is executed
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

        // Using a DependencyProperty as the backing store for WebcamRotation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WebcamRotationProperty =
            DependencyProperty.Register("WebcamRotation", typeof (double), typeof (Webcam), new UIPropertyMetadata(180d));

        // Using a DependencyProperty as the backing store for SelectedWebcam.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedWebcamProperty =
            DependencyProperty.Register("SelectedWebcam", typeof (CapDevice), typeof (Webcam),
                new UIPropertyMetadata(null));

        // Using a DependencyProperty as the backing store for SelectedWebcamMonikerString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedWebcamMonikerStringProperty =
            DependencyProperty.Register("SelectedWebcamMonikerString", typeof (string),
                typeof (Webcam), new UIPropertyMetadata("", SelectedWebcamMonikerString_Changed));

        // Using a DependencyProperty as the backing store for SelectedImages.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedImagesProperty = DependencyProperty.Register(
            "SelectedImages", typeof (ObservableCollection<BitmapSource>),
            typeof (Webcam), new UIPropertyMetadata(new ObservableCollection<BitmapSource>()));

        /// <summary>
        ///     Wrapper for the WebcamRotation dependency property
        /// </summary>
        public double WebcamRotation
        {
            get { return (double) GetValue(WebcamRotationProperty); }
            set { SetValue(WebcamRotationProperty, value); }
        }

        /// <summary>
        ///     Wrapper for the SelectedWebcam dependency property
        /// </summary>
        public CapDevice SelectedWebcam
        {
            get { return (CapDevice) GetValue(SelectedWebcamProperty); }
            set { SetValue(SelectedWebcamProperty, value); }
        }

        /// <summary>
        ///     Wrapper for the SelectedWebcamMonikerString dependency property
        /// </summary>
        public string SelectedWebcamMonikerString
        {
            get { return (string) GetValue(SelectedWebcamMonikerStringProperty); }
            set { SetValue(SelectedWebcamMonikerStringProperty, value); }
        }

        /// <summary>
        ///     Wrapper for the SelectedImages dependency property
        /// </summary>
        public ObservableCollection<BitmapSource> SelectedImages
        {
            get { return (ObservableCollection<BitmapSource>) GetValue(SelectedImagesProperty); }
            set { SetValue(SelectedImagesProperty, value); }
        }

        #endregion

        #region Methods

        public void AnimateIn()
        {
            _sbIn.Begin(this);
        }

        public void AnimateOut()
        {
        }

        /// <summary>
        ///     Invoked when the SelectedWebcamMonikerString dependency property has changed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private static void SelectedWebcamMonikerString_Changed(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
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


        /// <summary>
        ///     A helper method that write a given image to a given filename
        /// </summary>
        /// <param name="bitmap"></param>
        private void writeThisImageTo(BitmapSource bitmap, String filename)
        {
            // open a stream
            FileStream stream = new FileStream(filename, FileMode.Create);
            // create an encoder
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author;
            // add the bitmap to the frame
            encoder.Frames.Add(BitmapFrame.Create(bitmap));
            encoder.Save(stream);
            // close the stream
            stream.Close();
        }

        #endregion

        #region event handlers

        /// <summary>
        ///     invoked when an image in the select pool has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectedImageClicked(Object sender, RoutedEventArgs e)
        {
            Button btn = (Button) sender;
            BitmapSource bitmap = ((Image) btn.Content).Source as BitmapSource;

            _selectedImg.Source = bitmap;

            ResetTimer();
        }

        private void ResetTimer()
        {
            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException)
            {
            }
        }


        /// <summary>
        ///     Invoked when tweeting textbox has been touched.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tweetTxtFocused(object sender, RoutedEventArgs e)
        {
            // if the tweeting text is default, remove it
            if (_tweetTxt.Text.Equals(DEFAULT_TWEET))
            {
                _tweetTxt.Text = "";
            }

            ResetTimer();
        }


        /// <summary>
        ///     Invoked when "Tweet" button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tweetBtnClicked(object sender, RoutedEventArgs e)
        {
            // the bitmap image that need to post
            BitmapSource bitmap = _selectedImg.Source as BitmapSource;
            // the text that need to post
            String newTweet = _tweetTxt.Text;

            // do the tweet post 

            Twitter twitter = new Twitter(this);

            _tweetBtn.Content = "Uploading...";

            twitter.postTweet(newTweet, bitmap, this);

            ResetTimer();
        }

        private void tweetTxt_KeyDown(object sender, KeyEventArgs e)
        {
            ResetTimer();
        }

        private void tweetTxtKeyUp(object sender, MouseButtonEventArgs e)
        {
            // if the tweeting text is default, remove it
            if (_tweetTxt.Text.Equals(""))
            {
                _tweetTxt.Text = DEFAULT_TWEET;
            }
        }

        #endregion

        #endregion
    }
}