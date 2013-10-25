#region

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using P02Project.Resources.xml;
using P02Project.Screens.Game;

#endregion

namespace P02Project.Screens.BeadsOfCourage
{
    /// <summary>
    ///     Interaction logic for BeadsOfCourage.xaml
    /// </summary>
    public partial class BeadsOfCourage : UserControl
    {
        /// <summary>
        /// The selected color
        /// </summary>
        private static readonly Brush SELECTED_COLOR = new SolidColorBrush(Util._pageColDict["pbSelected"]);
        /// <summary>
        /// The unselected color
        /// </summary>
        private static readonly Brush UNSELECTED_COLOR = new SolidColorBrush(Util._pageColDict["pbUnSelected"]);
        /// <summary>
        /// The _bead model
        /// </summary>
        private readonly BeadModel _beadModel;
        /// <summary>
        /// Instance of the random class
        /// </summary>
        private readonly Random _r;

        /// <summary>
        /// Initializes a new instance of the <see cref="BeadsOfCourage"/> class.
        /// </summary>
        public BeadsOfCourage()
        {
            InitializeComponent();
            beadPoloroid.IsUnclickable = true;
            //load beads from xml
            String path = Path.Combine(Path.GetFullPath("."), "Utils/xml/BeadsOfCourageSchema/beads.xml");
            _beadModel = XMLUtilities.GetBeadsContentFromFile(path);
            _r = new Random();
            button.Background = SELECTED_COLOR;
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            button.Effect = dShdow;
        }

        /// <summary>
        /// Handles the MouseUp event of the Bead control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void Bead_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //move beads and thread down
            //display enlarged bead and text on the top
            if (sender.GetType() != typeof (Image))
            {
                return;
            }

            Image sder = (Image) sender;


            //Change the bead image
            BitmapImage bmpImage = new BitmapImage();
            bmpImage.BeginInit();
            bmpImage.UriSource =
                new Uri("pack://application:,,/Resources/images/beads/" + sder.Name.Replace("_", " ") + ".png");
            bmpImage.EndInit();
            beadImageView.Source = bmpImage;

            foreach (var temp in _beadModel.BeadsList)
            {
                if (!temp.id.ToLower().Equals(sder.Name.ToLower().Replace("_", " "))) continue;
                //set the textbox text
                beadDetailTextBlock.Text = temp.Value.Trim();
                beadTitle.Text = temp.id;
                break;
            }
            //set the poloroid image to a random image from the xml
            beadPoloroid.setImage(_beadModel.Images[_r.Next(_beadModel.Images.Length)].Value);
            ResetTimer();
        }

        private void ResetTimer()
        {
            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException)
            {
            }
        }

        /// <summary>
        /// Handles the event of the button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            //create a quiz window and display it
            Quiz q = new Quiz();
            q.Topmost = true;
            q.ShowDialog();
            ResetTimer();
        }
    }
}