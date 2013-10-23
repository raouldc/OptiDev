using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using P02Project.Utils;

namespace P02Project
{
	/// <summary>
	/// Interaction logic for hcihBeads.xaml
	/// </summary>
    public partial class hcihCampControl : UserControl, Animatiable
	{
        Storyboard sbIn;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public hcihCampControl()
		{
			this.InitializeComponent();

            sbIn = new Storyboard();

            foreach (FrameworkElement fElement in LayoutRoot.Children)
            {
                Util.FadeIn(sbIn, fElement);
            }

            Util.SetupQR(QRText, "http://childcancer.org.nz/How-you-can-help/Our-campaigns.aspx");
		}

        /// <summary>
        /// begin the animation
        /// </summary>
        void Animatiable.AnimateIn()
        {
            sbIn.Begin();
        }

        void Animatiable.AnimateOut()
        {
        }
    }
}