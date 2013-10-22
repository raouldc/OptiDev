using System.Windows.Controls;
using Microsoft.Maps.MapControl.WPF;

namespace P02Project.Screens
{
    /// <summary>
    /// Interaction logic for FSPage.xaml
    /// </summary>
    public partial class MapControl : UserControl
    {
        public MapControl()
        {
            InitializeComponent();
            myMap.Center = new Location(-40.7, 171.55);
            myMap.ZoomLevel = 7.0;

        }

       

    }
}
