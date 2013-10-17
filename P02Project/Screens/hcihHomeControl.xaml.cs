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

            campaings.setImage("images\\HowCanIHelp\\camp.png");
            campaings.setCaption("Campaings");
            campaings.setColour(colour);

            shop.setImage("images\\HowCanIhelp\\bb.png");
            shop.setCaption("Online Shop");
            shop.setColour(colour);

            fundraise.setImage("images\\HowCanIHelp\\fundraise.png");
            fundraise.setCaption("Fundraise");
            fundraise.setColour(colour);

            gift.setImage("images\\HowCanIHelp\\gift.png");
            gift.setCaption("Make a Gift");
            gift.setColour(colour);

            components = new List<Animatiable>();
            components.Add(donate);
            components.Add(beadsOfCourage);
            components.Add(schools);
            components.Add(volunteer);
            components.Add(campaings);
            components.Add(shop);
            components.Add(fundraise);
            components.Add(gift);
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

        private void campaings_MouseUp(object sender, MouseButtonEventArgs e)
        {
            hcihCampControl hcih = new hcihCampControl();
            topLevelPage.setContent(hcih);
            topLevelPage.setSubtitle("Campaings");
            (hcih as Animatiable).AnimateIn();
        }

        private void shop_MouseUp(object sender, MouseButtonEventArgs e)
        {
            hcihShopControl hcih = new hcihShopControl();
            topLevelPage.setContent(hcih);
            topLevelPage.setSubtitle("Online Shop");
            (hcih as Animatiable).AnimateIn();
        }

        private void fundraise_MouseUp(object sender, MouseButtonEventArgs e)
        {
            hcihFundraiseControl hcih = new hcihFundraiseControl();
            topLevelPage.setContent(hcih);
            topLevelPage.setSubtitle("Fundraise");
            (hcih as Animatiable).AnimateIn();
        }

        private void gift_MouseUp(object sender, MouseButtonEventArgs e)
        {
            hcihGiftControl hcih = new hcihGiftControl();
            topLevelPage.setContent(hcih);
            topLevelPage.setSubtitle("Make a Gift");
            (hcih as Animatiable).AnimateIn();
        }
    }
}