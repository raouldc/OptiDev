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
using P02Project.Utils;

namespace P02Project
{
    /// <summary>
    /// Interaction logic for hcihHomeControl.xaml
    /// </summary>
    public partial class hcihHomeControl : UserControl, Animatiable
    {
        private TopLevelPage topLevelPage;
        private List<Animatiable> components;

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

            schools.setImage("images\\HowCanIHelp\\schools.png");
            schools.setCaption("Schools");
            schools.setColour(colour);

            volunteer.setImage("howCanIHelp.png");
            volunteer.setCaption("Volunteer");
            volunteer.setColour(colour);

            components = new List<Animatiable>();
            components.Add(donate);
            components.Add(beadsOfCourage);
            components.Add(schools);
            components.Add(volunteer);
        }



        /// <summary>
        /// this method called when the "Donate" polaroid has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void donate_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // create the donation content and set the subtitle of the view
            UserControl don = new hcihDonateControl();
            topLevelPage.setContent(don);
            topLevelPage.setSubtitle("Donate");
            (don as Animatiable).AnimateIn();

        }

        private void beadsOfCourage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            topLevelPage.setContent(new hcihBeads());
            topLevelPage.setSubtitle("Beads of Courage");
        }

        private void schools_MouseUp(object sender, MouseButtonEventArgs e)
        {
            topLevelPage.setContent(new hcihSchoolsControl());
            topLevelPage.setSubtitle("Schools");
        }

        private void volunteer_MouseUp(object sender, MouseButtonEventArgs e)
        {
            topLevelPage.setContent(new hcihVolunteerControl());
            topLevelPage.setSubtitle("Volunteer");
        }

        public void AnimateIn()
        {
            foreach (Animatiable a in components)
            {
                a.AnimateIn();
            }
        }

        public void AnimateOut()
        {
        }
    }
}