﻿#region

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Threading;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Surface.Presentation.Controls;
using P02Project.Utils;

#endregion

namespace P02Project
{
    /// <summary>
    ///     Interaction logic for fsHomeControl.xaml
    /// </summary>
    public partial class fsHomeControl : UserControl, Animatiable
    {
        //Brushes for the left button colours
        private readonly Storyboard sbIn;
        private readonly SolidColorBrush sel;
        private readonly SolidColorBrush unsel;

        //Holiday home variables

        /// <summary>
        /// The arrowtown
        /// </summary>
        private ScatterViewItem arrowtown;
        /// <summary>
        /// The auckland pin
        /// </summary>
        private Pushpin aucklandPin;
        /// <summary>
        /// The christchurch pin
        /// </summary>
        private Pushpin christchurchPin;
        /// <summary>
        /// The dunedin pin
        /// </summary>
        private Pushpin dunedinPin;
        /// <summary>
        /// The hawkesbay pin
        /// </summary>
        private ScatterViewItem hawkesbay;
        private SurfaceScrollViewer hhscroll;
        /// <summary>
        /// The map
        /// </summary>
        private Map map;
        private SurfaceScrollViewer mscroll;
        /// <summary>
        /// The scatter
        /// </summary>
        private ScatterView scatter;
        /// <summary>
        /// The taupo pin
        /// </summary>
        private ScatterViewItem taupo;
        /// <summary>
        /// The wellington pin
        /// </summary>
        private Pushpin wellingtonPin;


        /// <summary>
        ///     Constructor
        /// </summary>
        public fsHomeControl()
        {
            InitializeComponent();

            //Set the button brush colours 
            sel = new SolidColorBrush(Util._pageColDict["fsSelected"]);
            unsel = new SolidColorBrush(Util._pageColDict["fsUnSelected"]);

            //Set the background of the scrollviewer
            text.Background = new SolidColorBrush(Util.contentBgColor);
            SetButtonStyles();

            sbIn = new Storyboard();
            Util.StackAnimationDefault(sbIn, buttons.Children);
            Util.FadeIn(sbIn, text);

            //set initial content
            scholarship_Click(null, null);

            //set properties of the polaroid at the bottom left
            fsPol.removeTouch();
            fsPol.setShadow(10, 0.3, (Color) ColorConverter.ConvertFromString("#ff7f7f7f"));
        }

        public void AnimateIn()
        {
            sbIn.Begin(this);
            fsPol.AnimateIn();
        }

        public void AnimateOut()
        {
        }

        //Set the styles of the left buttons
        private void SetButtonStyles()
        {
            scholarship.FontFamily = Util.buttonTextFont;
            pResources.FontFamily = Util.buttonTextFont;
            cList.FontFamily = Util.buttonTextFont;
            hHomes.FontFamily = Util.buttonTextFont;

            scholarship.Foreground = new SolidColorBrush(Util.buttonTextColor);
            pResources.Foreground = new SolidColorBrush(Util.buttonTextColor);
            cList.Foreground = new SolidColorBrush(Util.buttonTextColor);
            hHomes.Foreground = new SolidColorBrush(Util.buttonTextColor);

            scholarship.FontSize = Util.buttonTextSize;
            pResources.FontSize = Util.buttonTextSize;
            cList.FontSize = Util.buttonTextSize;
            hHomes.FontSize = Util.buttonTextSize;

            scholarship.HorizontalContentAlignment = HorizontalAlignment.Center;
            pResources.HorizontalContentAlignment = HorizontalAlignment.Center;
            cList.HorizontalContentAlignment = HorizontalAlignment.Center;
            hHomes.HorizontalContentAlignment = HorizontalAlignment.Center;
        }

        //remove all dropshadows and set the colour to unselected on all buttons
        /// <summary>
        /// Resets the BTN effects.
        /// </summary>
        private void ResetBtnEffects()
        {
            scholarship.Background = unsel;
            pResources.Background = unsel;
            hHomes.Background = unsel;
            cList.Background = unsel;

            scholarship.Effect = null;
            pResources.Effect = null;
            hHomes.Effect = null;
            cList.Effect = null;
        }

