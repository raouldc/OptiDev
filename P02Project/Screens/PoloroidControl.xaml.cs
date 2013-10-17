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
using System.Windows.Media.Animation;
using P02Project.Utils;

namespace P02Project
{
	/// <summary>
	/// Interaction logic for PoloroidControl.xaml
	/// </summary>
	public partial class PoloroidControl : UserControl, Animatiable
	{
        protected DoubleAnimation dblAnimationIn = new DoubleAnimation();
        protected DoubleAnimation dblAnimationOut = new DoubleAnimation();

        protected Storyboard sbIn = new Storyboard();
        protected Storyboard sbOut = new Storyboard();

        /// <summary>
        /// Constructor
        /// </summary>
		public PoloroidControl()
		{
			this.InitializeComponent();

            //Inward Animations
            dblAnimationIn.From = 0.0;
            dblAnimationIn.To = 1.0;
            dblAnimationIn.Duration = new Duration(TimeSpan.FromMilliseconds(200));

            sbIn.Children.Add(dblAnimationIn);

            Storyboard.SetTargetName(dblAnimationIn, this.Name);
            Storyboard.SetTargetProperty(dblAnimationIn, new PropertyPath(UserControl.OpacityProperty));

            //Outward Animations
            dblAnimationOut.From = 1.0;
            dblAnimationOut.To = 0.0;
            dblAnimationOut.Duration = new Duration(TimeSpan.FromMilliseconds(200));

            sbOut.Children.Add(dblAnimationOut);

            Storyboard.SetTargetName(dblAnimationOut, this.Name);
            Storyboard.SetTargetProperty(dblAnimationOut, new PropertyPath(UserControl.OpacityProperty));
		}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="resName">The name of the image in the resources folder</param>
        /// <param name="caption">The caption to go on the polaroid</param>
        /// <param name="colour">The colour of the backgroud of the text</param>
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
            removeTouch();

            setShadow(10,0.7,(Color)ColorConverter.ConvertFromString("#fff2df11"));
        }

        public void removeGlow() {
            removeTouch();
            
            setShadow(10,0.365,(Color)ColorConverter.ConvertFromString("#ff000000"));
        }
        
        public void AnimateIn()
        {
            sbIn.Begin(this);
        }

        public void AnimateOut()
        {
            sbOut.Begin(this);
        }

        public void removeTouch()
        {
            this.RemoveHandler(UIElement.TouchUpEvent, new EventHandler<TouchEventArgs>(Poloroid_TouchUp));
            this.RemoveHandler(UIElement.MouseUpEvent, new MouseButtonEventHandler(Poloroid_MouseUp));
            this.RemoveHandler(UIElement.TouchDownEvent, new EventHandler<TouchEventArgs>(Poloroid_TouchDown));
            this.RemoveHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(Poloroid_MouseDown));
        }

        public void setShadow(double blur, double opacity, Color col) {
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = blur;
            dShdow.Opacity = opacity;
            dShdow.Color = col;
            Canvas.Effect = dShdow;
        }

        public void removeBorder() {
            Canvas.Stroke = null;
        }
    }

}