using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace P02Project.Screens
{
    /// <summary>
    /// Interaction logic for PloaroidWithText.xaml
    /// </summary>
    public partial class PoloroidWithText : UserControl
    {
        public PoloroidWithText()
        {
            InitializeComponent();
        }
        /// <summary>
        /// construct a new poloroid with text element
        /// </summary>
        /// <param name="title">title of the polaroid</param>
        /// <param name="resName">link to image</param>
        /// <param name="date">date of event</param>
        /// <param name="place">place where event takes place</param>
        /// <param name="description">description of the event</param>
        public PoloroidWithText(String title, String resName, string date, String place, String description)
        {
            InitializeComponent();
            setImage(resName);
            setPlace(place);
            setDate(date);
            setDescription(description);
            setTitle(title);
        }
        /// <summary>
        /// set the image of the poloroid with text
        /// </summary>
        /// <param name="resName"></param>
        public void setImage(String resName)
        {
            var src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(Directory.GetCurrentDirectory() + "/Resources/" + resName);
            src.EndInit();

            Image.Source = src;
        }
        /// <summary>
        /// set the place field
        /// </summary>
        /// <param name="place"></param>
        public void setPlace(String place)
        {
            Place.Text = place;
        }
        /// <summary>
        /// set the date field
        /// </summary>
        /// <param name="date"></param>
        public void setDate(string date)
        {
            Date.Text = date;
        }
        /// <summary>
        /// set the description field
        /// </summary>
        /// <param name="desc"></param>
        public void setDescription(String desc)
        {
            Description.Text = desc;
        }
        /// <summary>
        /// set the title field
        /// </summary>
        /// <param name="title"></param>
        public void setTitle(String title)
        {
            Title.Text = title;
        }
        /// <summary>
        /// what happens if the image fails to load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            //TODO
        }
    }

}