        /// <summary>
        ///     This method called when the "Scholarships" button has been clicked
        /// </summary>
        /// <param name="sender"> the button that has been clicked</param>
        /// <param name="e"></param>
        private void scholarship_Click(object sender, RoutedEventArgs e)
        {
            // set plaroid image
            fsPol.setImage("images\\FamilySupport\\KidWithHat.png");

            //remove drop shadow from other buttons
            ResetBtnEffects();
            //Set the colour of the scholarship btn to be selected
            scholarship.Background = sel;
            //add drop shadow
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            scholarship.Effect = dShdow;
            //set content
            text.Content = scholarshipContent();

            ResetTimer();
        }

        /// <summary>
        /// Resets the timer.
        /// </summary>
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
        ///     This method called when the "Scholarships" button has been clicked
        /// </summary>
        /// <param name="sender"> the button that has been clicked</param>
        /// <param name="e"></param>
        private void schol_TouchDown(object sender, TouchEventArgs e)
        {
            // set image
            fsPol.setImage("images\\FamilySupport\\KidWithHat.png");

            //remove drop shadow from other buttons
            ResetBtnEffects();
            //Set the colour of the scholarship btn to be selected
            scholarship.Background = sel;
            //add drop shadow
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            scholarship.Effect = dShdow;

            //set the content
            text.Content = scholarshipContent();
        }

        /// <summary>
        ///     Creates a stackpanel that contains content for the scholarship page
        /// </summary>
        /// <returns></returns>
        private StackPanel scholarshipContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock scholarshipText = Util.TextBlockFactory();
            scholarshipText.Inlines.Add(new Bold(new Run("Scholarships \n")));
            scholarshipText.Inlines.Add(
                new Run(
                    "The Child Cancer Foundation Scholarship Fund aims to assist children aged 0 to 12 years with cancer, their siblings aged 0 to 12 years, or parents, achieve their personal education and developmental goals. Any activity that has the potential to educationally or developmentally benefit the applicant will be considered.\n\n"));
            scholarshipText.Inlines.Add(
                new Run(
                    "The Scholarship sub-committee, which meets four times a year, receives and considers all applications. Allocations made depend on the funds available and are made according to the policy guidelines of the Child Cancer Foundation.\n\n"));
            scholarshipText.Inlines.Add(
                new Run(
                    "All application enquiries should be directed to your local Family Support Coordinator.\nFor administration support please contact:\n"));
            scholarshipText.Inlines.Add(new Bold(new Run("Alison O'Connor  PHN ")));
            scholarshipText.Inlines.Add(new Run("(04) 389 2620 or "));
            scholarshipText.Inlines.Add(new Bold(new Run("email ")));
            scholarshipText.Inlines.Add(new Run("aoconnor@childcancer.org.nz\n"));

            contentStackPanel.Children.Add(scholarshipText);
            return contentStackPanel;
        }


        /// <summary>
        ///     This method called when the "parent resources" button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pResources_Click(object sender, RoutedEventArgs e)
        {
            // set polaroid image
            fsPol.setImage("images\\FamilySupport\\MotherandChild.png");

            //Set the background colours of the buttons
            ResetBtnEffects();
            pResources.Background = sel;
            //add drop shadow
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            pResources.Effect = dShdow;

            // set the content of the textbox
            text.Content = pResourcesContent();

            ResetTimer();
        }

        /// <summary>
        ///     This method called when the "parent resources" button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pRes_TouchDown(object sender, TouchEventArgs e)
        {
            // set image
            fsPol.setImage("images\\FamilySupport\\MotherandChild.png");

            //Set the background colours of the buttons
            ResetBtnEffects();
            //set presources to be selected
            pResources.Background = sel;
            //add drop shadow
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            pResources.Effect = dShdow;

            // set the content of the textbox
            text.Content = pResourcesContent();
        }

