#region

using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using P02Project.Screens;
using P02Project.Utils;

#endregion

namespace P02Project
{
    /// <summary>
    ///     Interaction logic for hcihHomeControl.xaml
    /// </summary>
    public partial class hcihHomeControl : UserControl, Animatiable
    {
        private readonly List<Animatiable> components;
        private readonly TopLevelPage topLevelPage;

        /// <summary>
        ///     Home page for the How Can I Help Section
        /// </summary>
        /// <param name="tlpage">Access Object to the Home page</param>
        public hcihHomeControl(TopLevelPage tlpage)
        {
            InitializeComponent();

            topLevelPage = tlpage;
            Color colour = Util._pageColDict["How Can I Help?"];

            //Set the images for all the poloroids
            donate.setImage("images\\HowCanIHelp\\donate.png");
            donate.setCaption("Donate");
            donate.setColour(colour);

            beadsOfCourage.setImage("images\\HowCanIHelp\\beads.png");
            beadsOfCourage.setCaption("Beads of Courage");
            beadsOfCourage.setColour(colour);

            schools.setImage("images\\HowCanIHelp\\schools.png");
            schools.setCaption("Schools");
            schools.setColour(colour);

            volunteer.setImage("images/Home/howCanIHelp.png");
            volunteer.setCaption("Volunteer");
            volunteer.setColour(colour);

            campaigns.setImage("images\\HowCanIHelp\\camp.png");
            campaigns.setCaption("Campaigns");
            campaigns.setColour(colour);

            shop.setImage("images\\HowCanIhelp\\bb.png");
            shop.setCaption("Online Shop");
            shop.setColour(colour);

            fundraise.setImage("images\\HowCanIHelp\\fundraise.png");
            fundraise.setCaption("Fundraise");
            fundraise.setColour(colour);

            gift.setImage("images\\HowCanIHelp\\gift.png");
            gift.setCaption("Make a Gift");
            gift.setColour(colour);

            //This maintains a list of all the poloroids that need to be animated on screen change
            components = new List<Animatiable>();
            components.Add(donate);
            components.Add(beadsOfCourage);
            components.Add(schools);
            components.Add(volunteer);
            components.Add(campaigns);
            components.Add(shop);
            components.Add(fundraise);
            components.Add(gift);
        }

        /// <summary>
        ///     Animate all the poloroids
        /// </summary>
        public void AnimateIn()
        {
            foreach (Animatiable a in components)
            {
                a.AnimateIn();
            }
        }

        /// <summary>
        ///     Does nothing
        /// </summary>
        public void AnimateOut()
        {
        }


        /// <summary>
        ///     this method called when the "Donate" polaroid has been clicked
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

        /// <summary>
        ///     Beads of Courage poloroid is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void beadsOfCourage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            hcihBeads hcih = new hcihBeads();
            topLevelPage.setContent(hcih);
            topLevelPage.setSubtitle("Beads of Courage");
            (hcih as Animatiable).AnimateIn();
        }

        /// <summary>
        ///     Schools poloroid is Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void schools_MouseUp(object sender, MouseButtonEventArgs e)
        {
            hcihSchoolsControl hcih = new hcihSchoolsControl();
            topLevelPage.setContent(hcih);
            topLevelPage.setSubtitle("Schools");
            (hcih as Animatiable).AnimateIn();
        }

        /// <summary>
        ///     Volunteer poloroid is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void volunteer_MouseUp(object sender, MouseButtonEventArgs e)
        {
            hcihVolunteerControl hcih = new hcihVolunteerControl();
            topLevelPage.setContent(hcih);
            topLevelPage.setSubtitle("Volunteer");
            (hcih as Animatiable).AnimateIn();
        }

        /// <summary>
        ///     Campigns Poloroid is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void campaigns_MouseUp(object sender, MouseButtonEventArgs e)
        {
            hcihCampControl hcih = new hcihCampControl();
            topLevelPage.setContent(hcih);
            topLevelPage.setSubtitle("Campaigns");
            (hcih as Animatiable).AnimateIn();
        }

        /// <summary>
        ///     Online Shop Poloroid Is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shop_MouseUp(object sender, MouseButtonEventArgs e)
        {
            hcihShopControl hcih = new hcihShopControl();
            topLevelPage.setContent(hcih);
            topLevelPage.setSubtitle("Online Shop");
            (hcih as Animatiable).AnimateIn();
        }

        /// <summary>
        ///     Fundraise poloroid is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fundraise_MouseUp(object sender, MouseButtonEventArgs e)
        {
            hcihFundraiseControl hcih = new hcihFundraiseControl();
            topLevelPage.setContent(hcih);
            topLevelPage.setSubtitle("Fundraise");
            (hcih as Animatiable).AnimateIn();
        }

        /// <summary>
        ///     Make a Gift poloroid is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gift_MouseUp(object sender, MouseButtonEventArgs e)
        {
            hcihGiftControl hcih = new hcihGiftControl();
            topLevelPage.setContent(hcih);
            topLevelPage.setSubtitle("Make a Gift");
            (hcih as Animatiable).AnimateIn();
        }
    }
}