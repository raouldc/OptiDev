using System;
using System.Collections.Generic;
using System.Linq;
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
using P02Project.Resources.xml;
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
