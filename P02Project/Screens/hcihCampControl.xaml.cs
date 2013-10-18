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

            foreach (FrameworkElement c in LayoutRoot.Children)
            {
                DoubleAnimation da = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromMilliseconds(200)));

                sbIn.Children.Add(da);

                Storyboard.SetTarget(da, c);
                Storyboard.SetTargetProperty(da, new PropertyPath(FrameworkElement.OpacityProperty));
            }
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