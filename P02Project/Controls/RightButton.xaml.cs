#region

using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

#endregion

namespace P02Project
{
    /// <summary>
    ///     This class is the UserControl for the buttons on the Right
    ///     The buttons can have a custom colour and caption
    /// </summary>
    public partial class RightButton : UserControl
    {
        /// <summary>
        ///     constructor
        /// </summary>
        public RightButton()
        {
            InitializeComponent();
            Text.FontFamily = Util.buttonTextFont;
            Text.Foreground = new SolidColorBrush(Util.buttonTextColor);
        }


        /// <summary>
        ///     Gets or Sets the Caption of the buttons
        ///     The caption is the text on the button
        /// </summary>
        public string Caption
        {
            set { Text.Text = value; }
            get { return Text.Text; }
        }


        /// <summary>
        ///     Gets or Sets the colour of the button
        /// </summary>
        public Color Colour
        {
            set { Canvas.Fill = new SolidColorBrush(value); }
            get { return ((SolidColorBrush) Canvas.Fill).Color; }
        }


        /// <summary>
        ///     Sets the opacity of the shadow to 100%
        ///     Makes the shadow visible
        /// </summary>
        private void showShadow()
        {
            ((DropShadowEffect) Canvas.Effect).Opacity = 1;
        }


        /// <summary>
        ///     Sets the opacity of the shadow to 0%
        ///     Makes the shadow invisible
        /// </summary>
        private void hideShadow()
        {
            ((DropShadowEffect) Canvas.Effect).Opacity = 0;
        }


        /// <summary>
        ///     When the mouse is down, the shadow of the button is hidden to make
        ///     it look like the button is moving down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Background_MouseDown(object sender, MouseButtonEventArgs e)
        {
            hideShadow();
        }


        /// <summary>
        ///     When the mouse if up, the shadow of the button is made visible to make
        ///     the button look like it's moving up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Background_MouseUp(object sender, MouseButtonEventArgs e)
        {
            showShadow();
        }
    }
}