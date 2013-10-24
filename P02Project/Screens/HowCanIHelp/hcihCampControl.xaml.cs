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

            // Fade in every element on the screen
            foreach (FrameworkElement fElement in LayoutRoot.Children)
            {
                Util.FadeIn(sbIn, fElement);
            }

            Util.SetupQR(QRText, "Find out more about our campaigns at http://tinyurl.com/lfxloyz");
		}

        /// <summary>
        /// begin the animation
        /// </summary>
        void Animatiable.AnimateIn()
        {
            sbIn.Begin();
        }

        /// <summary>
        /// Does nothing
        /// </summary>
        void Animatiable.AnimateOut()
        {
        }
    }
}