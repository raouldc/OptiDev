using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Animation;
using System.Windows.Documents;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Surface.Presentation.Controls;
using System.Windows.Input;
using P02Project.Utils;

namespace P02Project
{
    /// <summary>
    /// Interaction logic for ContactUs.xaml
    /// </summary>
    public partial class ContactUs : UserControl, Animatiable
    {
        // constant color for selected and unselected buttons
        private static readonly Brush SELECTED_COLOR = new SolidColorBrush(Util._pageColDict["cuSelected"]);
        private static readonly Brush UNSELECTED_COLOR = new SolidColorBrush(Util._pageColDict["cuUnSelected"]);

        private Map map;
        private Pushpin aucklandPin;
        private Pushpin christchurchPin;
        private Pushpin dunedinPin;
        private Pushpin wellingtonPin;

        private SurfaceScrollViewer familyPlaceScroll;

        // lists storing the contents of each option
        private List<RichTextBox> _fndrsOffList;
        private List<RichTextBox> _fmlSptList;

        //Animations
        private Storyboard sbIn;

        public ContactUs()
        {
            this.InitializeComponent();
            
            // set the color for each button
            _fmlPlcs.Background = SELECTED_COLOR;
            _mainOff.Background = UNSELECTED_COLOR;
            _fndrsOff.Background = UNSELECTED_COLOR;
            _fmlSptBrns.Background = UNSELECTED_COLOR;

            
            //Animations
            sbIn = new Storyboard();
            Util.StackAnimationDefault(sbIn, buttons.Children);

            content.Content = familyPlaceContent();

        }



        /// <summary>
        /// this method called when the "Family Places" option button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fmlPlClicked(Object sender, RoutedEventArgs e)
        {
            // set the color for all buttons
            _fmlPlcs.Background = SELECTED_COLOR;
            _mainOff.Background = UNSELECTED_COLOR;
            _fndrsOff.Background = UNSELECTED_COLOR;
            _fmlSptBrns.Background = UNSELECTED_COLOR;

            //remove drop shadow from other buttons
            _mainOff.Effect = null;
            _fndrsOff.Effect = null;
            _fmlSptBrns.Effect = null;

            //add drop shadow
            _fmlPlcs.Effect = new DropShadowEffect();

            content.Content = familyPlaceContent();
        }



        /// <summary>
        /// this method called when the "Main Office" option button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainOffClicked(Object sender, RoutedEventArgs e)
        {
            // set the color for all buttons
            _fmlPlcs.Background = UNSELECTED_COLOR;
            _mainOff.Background = SELECTED_COLOR;
            _fndrsOff.Background = UNSELECTED_COLOR;
            _fmlSptBrns.Background = UNSELECTED_COLOR;

            //remove drop shadow from other buttons
            _fmlPlcs.Effect = null;
            _fndrsOff.Effect = null;
            _fmlSptBrns.Effect = null;

            //add drop shadow
            _mainOff.Effect = new DropShadowEffect();

            content.Content = mainOfficeContent();
        }


        /// <summary>
        /// this method called when the "Findraising Office" option button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fndrsClicked(Object sender, RoutedEventArgs e)
        {
            // set the color for all buttons
            _fmlPlcs.Background = UNSELECTED_COLOR;
            _mainOff.Background = UNSELECTED_COLOR;
            _fndrsOff.Background = SELECTED_COLOR;
            _fmlSptBrns.Background = UNSELECTED_COLOR;

            //remove drop shadow from other buttons
            _fmlPlcs.Effect = null;
            _mainOff.Effect = null;
            _fmlSptBrns.Effect = null;

            //add drop shadow
            _fndrsOff.Effect = new DropShadowEffect();

            content.Content = fundraisingOfficeContent();
        }



        /// <summary>
        /// this method called when the "Family Support Branches" option button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fmlSptBrsClicked(Object sender, RoutedEventArgs e)
        {
            // set the color for all buttons
            _fmlPlcs.Background = UNSELECTED_COLOR;
            _mainOff.Background = UNSELECTED_COLOR;
            _fndrsOff.Background = UNSELECTED_COLOR;
            _fmlSptBrns.Background = SELECTED_COLOR;

            //remove drop shadow from other buttons
            _fmlPlcs.Effect = null;
            _mainOff.Effect = null;
            _fndrsOff.Effect = null;

            //add drop shadow
            _fmlSptBrns.Effect = new DropShadowEffect();

            content.Content = familySupportContent();
        }


