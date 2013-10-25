#region

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using P02Project.Utils;

#endregion

namespace P02Project
{
    /// <summary>
    ///     Interaction logic for PoloroidControl.xaml
    /// </summary>
    public partial class PoloroidControl : UserControl, Animatiable
    {
        protected DoubleAnimation dblAnimationIn = new DoubleAnimation();
        protected DoubleAnimation dblAnimationOut = new DoubleAnimation();

        protected Storyboard sbIn = new Storyboard();
        protected Storyboard sbOut = new Storyboard();

        public PoloroidControl()
        {
            InitializeComponent();


            //Inward Animations
            dblAnimationIn.From = 0.0;
            dblAnimationIn.To = 1.0;
            dblAnimationIn.Duration = new Duration(TimeSpan.FromMilliseconds(Util.animationMilisecs));


            sbIn.Children.Add(dblAnimationIn);


            Caption.FontFamily = Util.buttonTextFont;
            Caption.Foreground = new SolidColorBrush(Util.buttonTextColor);

            Storyboard.SetTargetName(dblAnimationIn, Name);
            Storyboard.SetTargetProperty(dblAnimationIn, new PropertyPath(OpacityProperty));

            //Outward Animations
            dblAnimationOut.From = 1.0;
            dblAnimationOut.To = 0.0;
            dblAnimationOut.Duration = new Duration(TimeSpan.FromMilliseconds(Util.animationMilisecs));

            sbOut.Children.Add(dblAnimationOut);

            Storyboard.SetTargetName(dblAnimationOut, Name);
            Storyboard.SetTargetProperty(dblAnimationOut, new PropertyPath(OpacityProperty));
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="resName">The name of the image in the resources folder</param>
        /// <param name="caption">The caption to go on the polaroid</param>
        /// <param name="colour">The colour of the backgroud of the text</param>
        public PoloroidControl(String resName, String caption, Color colour)
        {
            InitializeComponent();
            // set image, text and the color of the polaroid
            setImage(resName);
            setCaption(caption);
            setColour(colour);
            UpdateLayout();

            Caption.FontFamily = Util.buttonTextFont;
            Caption.Foreground = new SolidColorBrush(Util.buttonTextColor);
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <value><fElement>true</fElement> if this instance is unclickable; otherwise, <fElement>false</fElement>.</value>
        public bool IsUnclickable { private get; set; }

        /// <summary>
        ///     getter method for the polaroid text
        /// </summary>
        public String text
        {
            get { return Caption.Text; }
        }

        /// <summary>
        ///     getter method for the polaroid color
        /// </summary>
        public Color colour
        {
            get { return (Caption.Background as SolidColorBrush).Color; }
        }

        public void AnimateIn()
        {
            sbIn.Begin(this);
        }

        public void AnimateOut()
        {
            sbOut.Begin(this);
        }


        /// <summary>
        ///     setter method for the polaroid image
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
        ///     setter method for the polaroid text
        /// </summary>
        /// <param name="caption"></param>
        public void setCaption(String caption)
        {
            Caption.Text = caption;
        }


        /// <summary>
        ///     setter method for the polaroid color
        /// </summary>
        /// <param name="colour"></param>
        public void setColour(Color colour)
        {
            Caption.Background = new SolidColorBrush(colour);
        }


        /// <summary>
        ///     make the animation when touched
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Poloroid_TouchDown(object sender, TouchEventArgs e)
        {
            hideShadow();
        }


        /// <summary>
        ///     make the animation when mouse pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Poloroid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            hideShadow();
        }


        /// <summary>
        ///     a helper method for animate the shadow when the polaroid is clicked or touched
        /// </summary>
        private void hideShadow()
        {
            if (!IsUnclickable)
            {
                ((DropShadowEffect) Canvas.Effect).Opacity = 0;
            }
        }


        /// <summary>
        ///     a helper method for animate the shadow when the polaroid is clicked or touched
        /// </summary>
        private void showShadow()
        {
            if (!IsUnclickable)
            {
                ((
                    DropShadowEffect) Canvas.Effect).Opacity = 1;
            }
        }


        /// <summary>
        ///     make the animation when lift up the mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Poloroid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            showShadow();

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
        ///     make the animation when stop touching
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Poloroid_TouchUp(object sender, TouchEventArgs e)
        {
            showShadow();

            ResetTimer();
        }

        public void setGlow()
        {
            removeTouch();

            setShadow(10, 0.7, (Color) ColorConverter.ConvertFromString("#fff2df11"));
        }

        public void removeGlow()
        {
            removeTouch();

            setShadow(10, 0.365, (Color) ColorConverter.ConvertFromString("#ff000000"));
        }

        public void removeTouch()
        {
            RemoveHandler(TouchUpEvent, new EventHandler<TouchEventArgs>(Poloroid_TouchUp));
            RemoveHandler(MouseUpEvent, new MouseButtonEventHandler(Poloroid_MouseUp));
            RemoveHandler(TouchDownEvent, new EventHandler<TouchEventArgs>(Poloroid_TouchDown));
            RemoveHandler(MouseDownEvent, new MouseButtonEventHandler(Poloroid_MouseDown));
        }

        public void setShadow(double blur, double opacity, Color col)
        {
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = blur;
            dShdow.Opacity = opacity;
            dShdow.Color = col;
            Canvas.Effect = dShdow;
        }

        public void removeBorder()
        {
            Canvas.Stroke = null;
        }
    }
}