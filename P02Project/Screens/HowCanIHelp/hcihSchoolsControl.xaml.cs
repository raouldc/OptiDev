#region

using System.Windows.Controls;
using System.Windows.Media.Animation;
using P02Project.Utils;

#endregion

namespace P02Project
{
    /// <summary>
    ///     Interaction logic for hcihBeads.xaml
    /// </summary>
    public partial class hcihSchoolsControl : UserControl, Animatiable
    {
        private readonly Storyboard sbIn;

        /// <summary>
        ///     Constructor
        /// </summary>
        public hcihSchoolsControl()
        {
            InitializeComponent();

            sbIn = new Storyboard();
            Util.FadeIn(sbIn, img);
        }

        /// <summary>
        ///     Fade in the Image on the screen
        /// </summary>
        public void AnimateIn()
        {
            sbIn.Begin();
        }

        /// <summary>
        ///     Does nothing
        /// </summary>
        public void AnimateOut()
        {
        }
    }
}