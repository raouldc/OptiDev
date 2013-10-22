using System;
using System.Collections.Generic;
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

namespace P02Project
{
	/// <summary>
	/// Interaction logic for TweetListElement.xaml
	/// </summary>
	public partial class TweetListElement : UserControl
	{
		public TweetListElement()
		{
			this.InitializeComponent();
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