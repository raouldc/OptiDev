using System.Windows.Media.Effects;
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
	/// Interaction logic for PoloroidControl.xaml
	/// </summary>
	public partial class PoloroidControl : UserControl
	{
		public PoloroidControl()
		{
			this.InitializeComponent();
		}

        public PoloroidControl(String resName, String caption, Color colour)
        {
            this.InitializeComponent();
            setImage(resName);
            setCaption(caption);
            setColour(colour);
            UpdateLayout();
        }

        public void setImage(String resName)
        {
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("pack://application:,,/Resources/" + resName);
            src.EndInit();

            Image.Source = src;
        }

        public void setCaption(String caption)
        {
            Caption.Text = caption;
        }

        public void setColour(Color colour)
        {
            Caption.Background = new SolidColorBrush(colour);
        }

        private void Poloroid_TouchDown(object sender, TouchEventArgs e)
        {
            hideShadow();
        }

        private void Poloroid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            hideShadow();
        }

        private void hideShadow()
        {
            ((DropShadowEffect)Canvas.Effect).Opacity = 0;
        }

        private void showShadow()
        {
            ((DropShadowEffect)Canvas.Effect).Opacity = 1;
        }

        private void Poloroid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            showShadow();
        }

        private void Poloroid_TouchUp(object sender, TouchEventArgs e)
        {
            showShadow();
        }
	}

}