        public void AnimateIn()
        {
            sbIn.Begin(this);
        }

        public void AnimateOut()
        {
            
        }

        private Grid fundraisingOfficeContent() {
            Grid g = new Grid();
            // Add paragraphs to the FlowDocument.
            
            RichTextBox box1 = new RichTextBox((FlowDocument)FindResource("auckFOFlow"));
            RichTextBox box2 = new RichTextBox((FlowDocument)FindResource("waikatoFOFlow"));
            RichTextBox box3 = new RichTextBox((FlowDocument)FindResource("taurangaFOFlow"));
            RichTextBox box4 = new RichTextBox((FlowDocument)FindResource("wellFOFlow"));
            RichTextBox box5 = new RichTextBox((FlowDocument)FindResource("canterburyFOFlow"));
            RichTextBox box6 = new RichTextBox((FlowDocument)FindResource("otagoFOFlow"));
            
            g.Children.Add(box1);
            g.Children.Add(box2);
            g.Children.Add(box3);
            g.Children.Add(box4);
            g.Children.Add(box5);
            g.Children.Add(box6);
            
            return g;
        }

        private Grid familySupportContent()
        {
            Grid g = new Grid();
            // Add paragraphs to the FlowDocument.

            RichTextBox box1 = new RichTextBox((FlowDocument)FindResource("auckFSFlow"));
            RichTextBox box2 = new RichTextBox((FlowDocument)FindResource("waikatoFSFlow"));
            RichTextBox box3 = new RichTextBox((FlowDocument)FindResource("tarawhitiFSFlow"));
            RichTextBox box4 = new RichTextBox((FlowDocument)FindResource("wellFSFlow"));
            RichTextBox box5 = new RichTextBox((FlowDocument)FindResource("chchFSFlow"));
            RichTextBox box6 = new RichTextBox((FlowDocument)FindResource("dunedinFSFlow"));

            g.Children.Add(box1);
            g.Children.Add(box2);
            g.Children.Add(box3);
            g.Children.Add(box4);
            g.Children.Add(box5);
            g.Children.Add(box6);

            return g;
        }

        /// <summary>
        /// Content about the Auckland main office contacts
        /// </summary>
        /// <returns> A stack panel containing the content</returns>
        private StackPanel auckMOContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock textB = Util.TextBlockFactory();
            textB.Inlines.Add(new Bold(new Run("Main Office \n")));
            textB.Inlines.Add(new Run("Our National Office is based in Auckland.\n"));
            textB.Inlines.Add(new Bold(new Run("Address \n")));
            textB.Inlines.Add(new Run("The Family Place\n76 Grafton Rd\nGrafton\nAuckland 1010\n"));
            textB.Inlines.Add(new Bold(new Run("Postal Address \n")));
            textB.Inlines.Add(new Run("PO Box 152\nShortland Street\nAuckland 1140\n"));
            textB.Inlines.Add(new Bold(new Run("Phone")));
            textB.Inlines.Add(new Run(" | 09 366 1270"));
            textB.Inlines.Add(new Bold(new Run("Fax")));
            textB.Inlines.Add(new Run(" | 09 377 9395\n"));
            
            contentStackPanel.Children.Add(textB);
            return contentStackPanel;
        }

    /// <summary>
        /// Content about the Auckland family place contacts
        /// </summary>
        /// <returns> A stack panel containing the content</returns>
        private StackPanel auckFPContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock textB = Util.TextBlockFactory();
            textB.Inlines.Add(new Bold(new Run("Auckland Family Place \n")));
            textB.Inlines.Add(new Run("76 Grafton Road\nGrafton \nAuckland\nPhone: (09) 366 1270\n"));
            contentStackPanel.Children.Add(textB);
            return contentStackPanel;
        }



    /// <summary>
        /// Content about the Tauranga family place contacts
        /// </summary>
        /// <returns> A stack panel containing the content</returns>
        private StackPanel taurangaFPContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock textB = Util.TextBlockFactory();
            textB.Inlines.Add(new Bold(new Run("Tauranga Family Place \n")));
            textB.Inlines.Add(new Run("56 Christopher Street\nTauranga\nPhone: (07) 579 4141\n"));
            contentStackPanel.Children.Add(textB);
            return contentStackPanel;
        }

