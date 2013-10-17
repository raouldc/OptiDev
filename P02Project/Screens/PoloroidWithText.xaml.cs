using System;
using System.Collections.Generic;
using System.IO;
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

        public PoloroidWithText(String title, String resName, string date, String place, String description)
        {
            InitializeComponent();
            setImage(resName);
            setPlace(place);
            setDate(date);
            setDescription(description);
            setTitle(title);
        }

        public void setImage(String resName)
        {
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(Directory.GetCurrentDirectory() + "/Resources/" + resName);
            src.EndInit();

            Image.Source = src;
        }

        public void setPlace(String place)
        {
            Place.Text = place;
        }

        public void setDate(string date)
        {
            Date.Text = date;
        }

        public void setDescription(String desc)
        {
            Description.Text = desc;
        }

        public void setTitle(String title)
        {
            Title.Text = title;
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }

}