        /// <summary>
        ///     This method called when the "holiday homes" button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hHomes_Click(object sender, RoutedEventArgs e)
        {
            // set polaroid image
            fsPol.setImage("images\\FamilySupport\\SmilingRelative.png");

            //Set the background colours of the buttons
            ResetBtnEffects();
            hHomes.Background = sel;

            //add drop shadow
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            hHomes.Effect = dShdow;

            // set the content of the textbox
            text.Background = new SolidColorBrush(Util.contentBgColor);
            text.Content = hHomesContent();
            text.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;

            ResetTimer();
        }

        /// <summary>
        ///     This method called when the "holiday homes" button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hHomes_TouchDown(object sender, TouchEventArgs e)
        {
            // set polaroid image
            fsPol.setImage("images\\FamilySupport\\SmilingRelative.png");

            //Set the background colours of the buttons
            ResetBtnEffects();
            hHomes.Background = sel;

            //add drop shadow
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            hHomes.Effect = dShdow;

            // set the content of the textbox
            text.Background = new SolidColorBrush(Util.contentBgColor);
            text.Content = hHomesContent();
            text.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
        }

        /// <summary>
        ///     This method called when the taupo image has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taupo_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //set the content of the scrollviewer
            hhscroll.Content = taupoHomeContent();

            //Set the glow on the taupo polaroid
            ((PoloroidControl) hawkesbay.Content).removeGlow();
            ((PoloroidControl) arrowtown.Content).removeGlow();
            ((PoloroidControl) taupo.Content).setGlow();

            //set the taupo polaroid to be bigger than the other homes
            hawkesbay.Height = 200;
            hawkesbay.Width = 300;
            arrowtown.Height = 200;
            arrowtown.Width = 300;
            taupo.Height = 400;
            taupo.Width = 600;

            taupo.HorizontalAlignment = HorizontalAlignment.Center;
            taupo.VerticalAlignment = VerticalAlignment.Center;

