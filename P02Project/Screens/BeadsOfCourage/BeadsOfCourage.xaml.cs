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
using System.Windows.Media.Animation;
using P02Project.Resources.xml;

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
            beadPoloroid.IsUnclickable = true;
            String path = System.IO.Path.Combine(System.IO.Path.GetFullPath("."), "Utils/xml/BeadsOfCourageSchema/beads.xml");
            _beadModel = XMLUtilities.GetBeadsContentFromFile(path);
            r =new Random();
        }

        private void Bead_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // TODO: Add event handler implementation here.
            //move beads and thread down
            //display enlarged bead and text on the topp
            if (sender.GetType() != typeof(Image))
            {
                return;
            }

            Image sder = (Image)sender;


            //Change the bead image
            BitmapImage bmpImage = new BitmapImage();
            bmpImage.BeginInit();
            bmpImage.UriSource = new Uri("pack://application:,,/Resources/images/beads/" + sder.Name.Replace("_", " ") + ".png");
            bmpImage.EndInit();
            beadImageView.Source = bmpImage;

            foreach (var temp in _beadModel.BeadsList)
            {
                if (!temp.id.ToLower().Equals(sder.Name.ToLower().Replace("_", " "))) continue;
                beadDetailTextBlock.Text = temp.Value.Trim();
                beadTitle.Text = temp.id;
                break;
            }

            //beadPoloroid.setImage(_beadModel.Images);
            beadPoloroid.setImage(_beadModel.Images[r.Next(_beadModel.Images.Length)].Value);

        }

        private BeadModel _beadModel;
        private Random r;
    }
}
