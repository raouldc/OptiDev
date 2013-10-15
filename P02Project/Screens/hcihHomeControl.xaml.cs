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
using P02Project.Screens;

namespace P02Project
{
    /// <summary>
    /// Interaction logic for hcihHomeControl.xaml
    /// </summary>
    public partial class hcihHomeControl : UserControl
    {
        private TopLevelPage topLevelPage;

        public hcihHomeControl(TopLevelPage tlpage)
        {
            this.InitializeComponent();

            topLevelPage = tlpage;
            Color colour = Util._pageColDict["How Can I Help?"];

            donate.setImage("donate.png");
            donate.setCaption("Donate");
            donate.setColour(colour);

            beadsOfCourage.setImage("images\\HowCanIHelp\\beads.png");
            beadsOfCourage.setCaption("Beads of Courage");
            beadsOfCourage.setColour(colour);
        }



        /// <summary>
        /// this method called when the "Donate" polaroid has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void donate_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // create the donation content and set the subtitle of the view
            topLevelPage.setContent(new hcihDonateControl());
            topLevelPage.setSubtitle("Donate");

        }

        private void beadsOfCourage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            topLevelPage.setContent(new hcihBeads());
            topLevelPage.setSubtitle("Beads of Courage");
        }
    }
}