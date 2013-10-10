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
using System.Windows.Media.Effects;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P02Project
{
	/// <summary>
	/// Interaction logic for RightButton.xaml
	/// </summary>
	public partial class RightButton : UserControl
	{


        /// <summary>
        /// constructor
        /// </summary>
		public RightButton()
		{
			this.InitializeComponent();
		}



        /// <summary>
        /// get the text of the button
        /// </summary>
        public string Caption
        {
            set { this.Text.Text = value; }
            get { return this.Text.Text; }
        }



        /// <summary>
        /// get the color of the button
        /// </summary>
        public Color Colour
        {
            set { this.Canvas.Fill = new SolidColorBrush(value); }
            get { return ((SolidColorBrush)this.Canvas.Fill).Color; }
        }



        /// <summary>
        /// make the shadow on the button
        /// </summary>
        private void showShadow()
        {
            ((DropShadowEffect)Canvas.Effect).Opacity = 1;
        }



        /// <summary>
        /// hide shadow
        /// </summary>
        private void hideShadow()
        {
            ((DropShadowEffect)Canvas.Effect).Opacity = 0;
        }



        /// <summary>
        /// change the background of the buttn when the mouse pressed down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Background_MouseDown(object sender, MouseButtonEventArgs e)
        {
            hideShadow();
        }



        /// <summary>
        /// /// change the background of the buttn when the mouse pressed released
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Background_MouseUp(object sender, MouseButtonEventArgs e)
        {
            showShadow();
        }

	}
}