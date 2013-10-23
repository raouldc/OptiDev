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

namespace P02Project.Screens.BeadsOfCourage
{
    /// <summary>
    /// Interaction logic for BeadsOfCourage.xaml
    /// </summary>
    public partial class BeadsOfCourage : UserControl
    {
        public BeadsOfCourage()
        {
            InitializeComponent();
            beadList =new List<Bead>();
            beadList.Add(new Bead("Brown","Loss of hair"));
            beadList.Add(new Bead("Green", "Loss of hair"));
            beadList.Add(new Bead("Blue", "Loss of hair"));
            beadList.Add(new Bead("Purple", "Loss of hair"));
            beadList.Add(new Bead("Grey", "Loss of hair"));
        }

        private void Bead_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            int y = 5;
            //move beads and thread down
            //enlarge clicked bead and move to the top
            if (sender.GetType() != typeof(Image))
            {
                return;
            }

            Image sder = (Image) sender;
            sder.RenderTransform = new RotateTransform(0);
            //sder.Visibility = Visibility.Collapsed;
            //display info about the bead
            //foreach (Image child in threadedBeadGrid.Children)
            //{
            //    if (child.Equals(sder))
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        child.Height = child.Height*0.2;
            //        child.Width = child.Width*0.2;
            //    }
            //}
        }

        private List<Bead> beadList;

        private class Bead
        {
            String text { get; set; }
            String name { get; set; }

            public Bead(String name, String text)
            {
                this.text = text;
                this.name = name;
            }
        }
    }
}
