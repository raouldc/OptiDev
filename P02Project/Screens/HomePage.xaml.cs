﻿using System;
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
using P02Project.Utils;

namespace P02Project
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Screen, Animatiable
    {
        private List<Animatiable> components;

        public HomePage(TopWindow parentWindow) : base(parentWindow)
        {
            this.InitializeComponent();
        }


        /// <summary>
        ///
        /// this method called when the surface app has just been created.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // set image and color for About polaroid
            about.setImage("abt.png");
            about.setCaption("About");
            about.setColour(Util._pageColDict["About"]);

            // set image and color for Family Support polaroid
            familySupport.setImage("FS.png");
            familySupport.setCaption("Family Support");
            familySupport.setColour(Util._pageColDict["Family Support"]);

            // set image and color for How Can I Help polaroid
            howCanIHelp.setImage("howCanIHelp.png");
            howCanIHelp.setCaption("How Can I Help?");
            howCanIHelp.setColour(Util._pageColDict["How Can I Help?"]);

            // set image and color for News polaroid
            news.setImage("news.png");
            news.setCaption("News");
            news.setColour(Util._pageColDict["News"]);

            // set image and color for Events polaroid
            events.setImage("events.png");
            events.setCaption("Events");
            events.setColour(Util._pageColDict["Events"]);

            // set image and color for Contact Us polaroid
            contactUs.setImage("contact.png");
            contactUs.setCaption("Contact Us");
            contactUs.setColour(Util._pageColDict["Contact Us"]);

            // set image and color for Play Beads polaroid
            playBeads.setImage("beads.png");
            playBeads.setCaption("Play Beads");
            playBeads.setColour(Util._pageColDict["Play Beads"]);

            components = new List<Animatiable>();
            components.Add(about);
            components.Add(familySupport);
            components.Add(howCanIHelp);
            components.Add(news);
            components.Add(events);
            components.Add(contactUs);
            components.Add(playBeads);
        }

        public void AnimateOut()
        {
            foreach (Animatiable a in components)
            {
                a.AnimateIn();
            }
        }

        public void AnimateIn()
        {
        }

        /// <summary>
        /// This method get called when the About has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void about_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // create a new subscreen and push it into the stack of subscreens
            TopLevelPage nextScreen = new TopLevelPage(ParentWindow, "About");
            ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("About"), about.colour, new FunkyGrid("xml/About.xml"), "");
        }



        /// <summary>
        /// This method get called when the News has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void news_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // create a new subscreen and push it into the stack of subscreens
            TopLevelPage nextScreen = new TopLevelPage(ParentWindow, "News");
            ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("News"), news.colour, new UserControl(), "");
        }



        /// <summary>
        /// This method get called when the Events has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void events_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // create a new subscreen and push it into the stack of subscreens
            TopLevelPage nextScreen = new TopLevelPage(ParentWindow, "Events");
            ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("Events"), events.colour, new UserControl(), "");
        }



        /// <summary>
        /// This method get called when the Contact Us has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contactUs_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // create a new subscreen and push it into the stack of subscreens
            TopLevelPage nextScreen = new TopLevelPage(ParentWindow, "Contact Us");
            ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("Contact Us"), contactUs.colour, new ContactUs(), "");
        }



        /// <summary>
        /// This method get called when the How Can I Help has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void howCanIHelp_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Do out animation
            AnimateOut();

            // create a new subscreen and push it into the stack of subscreens
            TopLevelPage nextScreen = new TopLevelPage(ParentWindow, "How Can I Help?");
            hcihHomeControl hcih = new hcihHomeControl(nextScreen);
            ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("How Can I Help?"), howCanIHelp.colour, hcih, "");
            hcih.AnimateIn();
        }



        /// <summary>
        /// This method get called when the Family Support has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void familySupport_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // create a new subscreen and push it into the stack of subscreens
            TopLevelPage nextScreen = new TopLevelPage(ParentWindow, "Family Support");
            ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("Family Support"), familySupport.colour, new UserControl(), "");
        }



        /// <summary>
        /// This method get called when the Play Beads has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playBeads_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // create a new subscreen and push it into the stack of subscreens
            TopLevelPage nextScreen = new TopLevelPage(ParentWindow, "Play Beads");
            ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("Play Beads"), playBeads.colour, new UserControl(), "");

        }

        
    }
}