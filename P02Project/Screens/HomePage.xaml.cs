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
using P02Project.Utils;
using System.Windows.Threading;

namespace P02Project
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Screen, Animatiable
    {
        private List<Animatiable> components;
        DispatcherTimer dt;

        Storyboard sbOut;

        public HomePage(TopWindow parentWindow) : base(parentWindow)
        {
            this.InitializeComponent();

            //bla.Visibility = System.Windows.Visibility.Visible;
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

            TwitterBlock tb = new TwitterBlock();
            tb.Foreground = new SolidColorBrush(Colors.Black);
            
            Thickness t = tb.Margin;
            t.Bottom = 30;
            t.Right = 30;
            tb.Margin = t;
            
            tb.Height = 80;
            tb.Width = 700;

            tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            tb.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            
            poGrid.Children.Add(tb);

            dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 200);
            sbOut = new Storyboard();

            foreach (UserControl uc in components)
            {
                ThicknessAnimation panRight = new ThicknessAnimation();
                panRight.From = uc.Margin;
                panRight.To = new Thickness(1920, uc.Margin.Top, 0, uc.Margin.Bottom);
                panRight.Duration = new Duration(TimeSpan.FromMilliseconds(300));

                sbOut.Children.Add(panRight);

                Storyboard.SetTarget(panRight, uc);
                Storyboard.SetTargetProperty(panRight, new PropertyPath(UserControl.MarginProperty));
            }
        }

        public void AnimateOut()
        {
            sbOut.AutoReverse = false;
            sbOut.Begin(this);
        }

        public void AnimateIn()
        {
            sbOut.AutoReverse = true;
            sbOut.Begin(this, true);
            sbOut.Seek(this, new TimeSpan(0, 0, 0), TimeSeekOrigin.Duration);
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

            dt.Tick += new EventHandler(pushHCIH);
            dt.Start();
        }

        private void pushHCIH(object sender, EventArgs e)
        {
            // create a new subscreen and push it into the stack of subscreens
            TopLevelPage nextScreen = new TopLevelPage(ParentWindow, "How Can I Help?");
            hcihHomeControl hcih = new hcihHomeControl(nextScreen);
            ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("How Can I Help?"), howCanIHelp.colour, hcih, "");
            nextScreen.AnimateIn();
            hcih.AnimateIn();

            dt.Stop();
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






        //??????????????????????????????????????????????????????????????????????????????
        //??????????????????????????????????????????????????????????????????????????????
        //??????????????????????????????????????????????????????????????????????????????
        //??????????????????????????????????????????????????????????????????????????????
        //??????????????????????????????????????????????????????????????????????????????
        /// <summary>
        /// This method get called when the Camera button has been clicked
        /// this is just a temporary button. need to replace with a proper one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openWebcam(Object sender, RoutedEventArgs e)
        {
            // create a new subscreen and push it into the stack of subscreens
            TopLevelPage nextScreen = new TopLevelPage(ParentWindow, "Twitter");
            
            
            
            //*********************************************************************\\
            // need to change the Util.getLinks("About") to a correct one \\
            ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("About"), Util._pageColDict["Extra"], new Webcam(), "Support Us On Twitter");
        }
    }
}