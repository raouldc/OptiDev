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
		public RightButton()
		{
			this.InitializeComponent();
		}

        public string Caption
        {
            set { this.Text.Text = value; }
            get { return this.Text.Text; }
        }

        public Color Colour
        {
            set { this.Canvas.Fill = new SolidColorBrush(value); }
            get { return ((SolidColorBrush)this.Canvas.Fill).Color; }
        }

        private void showShadow()
        {
            ((DropShadowEffect)Canvas.Effect).Opacity = 1;
        }

        private void hideShadow()
        {
            ((DropShadowEffect)Canvas.Effect).Opacity = 0;
        }

        private void Background_MouseDown(object sender, MouseButtonEventArgs e)
        {
            hideShadow();
        }

        private void Background_MouseUp(object sender, MouseButtonEventArgs e)
        {
            showShadow();
        }

	}
}