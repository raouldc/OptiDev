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
using System.Windows.Media.Effects;
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


        void Animatiable.AnimateIn()
        {
            sbIn.Begin();
        }

        void Animatiable.AnimateOut()
        {
        }
    }
}