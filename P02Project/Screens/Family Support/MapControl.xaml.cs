using System.Windows.Controls;
using Microsoft.Maps.MapControl.WPF;
using System.Windows.Media.Animation;
using P02Project.Utils;

namespace P02Project.Screens
{
    /// <summary>
    /// Interaction logic for FSPage.xaml
    /// </summary>
    public partial class MapControl : UserControl, Animatiable
    {
        private Storyboard sbIn;

        public MapControl()
        {
            InitializeComponent();
            myMap.Center = new Location(-40.7, 171.55);
            myMap.ZoomLevel = 7.0;

            sbIn = new Storyboard();
            Util.FadeIn(sbIn, myMap);
        }

        public void AnimateIn()
        {
            sbIn.Begin(this);
        }

        public void AnimateOut()
        {
            
        }
    }
}
