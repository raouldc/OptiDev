#region

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

#endregion

namespace P02Project
{
    /// <summary>
    ///     Interaction logic for TweetListElement.xaml
    /// </summary>
    public partial class TweetListElement : UserControl
    {
        public TweetListElement()
        {
            InitializeComponent();
        }

        public void setTweetText(String txt)
        {
            _tweetTxt.Text = txt;
        }

        public void setTweetImg(BitmapImage img)
        {
            _tweetImg.Source = img;
        }


        public void setBackground(Brush bg)
        {
            _layout.Background = bg;
        }

        public void setMargin(double left, double top, double right, double bottom)
        {
            _layout.Margin = new Thickness(left, top, right, bottom);
        }
    }
}