/// <summary>
        /// Content about the Hawkes Bay family place contacts
        /// </summary>
        /// <returns> A stack panel containing the content</returns>
        private StackPanel hbFPContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock textB = Util.TextBlockFactory();
            textB.Inlines.Add(new Bold(new Run("Hawkes Bay Family Place \n")));
            textB.Inlines.Add(new Run("310 Orchard Road\nHastings\nPhone : (06) 870 3189\n"));
            contentStackPanel.Children.Add(textB);
            return contentStackPanel;
        }

/// <summary>
        /// Content about the Wellington family place contacts
        /// </summary>
        /// <returns> A stack panel containing the content</returns>
        private StackPanel wellFPContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock textB = Util.TextBlockFactory();
            textB.Inlines.Add(new Bold(new Run("Wellington Family Place \n")));
            textB.Inlines.Add(new Run("27 Riddiford Street\nNewtown\nWellington\nPhone: (04) 389 2620\n"));
            contentStackPanel.Children.Add(textB);
            return contentStackPanel;
        }

        /// <summary>
        /// Content about the Christchurch family place contacts
        /// </summary>
        /// <returns> A stack panel containing the content</returns>
        private StackPanel chchFPContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock textB = Util.TextBlockFactory();
            textB.Inlines.Add(new Bold(new Run("Christchurch Family Place \n")));
            textB.Inlines.Add(new Run("Temporarily located at:\n297 Russley Road (entrance off Ron Guthrey Road)\nAvonhead\nChristchurch\nPhone: (03) 365 1485\nConstruction on our new Family Place will begin shortly!\n"));
            contentStackPanel.Children.Add(textB);
            return contentStackPanel;
        }

        /// <summary>
        /// Content about the Dunedin family place contacts
        /// </summary>
        /// <returns> A stack panel containing the content</returns>
        private StackPanel dunedinFPContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock textB = Util.TextBlockFactory();
            textB.Inlines.Add(new Bold(new Run("Dunedin Family Place \n")));
            textB.Inlines.Add(new Run("28 London Street\nDunedin\nPhone: (03) 471 7258\n"));
            contentStackPanel.Children.Add(textB);
            return contentStackPanel;
        }


        /// <summary>
        /// the helper method to generate the content when "contact list" has been clicked
        /// </summary>
        /// <returns></returns>
        private StackPanel familyPlaceContent()
        {
            //Set content to on going donation
            StackPanel contentStackPanel = new StackPanel();


            // Set up the Bing map control
            map = new Map();
            map.Mode = new AerialMode(labels: true);
            map.CredentialsProvider = Util.MapProvider;
            map.HorizontalAlignment = HorizontalAlignment.Stretch;
            map.VerticalAlignment = VerticalAlignment.Stretch;
            map.Center = new Location(-41, 174);
            map.ZoomLevel = 6.0;
            map.Height = 550;

            // The pushpin to add to the map.
            aucklandPin = new Pushpin();
            aucklandPin.Location = new Location(-36.843880, 174.767746);

            // Adds the pushpin to the map.
            map.Children.Add(aucklandPin);

            // The pushpin to add to the map.
            christchurchPin = new Pushpin();
            christchurchPin.Location = new Location(-43.531010, 172.637787);

            // Adds the pushpin to the map.
            map.Children.Add(christchurchPin);

            // The pushpin to add to the map.
            dunedinPin = new Pushpin();
            dunedinPin.Location = new Location(-45.873489, 170.503967);

            // Adds the pushpin to the map.
            map.Children.Add(dunedinPin);
            // The pushpin to add to the map.
            wellingtonPin = new Pushpin();
            wellingtonPin.Location = new Location(-41.288940, 174.776276);

            // Adds the pushpin to the map.
            map.Children.Add(wellingtonPin);

            map.AddHandler(UIElement.TouchDownEvent, new EventHandler<TouchEventArgs>(MapWithPushpins_TouchDown), true);
            map.AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(MapWithPushpins_MouseDown), true);

            familyPlaceScroll = new SurfaceScrollViewer();
            familyPlaceScroll.Height = 300;
            familyPlaceScroll.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00000000"));


            TextBlock prompt = Util.TextBlockFactory();
            prompt.TextAlignment = TextAlignment.Center;
            prompt.Inlines.Add(new Run("Click on the pins to see their contact information\n"));

            familyPlaceScroll.Content = prompt;

            contentStackPanel.Children.Add(map);
            contentStackPanel.Children.Add(familyPlaceScroll);

            familyPlaceScroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            familyPlaceScroll.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            return contentStackPanel;
        }

        /// <summary>
        /// the helper method to generate the content when "contact list" has been clicked
        /// </summary>
        /// <returns></returns>
        private StackPanel mainOfficeContent()
        {
            //Set content to on going donation
            StackPanel contentStackPanel = new StackPanel();


            // Set up the Bing map control
            Map moMap = new Map();
            moMap.Mode = new AerialMode(labels: true);
            moMap.CredentialsProvider = Util.MapProvider;
            moMap.HorizontalAlignment = HorizontalAlignment.Stretch;
            moMap.VerticalAlignment = VerticalAlignment.Stretch;
            moMap.Center = new Location(-41, 174);
            moMap.ZoomLevel = 6.0;
            moMap.Height = 550;

            // The pushpin to add to the map.
            Pushpin moPin = new Pushpin();
            moPin.Location = new Location(-36.843880, 174.767746);

            // Adds the pushpin to the map.
            moMap.Children.Add(moPin);

            SurfaceScrollViewer scrollContent = new SurfaceScrollViewer();
            scrollContent.Height = 300;
            scrollContent.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00000000"));

            //Add main office content here
            scrollContent.Content = mainOfficeContent();
            
            contentStackPanel.Children.Add(map);
            contentStackPanel.Children.Add(scrollContent);

            scrollContent.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            scrollContent.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            return contentStackPanel;
        }


        private void MapWithPushpins_TouchDown(object sender, TouchEventArgs e)
        {
            // Disables the default touch down behavior.
            e.Handled = true;

            //Get the touch down coordinates
            TouchPoint touchPosition = e.GetTouchPoint(this);
            //Convert the mouse coordinates to a location on the map
            //pinlocation longitude is comingout as negative so reversing
            Location pinLocation = map.ViewportPointToLocation(touchPosition.Position);

            //Calculate the distance to the other pushpins
            double auckdist = Math.Sqrt(Math.Pow(aucklandPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(aucklandPin.Location.Longitude - -pinLocation.Longitude, 2));
            double chchdist = Math.Sqrt(Math.Pow(christchurchPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(christchurchPin.Location.Longitude - -pinLocation.Longitude, 2));
            double dundist = Math.Sqrt(Math.Pow(dunedinPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(dunedinPin.Location.Longitude - -pinLocation.Longitude, 2));
            double welldist = Math.Sqrt(Math.Pow(wellingtonPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(wellingtonPin.Location.Longitude - -pinLocation.Longitude, 2));

             //If within 2 latitude/longitude then show content
            if (auckdist > -2 && auckdist < 2)
            {
                familyPlaceScroll.Content = auckFPContent();
            }
            else if (chchdist > -2 && chchdist < 2)
            {
                familyPlaceScroll.Content = chchFPContent();
            }
            else if (dundist > -2 && dundist < 2)
            {
                familyPlaceScroll.Content = dunedinFPContent();
            }
            else if (welldist > -2 && welldist < 2)
            {
                familyPlaceScroll.Content = wellFPContent();
            }

            // Adds the pushpin to the map.
            //map.Children.Add(pin);
        }

        private void MapWithPushpins_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Disables the default touch down behavior.
            e.Handled = true;

            //Get the touch down coordinates
            Point touchPosition = e.GetPosition(this);

            //Convert the mouse coordinates to a location on the map
            Location pinLocation = map.ViewportPointToLocation(touchPosition);

            //Calculate the distance to the other pushpins
            double auckdist = Math.Sqrt(Math.Pow(aucklandPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(aucklandPin.Location.Longitude - -pinLocation.Longitude, 2));
            double chchdist = Math.Sqrt(Math.Pow(christchurchPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(christchurchPin.Location.Longitude - -pinLocation.Longitude, 2));
            double dundist = Math.Sqrt(Math.Pow(dunedinPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(dunedinPin.Location.Longitude - -pinLocation.Longitude, 2));
            double welldist = Math.Sqrt(Math.Pow(wellingtonPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(wellingtonPin.Location.Longitude - -pinLocation.Longitude, 2));

            //If within 2 latitude/longitude then show content
            if (auckdist > -2 && auckdist < 2)
            {
                familyPlaceScroll.Content = auckFPContent();
            }
            else if (chchdist > -2 && chchdist < 2)
            {
                familyPlaceScroll.Content = chchFPContent();
            }
            else if (dundist > -2 && dundist < 2)
            {
                familyPlaceScroll.Content = dunedinFPContent();
            }
            else if (welldist > -2 && welldist < 2)
            {
                familyPlaceScroll.Content = wellFPContent();
            }

        }
    }
}