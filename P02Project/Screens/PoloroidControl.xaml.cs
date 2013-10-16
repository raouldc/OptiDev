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
        /// <summary>
        /// Constructor
        /// </summary>
		public PoloroidControl()
		{
			this.InitializeComponent();
		}



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="resName"></param>
        /// <param name="caption"></param>
        /// <param name="colour"></param>
        public PoloroidControl(String resName, String caption, Color colour)
        {
            this.InitializeComponent();
            // set image, text and the color of the polaroid
            setImage(resName);
            setCaption(caption);
            setColour(colour);
            UpdateLayout();
        }



        /// <summary>
        /// setter method for the polaroid image
        /// </summary>
        /// <param name="resName"></param>
        public void setImage(String resName)
        {
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("pack://application:,,/Resources/" + resName);
            src.EndInit();

            Image.Source = src;
        }



        /// <summary>
        /// setter method for the polaroid text
        /// </summary>
        /// <param name="caption"></param>
        public void setCaption(String caption)
        {
            Caption.Text = caption;
        }



        /// <summary>
        /// getter method for the polaroid text
        /// </summary>
        public String text
        {
            get
            {
                return Caption.Text;
            }
        }



        /// <summary>
        /// setter method for the polaroid color
        /// </summary>
        /// <param name="colour"></param>
        public void setColour(Color colour)
        {
            Caption.Background = new SolidColorBrush(colour);
        }



        /// <summary>
        /// getter method for the polaroid color
        /// </summary>
        public Color colour{
            get {
                return (Caption.Background as SolidColorBrush).Color;
            }
        }



        /// <summary>
        /// make the animation when touched
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Poloroid_TouchDown(object sender, TouchEventArgs e)
        {
            hideShadow();
        }



        /// <summary>
        /// make the animation when mouse pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Poloroid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            hideShadow();
        }


        
        /// <summary>
        /// a helper method for animate the shadow when the polaroid is clicked or touched
        /// </summary>
        private void hideShadow()
        {
            ((DropShadowEffect)Canvas.Effect).Opacity = 0;
        }



        /// <summary>
        /// a helper method for animate the shadow when the polaroid is clicked or touched
        /// </summary>
        private void showShadow()
        {
            ((DropShadowEffect)Canvas.Effect).Opacity = 1;
        }



        /// <summary>
        /// make the animation when lift up the mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Poloroid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            showShadow();
        }


        /// <summary>
        /// make the animation when stop touching
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Poloroid_TouchUp(object sender, TouchEventArgs e)
        {
            showShadow();
        }

        public void setGlow() {
            DropShadowEffect dShad = new DropShadowEffect();
            dShad.Color = (Color)ColorConverter.ConvertFromString("#fff2df11");
            dShad.BlurRadius = 10;
            Canvas.Effect = dShad;
        }

        public void removeGlow() {
            Canvas.Effect = new DropShadowEffect();
        }
	}

}