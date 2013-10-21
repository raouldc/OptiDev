using System.Windows.Controls;
using System.Windows.Media.Animation;
using P02Project.Utils;

namespace P02Project
{
	/// <summary>
	/// Interaction logic for hcihBeads.xaml
	/// </summary>
    public partial class hcihSchoolsControl : UserControl, Animatiable
	{
        private Storyboard sbIn;
        /// <summary>
        /// Constructor
        /// </summary>
        public hcihSchoolsControl()
		{
			this.InitializeComponent();

            sbIn = new Storyboard();
            Util.FadeIn(sbIn, img);
		}


        public void AnimateIn()
        {
            sbIn.Begin();
        }

        public void AnimateOut()
        {
            
        }
    }
}