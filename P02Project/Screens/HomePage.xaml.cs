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
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;
using System.Windows.Media.Animation;
using P02Project.Screens;

namespace P02Project
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Screen
    {

        public HomePage(SurfaceWindow1 parentWindow) : base(parentWindow)
        {
            this.InitializeComponent();
        }


        //// this method called when the surface app has just been created.
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            about.setImage("abt.png");
            about.setCaption("About");
            about.setColour(Util._pageColDict["About"]);

            familySupport.setImage("FS.png");
            familySupport.setCaption("Family Support");
            familySupport.setColour(Util._pageColDict["Family Support"]);

            howCanIHelp.setImage("howCanIHelp.png");
            howCanIHelp.setCaption("How Can I Help?");
            howCanIHelp.setColour(Util._pageColDict["How Can I Help?"]);

            news.setImage("news.png");
            news.setCaption("News");
            news.setColour(Util._pageColDict["News"]);

            events.setImage("events.png");
            events.setCaption("Events");
            events.setColour(Util._pageColDict["Events"]);

            contactUs.setImage("contact.png");
            contactUs.setCaption("Contact Us");
            contactUs.setColour(Util._pageColDict["contactUUnSelected"]);

            playBeads.setImage("beads.png");
            playBeads.setCaption("Play Beads");
            playBeads.setColour(Util._pageColDict["Play Beads"]);
        }
       

        private void about_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TopLevelPage nextScreen = new TopLevelPage(ParentWindow, "About");
            ParentWindow.pushScreenOnStack(nextScreen, new String[6] { "Family Support", "How Can I Help?", "News", "Events", "Play Beads", "Contact Us" }, about.colour, new FunkyGrid("xml/About.xml"), "");
        }

        private void news_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TopLevelPage nextScreen = new TopLevelPage(ParentWindow, "News");
            ParentWindow.pushScreenOnStack(nextScreen, new String[6] { "About", "Family Support", "How Can I Help?", "Events", "Play Beads", "Contact Us" }, news.colour, new UserControl(), "");
        }

        private void events_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TopLevelPage nextScreen = new TopLevelPage(ParentWindow, "Events");
            ParentWindow.pushScreenOnStack(nextScreen, new String[6] { "About", "Family Support", "How Can I Help?", "News", "Play Beads", "Contact Us" }, events.colour, new UserControl(), "");
        }

        private void contactUs_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TopLevelPage nextScreen = new TopLevelPage(ParentWindow, "Contact Us");
            ParentWindow.pushScreenOnStack(nextScreen, new String[6] { "About", "Family Support", "How Can I Help?", "News", "Events", "Play Beads" }, contactUs.colour, new ContactUs(), "");
        }

        private void howCanIHelp_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TopLevelPage nextScreen = new TopLevelPage(ParentWindow, "How Can I Help?");
            ParentWindow.pushScreenOnStack(nextScreen, new String[6] { "About", "Family Support", "News", "Events", "Play Beads", "Contact Us" }, howCanIHelp.colour, new hcihHomeControl(nextScreen), "");
        }

        private void familySupport_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TopLevelPage nextScreen = new TopLevelPage(ParentWindow, "Family Support");
            ParentWindow.pushScreenOnStack(nextScreen, new String[6] { "About", "How Can I Help?", "News", "Events", "Play Beads", "Contact Us" }, familySupport.colour, new UserControl(), "");
        }

        private void playBeads_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TopLevelPage nextScreen = new TopLevelPage(ParentWindow, "Play Beads");
            ParentWindow.pushScreenOnStack(nextScreen, new String[6] { "About", "Family Support", "How Can I Help?", "News", "Events", "Contact Us" }, playBeads.colour, new UserControl(), "");

        }

        
    }
}