            ResetTimer();
        }

        /// <summary>
        ///     This method called when the arrowtown image has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void arrowtown_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //set the content of the scrollviewer
            hhscroll.Content = arrowtownHomeContent();

            //Set the glow on the arrowtown polaroid
            ((PoloroidControl) hawkesbay.Content).removeGlow();
            ((PoloroidControl) arrowtown.Content).setGlow();
            ((PoloroidControl) taupo.Content).removeGlow();

            //set the arrowtown polaroid to be bigger than the other homes
            hawkesbay.Height = 200;
            hawkesbay.Width = 300;
            arrowtown.Height = 400;
            arrowtown.Width = 600;
            taupo.Height = 200;
            taupo.Width = 300;

            arrowtown.HorizontalAlignment = HorizontalAlignment.Center;
            arrowtown.VerticalAlignment = VerticalAlignment.Center;

            ResetTimer();
        }

        /// <summary>
        ///     This method called when the hawkes bay image has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hawkesBay_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //set the content of the scrollviewer
            hhscroll.Content = hawkesBayHomeContent();

            //Set the glow on the hawkes bay polaroid
            ((PoloroidControl) hawkesbay.Content).setGlow();
            ((PoloroidControl) arrowtown.Content).removeGlow();
            ((PoloroidControl) taupo.Content).removeGlow();

            //set the hawkes bay polaroid to be bigger than the other homes
            hawkesbay.Height = 400;
            hawkesbay.Width = 600;
            arrowtown.Height = 200;
            arrowtown.Width = 300;
            taupo.Height = 200;
            taupo.Width = 300;

            hawkesbay.HorizontalAlignment = HorizontalAlignment.Center;
            hawkesbay.VerticalAlignment = VerticalAlignment.Center;

            ResetTimer();
        }

        /// <summary>
        ///     This method called when the contact list button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cList_Click(object sender, RoutedEventArgs e)
        {
            // set polaroid image
            fsPol.setImage("images\\FamilySupport\\TwoGirls.png");

            //Set the background colours of the buttons
            ResetBtnEffects();
            //Set contact list to be selected
            cList.Background = sel;

            //add drop shadow
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            cList.Effect = dShdow;

            // set the content in the textbox
            //text.Content = cListContent();
            ResetTimer();

            // set the content in the 
            Action action = delegate { mapLoad(); };
            Dispatcher.BeginInvoke(action, DispatcherPriority.Background);
            cList.Content = "Loading...";
        }

        private void cList_TouchDown(object sender, TouchEventArgs e)
        {
            // set image
            fsPol.setImage("images\\FamilySupport\\TwoGirls.png");

            //Set the background colours of the buttons
            ResetBtnEffects();
            //Set contact list to be selected
            cList.Background = sel;

            //add drop shadow
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            cList.Effect = dShdow;
        }

        public void mapLoad()
        {
            //System.Threading.Thread.Sleep(3000);
            text.Content = cListContent();
            cList.Content = "Contact List";
        }

        /// <summary>
        ///     the helper method to generate the content when "contact list" has been clicked
        /// </summary>
        /// <returns></returns>
        private StackPanel cListContent()
        {
            //Set content to on going donation
            StackPanel contentStackPanel = new StackPanel();

            // Set up the Bing map control
            map = new Map();
            map.Mode = new AerialMode(true);
            map.CredentialsProvider = Util.MapProvider;
            map.HorizontalAlignment = HorizontalAlignment.Stretch;
            map.VerticalAlignment = VerticalAlignment.Stretch;
            map.Center = new Location(-41, 174);
            map.ZoomLevel = 6.0;
            map.Height = 550;

            // The pushpin to add to the map.
            aucklandPin = new Pushpin();
            aucklandPin.Location = new Location(-36.843880, 174.767746);

            // Add the pushpin to the map.
            map.Children.Add(aucklandPin);

            // The pushpin to add to the map.
            christchurchPin = new Pushpin();
            christchurchPin.Location = new Location(-43.531010, 172.637787);

            // Add the pushpin to the map.
            map.Children.Add(christchurchPin);

            // The pushpin to add to the map.
            dunedinPin = new Pushpin();
            dunedinPin.Location = new Location(-45.873489, 170.503967);

            // Add the pushpin to the map.
            map.Children.Add(dunedinPin);
            // The pushpin to add to the map.
            wellingtonPin = new Pushpin();
            wellingtonPin.Location = new Location(-41.288940, 174.776276);

            // Add the pushpin to the map.
            map.Children.Add(wellingtonPin);

            //Create handlers to handle when the map is clicked
            map.AddHandler(TouchDownEvent, new EventHandler<TouchEventArgs>(MapWithPushpins_TouchDown), true);
            map.AddHandler(MouseDownEvent, new MouseButtonEventHandler(MapWithPushpins_MouseDown), true);

            //Create a scroll viewer to show pin details
            mscroll = new SurfaceScrollViewer();
            mscroll.Style = FindResource("SurfaceScrollViewerStyle1") as Style;
            mscroll.Height = 300;
            mscroll.Background = new SolidColorBrush((Color) ColorConverter.ConvertFromString("#00000000"));
            mscroll.ScrollChanged += mscroll_ScrollChanged;

            //set the initial content of the scroll viewer to be a prompt 
            TextBlock prompt = Util.TextBlockFactory();
            prompt.TextAlignment = TextAlignment.Center;
            prompt.Inlines.Add(new Run("Click on the pins to see their contact information\n"));
            mscroll.Content = prompt;

            //Add the map and scrollviewer to the stack panel
            contentStackPanel.Children.Add(map);
            contentStackPanel.Children.Add(mscroll);

            //Set only the vertical bar to be visible when necessary
            mscroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            mscroll.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            return contentStackPanel;
        }

        /// <summary>
        /// Handles the ScrollChanged event of the mscroll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ScrollChangedEventArgs"/> instance containing the event data.</param>
        private void mscroll_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ResetTimer();
        }

        /// <summary>
        ///     Called when the map is touched
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapWithPushpins_TouchDown(object sender, TouchEventArgs e)
        {
            // Disables the default touch down behavior.
            e.Handled = true;

            //Get the touch down coordinates
            TouchPoint touchPosition = e.GetTouchPoint(this);

            //Convert the mouse coordinates to a location on the map
            Location pinLocation = map.ViewportPointToLocation(touchPosition.Position);

            //Negate longitude if it comes out negative. Unsure of why this is happening - assuming the user is likely to only look at nz
            if (pinLocation.Longitude < 0)
            {
                pinLocation.Longitude = -pinLocation.Longitude;
            }
            //Calculate the distance to the other pushpins
            double auckdist =
                Math.Sqrt(Math.Pow(aucklandPin.Location.Latitude - pinLocation.Latitude, 2) +
                          Math.Pow(aucklandPin.Location.Longitude - -pinLocation.Longitude, 2));
            double chchdist =
                Math.Sqrt(Math.Pow(christchurchPin.Location.Latitude - pinLocation.Latitude, 2) +
                          Math.Pow(christchurchPin.Location.Longitude - -pinLocation.Longitude, 2));
            double dundist =
                Math.Sqrt(Math.Pow(dunedinPin.Location.Latitude - pinLocation.Latitude, 2) +
                          Math.Pow(dunedinPin.Location.Longitude - -pinLocation.Longitude, 2));
            double welldist =
                Math.Sqrt(Math.Pow(wellingtonPin.Location.Latitude - pinLocation.Latitude, 2) +
                          Math.Pow(wellingtonPin.Location.Longitude - -pinLocation.Longitude, 2));

            //If within 2 latitude/longitude then show content
            if (auckdist > -2 && auckdist < 2)
            {
                mscroll.Content = aucklandContent();
            }
            else if (chchdist > -2 && chchdist < 2)
            {
                mscroll.Content = christchurchContent();
            }
            else if (dundist > -2 && dundist < 2)
            {
                mscroll.Content = dunedinContent();
            }
            else if (welldist > -2 && welldist < 2)
            {
                mscroll.Content = wellingtonContent();
            }

            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException)
            {
            }
        }

        /// <summary>
        ///     Called when the map is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapWithPushpins_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Disables the default touch down behavior.
            e.Handled = true;

            //Get the touch down coordinates
            Point touchPosition = e.GetPosition(this);

            //Convert the mouse coordinates to a location on the map
            Location pinLocation = map.ViewportPointToLocation(touchPosition);

            //Negate longitude if it comes out negative. Unsure of why this is happening - assuming the user is likely to only look at nz
            if (pinLocation.Longitude < 0)
            {
                pinLocation.Longitude = -pinLocation.Longitude;
            }
            //Calculate the distance to the other pushpins
            double auckdist =
                Math.Sqrt(Math.Pow(aucklandPin.Location.Latitude - pinLocation.Latitude, 2) +
                          Math.Pow(aucklandPin.Location.Longitude - -pinLocation.Longitude, 2));
            double chchdist =
                Math.Sqrt(Math.Pow(christchurchPin.Location.Latitude - pinLocation.Latitude, 2) +
                          Math.Pow(christchurchPin.Location.Longitude - -pinLocation.Longitude, 2));
            double dundist =
                Math.Sqrt(Math.Pow(dunedinPin.Location.Latitude - pinLocation.Latitude, 2) +
                          Math.Pow(dunedinPin.Location.Longitude - -pinLocation.Longitude, 2));
            double welldist =
                Math.Sqrt(Math.Pow(wellingtonPin.Location.Latitude - pinLocation.Latitude, 2) +
                          Math.Pow(wellingtonPin.Location.Longitude - -pinLocation.Longitude, 2));

            //If within 2 latitude/longitude then show content
            if (auckdist > -2 && auckdist < 2)
            {
                mscroll.Content = aucklandContent();
            }
            else if (chchdist > -2 && chchdist < 2)
            {
                mscroll.Content = christchurchContent();
            }
            else if (dundist > -2 && dundist < 2)
            {
                mscroll.Content = dunedinContent();
            }
            else if (welldist > -2 && welldist < 2)
            {
                mscroll.Content = wellingtonContent();
            }
            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException)
            {
            }
        }


        /// <summary>
        ///     Content to be displayed on the parent resources page
        /// </summary>
        /// <returns>A stack panel containing the parent resources content</returns>
        private StackPanel pResourcesContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock pResourcesText1 = Util.TextBlockFactory();
            TextBlock pResourcesText2 = Util.TextBlockFactory();

            pResourcesText2.Inlines.Add(new Bold(new Run("Parent Resources \n")));
            pResourcesText2.Inlines.Add(
                new Run(
                    "Child Cancer Foundation aims to provide up-to-date information for families. Below is a list of websites providing additional information, research documents and details about child cancer from around the world."));

            pResourcesText1.Inlines.Add(new Bold(new Run("\nKidscope\n")));
            pResourcesText1.Inlines.Add(
                new Run(
                    "www.kidscope.org\nAn organization which has been formed to help families and children better understand the effects of cancer and chemotherapy.\n\n"));
            pResourcesText1.Inlines.Add(new Bold(new Run("CancerCare, Inc.\n")));
            pResourcesText1.Inlines.Add(new Run("www.cancercareinc.org\n\n"));
            pResourcesText1.Inlines.Add(new Bold(new Run("Chemo Kids\n")));
            pResourcesText1.Inlines.Add(
                new Run(
                    "http://www.chemo4kids.com/cancer-resources/\nThis site offers simplified information about chemotherapy and its use to treat cancer.\n\n"));
            pResourcesText1.Inlines.Add(new Bold(new Run("Candlelighters\n")));
            pResourcesText1.Inlines.Add(
                new Run(
                    "www.candlelighters.org/ \nThe Candlelighters mission is to educate, support, serve, and advocate for families of children with cancer, survivors of childhood cancer and professionals who care for them.\n\n"));
            pResourcesText1.Inlines.Add(new Bold(new Run("ACT\n")));
            pResourcesText1.Inlines.Add(
                new Run(
                    "www.act.org.uk \nThe site of the Association for Children with life-threatening or terminal conditions and their families. This site is in the process of redevelopment and will include access to a web-based research journal called LitpaedpalLit.\n\n"));
            pResourcesText1.Inlines.Add(
                new Bold(new Run("International Confederation of Child Cancer Parent Organisations\n")));
            pResourcesText1.Inlines.Add(new Run("www.icccpo.org\n\n"));
            pResourcesText1.Inlines.Add(new Bold(new Run("Action for Children and Youth in Aotearoa\n")));
            pResourcesText1.Inlines.Add(
                new Run(
                    "www.acya.org.nz \nThis site has many excellent documents relating to areas of rights of children and youth.\n\n"));

            contentStackPanel.Children.Add(pResourcesText2);
            contentStackPanel.Children.Add(pResourcesText1);
            return contentStackPanel;
        }

        /// <summary>
        ///     Content to be displayed on the holiday homes page
        /// </summary>
        /// <returns>A stackpanel with the holiday home content</returns>
        private StackPanel hHomesContent()
        {
            StackPanel contentStackPanel = new StackPanel();
            //Create a scatter view for the holiday home pictures
            scatter = new ScatterView();
            scatter.Height = 500;
            scatter.Background = new SolidColorBrush((Color) ColorConverter.ConvertFromString("#00000000"));

            //Create a scrollviewer for the details about the homes
            hhscroll = new SurfaceScrollViewer();
            hhscroll.Style = FindResource("SurfaceScrollViewerStyle1") as Style;
            hhscroll.Height = 300;
            hhscroll.Background = new SolidColorBrush(Util.contentBgColor);

            hhscroll.ScrollChanged += hhscroll_ScrollChanged;

            //Create a prompt to show the user that they can move/zoom the pictures
            TextBlock prompt = Util.TextBlockFactory();
            prompt.TextAlignment = TextAlignment.Center;
            prompt.Inlines.Add(new Run("Click on the images below to see information or use two fingers to zoom\n"));

            contentStackPanel.Children.Add(prompt);
            contentStackPanel.Children.Add(scatter);
            contentStackPanel.Children.Add(hhscroll);

            //Don't allow horizontal scrolling
            hhscroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            hhscroll.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            //Create new scatterview item for the arrowwtown home
            arrowtown = new ScatterViewItem();
            arrowtown.Content = new PoloroidControl("images/FamilySupport/arrowtown.jpg", "Arrowtown",
                (Color) ColorConverter.ConvertFromString("#ffffffff"));
            (arrowtown.Content as PoloroidControl).removeBorder();
            arrowtown.Orientation = 0;
            arrowtown.Height = 200;
            arrowtown.Width = 300;
            arrowtown.AddHandler(MouseUpEvent, new MouseButtonEventHandler(arrowtown_MouseUp), true);
            scatter.Items.Add(arrowtown);

            //Create new scatterview item for the taupo home
            taupo = new ScatterViewItem();
            taupo.Content = new PoloroidControl("images/FamilySupport/taupo.jpg", "Taupo",
                (Color) ColorConverter.ConvertFromString("#ffffffff"));
            (taupo.Content as PoloroidControl).removeBorder();
            taupo.Orientation = 0;
            taupo.Height = 200;
            taupo.Width = 300;
            taupo.AddHandler(MouseUpEvent, new MouseButtonEventHandler(taupo_MouseUp), true);
            scatter.Items.Add(taupo);

            //Create new scatterview item for the hawkes bay home
            hawkesbay = new ScatterViewItem();
            hawkesbay.Content = new PoloroidControl("images/FamilySupport/hawkesBay.jpg", "Hawkes Bay",
                (Color) ColorConverter.ConvertFromString("#00ffffff"));
            (hawkesbay.Content as PoloroidControl).removeBorder();
            hawkesbay.Orientation = 0;
            hawkesbay.Height = 200;
            hawkesbay.Width = 300;
            hawkesbay.AddHandler(MouseUpEvent, new MouseButtonEventHandler(hawkesBay_MouseUp), true);
            scatter.Items.Add(hawkesbay);

            //set the content to initially be hawkes bay content
            hawkesBay_MouseUp(null, null);
            return contentStackPanel;
        }

        /// <summary>
        /// Handles the ScrollChanged event of the hhscroll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ScrollChangedEventArgs"/> instance containing the event data.</param>
        private void hhscroll_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ResetTimer();
        }

        /// <summary>
        ///     Content about the Taupo holiday home
        /// </summary>
        /// <returns> A stack panel containing the content</returns>
        private StackPanel taupoHomeContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock taupoText = Util.TextBlockFactory();
            taupoText.Inlines.Add(new Bold(new Run("Taupo Sunshine Lodge Holiday Home \n")));
            taupoText.Inlines.Add(
                new Run(
                    "Child Cancer Foundation has a Sunshine Lodge holiday home in Taupo.The Lockwood house offers three-bedrooms, a bathroom and is fully furnished.\n\n"));
            taupoText.Inlines.Add(
                new Run(
                    "If your family would like to book a holiday home please contact:\nMelissa Walker | PHN 03 365 1485 | EML mwalker@childcancer.org.nz\n"));
            contentStackPanel.Children.Add(taupoText);
            return contentStackPanel;
        }

        /// <summary>
        ///     Content about the Arrowtown holiday home
        /// </summary>
        /// <returns> A stack panel containing the content</returns>
        private StackPanel arrowtownHomeContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock arrowText = Util.TextBlockFactory();
            arrowText.Inlines.Add(new Bold(new Run("Arrowtown \n")));
            arrowText.Inlines.Add(
                new Run(
                    "The new Child Cancer Foundation Arrowtown Holiday Home was officially opened in June, 2012.The new Arrowfield Mews property is a three bedroom, two bathroom, two storey, well insulated and sunny house, well suited to the requirement of CCF families. The house is walking distance from the main Arrowtown shopping / entertainment area, close to public transport and opposite the Millbrook golf course.\n\n"));
            arrowText.Inlines.Add(
                new Run(
                    "If your family would like to book a holiday home please contact:\nMelissa Walker | PHN 03 365 1485 | EML mwalker@childcancer.org.nz\n"));
            contentStackPanel.Children.Add(arrowText);
            return contentStackPanel;
        }

        /// <summary>
        ///     Content about the Hawkes Bay holiday home
        /// </summary>
        /// <returns> A stack panel containing the content</returns>
        private StackPanel hawkesBayHomeContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock hbText = Util.TextBlockFactory();
            hbText.Inlines.Add(new Bold(new Run("Hawkes Bay Little Elms \n")));
            hbText.Inlines.Add(
                new Run(
                    "The Trucking for Hawkes Bay Child Cancer Trust owns and manages the Little Elms complex in Orchard Road, Hastings, Hawkes Bay. Families of child cancer patients from around the country are able to use the holiday house to have some much needed “time out”. The Holiday house offers three-bedrooms, two-bathrooms and is fully furnished.\n\n"));
            hbText.Inlines.Add(
                new Run(
                    "If your family would like to book a holiday home please contact:\nMelissa Walker | PHN 03 365 1485 | EML mwalker@childcancer.org.nz\n"));
            contentStackPanel.Children.Add(hbText);
            return contentStackPanel;
        }

        ///////////////////////////
        //Conact list info for map pushpins

        /// <summary>
        ///     Content about the Auckland family support contacts
        /// </summary>
        /// <returns> A stack panel containing the content</returns>
        private StackPanel aucklandContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock auckText = Util.TextBlockFactory();
            auckText.Inlines.Add(new Bold(new Run("Family Support - Auckland﻿ \n")));
            auckText.Inlines.Add(
                new Run(
                    "Janet Masina	 \n(09) 303 9885	jmasina@childcancer.org.nz\n\nMary Mangan	 \n(09) 303 9971	mmangan@childcancer.org.nz\n"));
            contentStackPanel.Children.Add(auckText);
            return contentStackPanel;
        }

        /// <summary>
        ///     Content about the Dunedin family support contacts
        /// </summary>
        /// <returns> A stack panel containing the content</returns>
        private StackPanel dunedinContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock dunText = Util.TextBlockFactory();
            dunText.Inlines.Add(new Bold(new Run("Family Support - Dunedin﻿ \n")));
            dunText.Inlines.Add(new Run("Christine Donovan	\n(03) 471 7258	cdonovan@childcancer.org.nz\n"));
            contentStackPanel.Children.Add(dunText);
            return contentStackPanel;
        }

        /// <summary>
        ///     Content about the Christchurch family support contacts
        /// </summary>
        /// <returns> A stack panel containing the content</returns>
        private StackPanel christchurchContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock chchText = Util.TextBlockFactory();
            chchText.Inlines.Add(new Bold(new Run("Family Support - Christchurch \n")));
            chchText.Inlines.Add(
                new Run(
                    "Christine Graham	 \n(03) 365 1485	cgraham@childcancer.org.nz\n\nDiane Kerr\n021 838 142	dkerr@childcancer.org.nz\n"));
            contentStackPanel.Children.Add(chchText);
            return contentStackPanel;
        }

        /// <summary>
        ///     Content about the Wellington family support contacts
        /// </summary>
        /// <returns> A stack panel containing the content</returns>
        private StackPanel wellingtonContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock wellyText = Util.TextBlockFactory();
            wellyText.Inlines.Add(new Bold(new Run("Family Support - Wellington \n")));
            wellyText.Inlines.Add(
                new Run(
                    "Sally Black\n(04) 389 2620	sblack@childcancer.org.nz\n\nTracy Ward	 \n(04) 389 2620	tward@childcancer.org.nz\n"));
            contentStackPanel.Children.Add(wellyText);
            return contentStackPanel;
        }

        /// <summary>
        /// Handles the ScrollChanged event of the text control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ScrollChangedEventArgs"/> instance containing the event data.</param>
        private void text_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ResetTimer();
        }
    }
}