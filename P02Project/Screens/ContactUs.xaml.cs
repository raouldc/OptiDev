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
using System.Windows.Threading;

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

        private Map moMap;
        private Map map;
        private Pushpin auckMOPin;
        private Pushpin chchPin;
        private Pushpin dunPin;
        private Pushpin taurPin;
        private Pushpin hBPin;
        private Pushpin wellPin;
        //private DispatcherTimer mapLoader;

        private SurfaceScrollViewer familyPlaceScroll;

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

            _fmlPlcs.FontFamily = Util.buttonTextFont;
            _mainOff.FontFamily = Util.buttonTextFont;
            _fndrsOff.FontFamily = Util.buttonTextFont;
            _fmlSptBrns.FontFamily = Util.buttonTextFont;

            _fmlPlcs.FontSize = Util.buttonTextSize;
            _mainOff.FontSize = Util.buttonTextSize;
            _fndrsOff.FontSize = Util.buttonTextSize;
            _fmlSptBrns.FontSize = Util.buttonTextSize;

            _fmlPlcs.Foreground = new SolidColorBrush(Util.buttonTextColor);
            _mainOff.Foreground = new SolidColorBrush(Util.buttonTextColor);
            _fndrsOff.Foreground = new SolidColorBrush(Util.buttonTextColor);
            _fmlSptBrns.Foreground = new SolidColorBrush(Util.buttonTextColor);

            //Animations
            sbIn = new Storyboard();
            Util.StackAnimationDefault(sbIn, buttons.Children);

            Util.SetupQR(QRText, "Find out other ways to contact us at\nhttp://tinyurl.com/mhdzd2f");

            //mapLoader = new DispatcherTimer();

            fmlPlClicked(null, null);

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
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            _fmlPlcs.Effect = dShdow;

            Action act = delegate() { content.Content = familyPlaceContent(); };
            Dispatcher.BeginInvoke(act, DispatcherPriority.ApplicationIdle);
            _fmlPlcs.Content = "Loading...";

            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }
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
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            _mainOff.Effect = dShdow;

            Action act = delegate() { content.Content = mainOfficeContent(); };
            Dispatcher.BeginInvoke(act, DispatcherPriority.Background);
            _mainOff.Content = "Loading...";

            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }
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
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            _fndrsOff.Effect = dShdow;

            content.Content = fundraisingOfficeContent();

            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }
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
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            _fmlSptBrns.Effect = dShdow;

            content.Content = familySupportContent();
            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }
        }


        public void AnimateIn()
        {
            sbIn.Begin(this);
        }

        public void AnimateOut()
        {
            
        }

        private Grid fundraisingOfficeContent() {
            
            Grid fundOfficeGrid = new Grid();

            ColumnDefinition c1 = new ColumnDefinition();
            ColumnDefinition c2 = new ColumnDefinition();
            fundOfficeGrid.ColumnDefinitions.Add(c1);
            fundOfficeGrid.ColumnDefinitions.Add(c2);

            RowDefinition r1 = new RowDefinition();
            RowDefinition r2 = new RowDefinition();
            RowDefinition r3 = new RowDefinition();
            fundOfficeGrid.RowDefinitions.Add(r1);
            fundOfficeGrid.RowDefinitions.Add(r2);
            fundOfficeGrid.RowDefinitions.Add(r3);

            RichTextBox box1 = new RichTextBox(auckFOFlow());
            RichTextBox box2 = new RichTextBox(waikatoFOFlow());
            RichTextBox box3 = new RichTextBox(taurangaFOFlow());
            RichTextBox box4 = new RichTextBox(wellFOFlow());
            RichTextBox box5 = new RichTextBox(canterburyFOFlow());
            RichTextBox box6 = new RichTextBox(otagoFOFlow());

            setRTBoxStyle(box1);
            setRTBoxStyle(box2);
            setRTBoxStyle(box3);
            setRTBoxStyle(box4);
            setRTBoxStyle(box5);
            setRTBoxStyle(box6);

            Grid.SetColumn(box1, 0);
            Grid.SetRow(box1, 0);

            Grid.SetColumn(box2, 1);
            Grid.SetRow(box2, 0);

            Grid.SetColumn(box3, 0);
            Grid.SetRow(box3, 1);

            Grid.SetColumn(box4, 1);
            Grid.SetRow(box4, 1);

            Grid.SetColumn(box5, 0);
            Grid.SetRow(box5, 2);

            Grid.SetColumn(box6, 1);
            Grid.SetRow(box6, 2);

            fundOfficeGrid.Children.Add(box1);
            fundOfficeGrid.Children.Add(box2);
            fundOfficeGrid.Children.Add(box3);
            fundOfficeGrid.Children.Add(box4);
            fundOfficeGrid.Children.Add(box5);
            fundOfficeGrid.Children.Add(box6);
           
            return fundOfficeGrid;
        }

        private static void setRTBoxStyle(RichTextBox box)
        {
            box.FontFamily = Util.contentTextFont;
            box.FontSize = Util.contentTextSize;
            box.Foreground = new SolidColorBrush(Util.contentTextColor);
            box.Background = new SolidColorBrush(Util.contentBgColor);
            box.Margin = new Thickness(10);
            box.Width = 400;
            box.Height = 250;
            //add drop shadow
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            box.Effect = dShdow; 
        }

        private Grid familySupportContent()
        {

            Grid familySupportGrid = new Grid();
           
            ColumnDefinition c1 = new ColumnDefinition();
            ColumnDefinition c2 = new ColumnDefinition();
            familySupportGrid.ColumnDefinitions.Add(c1);
            familySupportGrid.ColumnDefinitions.Add(c2);

            RowDefinition r1 = new RowDefinition();
            RowDefinition r2 = new RowDefinition();
            RowDefinition r3 = new RowDefinition();
            familySupportGrid.RowDefinitions.Add(r1);
            familySupportGrid.RowDefinitions.Add(r2);
            familySupportGrid.RowDefinitions.Add(r3);

            RichTextBox box1 = new RichTextBox(auckFSFlow());
            RichTextBox box2 = new RichTextBox(waikatoFSFlow());
            RichTextBox box3 = new RichTextBox(tarawhitiFSFlow());
            RichTextBox box4 = new RichTextBox(wellFSFlow());
            RichTextBox box5 = new RichTextBox(chchFSFlow());
            RichTextBox box6 = new RichTextBox(dunedinFSFlow());

            setRTBoxStyle(box1);
            setRTBoxStyle(box2);
            setRTBoxStyle(box3);
            setRTBoxStyle(box4);
            setRTBoxStyle(box5);
            setRTBoxStyle(box6);

            Grid.SetColumn(box1, 0);
            Grid.SetRow(box1, 0);

            Grid.SetColumn(box2, 1);
            Grid.SetRow(box2, 0);

            Grid.SetColumn(box3, 0);
            Grid.SetRow(box3, 1);

            Grid.SetColumn(box4, 1);
            Grid.SetRow(box4, 1);

            Grid.SetColumn(box5, 0);
            Grid.SetRow(box5, 2);

            Grid.SetColumn(box6, 1);
            Grid.SetRow(box6, 2);

            familySupportGrid.Children.Add(box1);
            familySupportGrid.Children.Add(box2);
            familySupportGrid.Children.Add(box3);
            familySupportGrid.Children.Add(box4);
            familySupportGrid.Children.Add(box5);
            familySupportGrid.Children.Add(box6);
        
            return familySupportGrid;
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

            //Remove all pushpins from the map
            //Map
            map = new Map();
            map.Mode = new AerialMode(labels: true);
            map.CredentialsProvider = Util.MapProvider;
            map.HorizontalAlignment = HorizontalAlignment.Stretch;
            map.VerticalAlignment = VerticalAlignment.Stretch;
            map.Center = new Location(-41, 174);
            map.ZoomLevel = 6.0;
            map.Height = 550;


            //init pushpins
            auckMOPin = new Pushpin();
            chchPin = new Pushpin();
            dunPin = new Pushpin();
            taurPin = new Pushpin();
            hBPin = new Pushpin();
            wellPin = new Pushpin();

            auckMOPin.Location = new Location(-36.857897, 174.769401);
            chchPin.Location = new Location(-43.501951, 172.544112);
            dunPin.Location = new Location(-45.868512, 170.50574);
            taurPin.Location = new Location(-37.699713, 176.156457);
            hBPin.Location = new Location(-39.628639, 176.822171);
            wellPin.Location = new Location(-41.307915, 174.77836);

            map.Children.Add(auckMOPin);
            map.Children.Add(chchPin);
            map.Children.Add(dunPin);
            map.Children.Add(taurPin);
            map.Children.Add(hBPin);
            map.Children.Add(wellPin);

            map.AddHandler(UIElement.TouchDownEvent, new EventHandler<TouchEventArgs>(MapWithPushpins_TouchDown), true);
            map.AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(MapWithPushpins_MouseDown), true);

            //List of buttons to zoom in on locations
            //StackPanel mapBtns = mapButtons();


            familyPlaceScroll = new SurfaceScrollViewer();
            familyPlaceScroll.Style = this.FindResource("SurfaceScrollViewerStyle1") as Style;
            familyPlaceScroll.Height = 300;
            familyPlaceScroll.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00000000"));
            
            TextBlock prompt = Util.TextBlockFactory();
            prompt.TextAlignment = TextAlignment.Center;
            prompt.Inlines.Add(new Run("Click on the pins to see their contact information\n"));
            familyPlaceScroll.Content = prompt;

            contentStackPanel.Children.Add(map);
            //contentStackPanel.Children.Add(mapBtns);
            contentStackPanel.Children.Add(familyPlaceScroll);

            familyPlaceScroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            familyPlaceScroll.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            _fmlPlcs.Content = "Family Places";

            return contentStackPanel;
        }

        //private StackPanel mapButtons() { 
        //    StackPanel stack = new StackPanel();
        //    stack.Orientation = Orientation.Horizontal;
        //    Button  

        //    return stack;
        //}

        /// <summary>
        /// the helper method to generate the content when "contact list" has been clicked
        /// </summary>
        /// <returns></returns>
        private StackPanel mainOfficeContent()
        {
            //Set content to on going donation
            StackPanel contentStackPanel = new StackPanel();


            moMap = new Map();
            moMap.Mode = new AerialMode(labels: true);
            moMap.CredentialsProvider = Util.MapProvider;
            moMap.HorizontalAlignment = HorizontalAlignment.Stretch;
            moMap.VerticalAlignment = VerticalAlignment.Stretch;
            moMap.Center = new Location(-41, 174);
            moMap.ZoomLevel = 6.0;
            moMap.Height = 550;

            Pushpin moPin = new Pushpin(); 
            moPin.Location = new Location(-36.857897, 174.769401);
            moMap.Children.Add(moPin);

            SurfaceScrollViewer scrollContent = new SurfaceScrollViewer();
            scrollContent.Style = this.FindResource("SurfaceScrollViewerStyle1") as Style;
            scrollContent.Height = 300;
            scrollContent.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00000000"));
            scrollContent.AddHandler(UIElement.TouchUpEvent, new EventHandler<TouchEventArgs>(MainOffice_TouchDown), true);

            //Add main office content here
            scrollContent.Content = auckMOContent();
            
            contentStackPanel.Children.Add(moMap);
            contentStackPanel.Children.Add(scrollContent);

            scrollContent.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            scrollContent.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            _mainOff.Content = "Main Office";

            return contentStackPanel;
        }

        private void MainOffice_TouchDown(object sender, TouchEventArgs e)
        {
            moMap.Center = auckMOPin.Location;
            moMap.ZoomLevel = 8.0;
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
            Console.WriteLine("Touched - "+ pinLocation.Latitude +", "+ pinLocation.Longitude);
            //Calculate the distance to the other pushpins
            //Negate longitude if it coems out negative. Unsure of why this is happening - assuming the user is likely to only look at nz
            if(pinLocation.Longitude < 0){
                pinLocation.Longitude = -pinLocation.Longitude;
            }

            double auckdist = Math.Sqrt(Math.Pow(auckMOPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(auckMOPin.Location.Longitude - pinLocation.Longitude, 2));
            double chchdist = Math.Sqrt(Math.Pow(chchPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(chchPin.Location.Longitude - pinLocation.Longitude, 2));
            double dundist = Math.Sqrt(Math.Pow(dunPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(dunPin.Location.Longitude - pinLocation.Longitude, 2));
            double welldist = Math.Sqrt(Math.Pow(wellPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(wellPin.Location.Longitude - pinLocation.Longitude, 2));
            double taurdist = Math.Sqrt(Math.Pow(taurPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(taurPin.Location.Longitude - pinLocation.Longitude, 2));
            double hbdist = Math.Sqrt(Math.Pow(hBPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(hBPin.Location.Longitude - pinLocation.Longitude, 2));


            Console.WriteLine("Distances a- " + auckdist + ", c-" + chchdist + ", d-" + dundist + ", w-" + welldist + ", t-" + taurdist + ", h-" + hbdist);
             //If within 2 latitude/longitude then show content
            if (auckdist > -1 && auckdist < 2)
            {
                Console.WriteLine("Displaying A content");
                familyPlaceScroll.Content = auckFPContent();
            }
            else if (chchdist > -2 && chchdist < 2)
            {
                Console.WriteLine("Displaying C content");
                familyPlaceScroll.Content = chchFPContent();
            }
            else if (dundist > -2 && dundist < 2)
            {
                Console.WriteLine("Displaying D content");
                familyPlaceScroll.Content = dunedinFPContent();
            }
            else if (welldist > -2 && welldist < 2)
            {
                Console.WriteLine("Displaying W content");
                familyPlaceScroll.Content = wellFPContent();
            }
            else if (taurdist > -2 && taurdist < 2)
            {
                Console.WriteLine("Displaying T content");
                familyPlaceScroll.Content = taurangaFPContent();
            }
            else if (hbdist > -2 && hbdist < 2)
            {
                Console.WriteLine("Displaying H content");
                familyPlaceScroll.Content = hbFPContent();
            }
            
        }

        private void MapWithPushpins_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Disables the default touch down behavior.
            e.Handled = true;

            //Get the touch down coordinates
            Point touchPosition = e.GetPosition(this);

            //Convert the mouse coordinates to a location on the map
            Location pinLocation = map.ViewportPointToLocation(touchPosition);

            Console.WriteLine("Touched - " + pinLocation.Latitude + ", " + pinLocation.Longitude);
            //Calculate the distance to the other pushpins
            double auckdist = Math.Sqrt(Math.Pow(auckMOPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(auckMOPin.Location.Longitude - -pinLocation.Longitude, 2));
            double chchdist = Math.Sqrt(Math.Pow(chchPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(chchPin.Location.Longitude - -pinLocation.Longitude, 2));
            double dundist = Math.Sqrt(Math.Pow(dunPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(dunPin.Location.Longitude - -pinLocation.Longitude, 2));
            double welldist = Math.Sqrt(Math.Pow(wellPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(wellPin.Location.Longitude - -pinLocation.Longitude, 2));
            double taurdist = Math.Sqrt(Math.Pow(taurPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(taurPin.Location.Longitude - -pinLocation.Longitude, 2));
            double hbdist = Math.Sqrt(Math.Pow(hBPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(hBPin.Location.Longitude - -pinLocation.Longitude, 2));

            Console.WriteLine("Distances a- " + auckdist + ", c-" + chchdist + ", d-" + dundist + ", w-" + welldist + ", t-" + taurdist + ", h-" + hbdist);
            //If within 2 latitude/longitude then show content
            if (auckdist > -1 && auckdist < 2)
            {
                Console.WriteLine("Displaying A content");
                familyPlaceScroll.Content = auckFPContent();
            }
            else if (chchdist > -2 && chchdist < 2)
            {
                Console.WriteLine("Displaying C content");
                familyPlaceScroll.Content = chchFPContent();
            }
            else if (dundist > -2 && dundist < 2)
            {
                Console.WriteLine("Displaying D content");
                familyPlaceScroll.Content = dunedinFPContent();
            }
            else if (welldist > -2 && welldist < 2)
            {
                Console.WriteLine("Displaying W content");
                familyPlaceScroll.Content = wellFPContent();
            }
            else if (taurdist > -2 && taurdist < 2)
            {
                Console.WriteLine("Displaying T content");
                familyPlaceScroll.Content = taurangaFPContent();
            }
            else if (hbdist > -2 && hbdist < 2)
            {
                Console.WriteLine("Displaying H content");
                familyPlaceScroll.Content = hbFPContent();
            }
        }

        private FlowDocument auckFOFlow()
        {
            FlowDocument flow = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Auckland / Northland\n")));
            p.Inlines.Add(new Run("Liz Atkinson\nPhone: 09 303 9976  | 021 574 545\nlatkinson@childcancer.org.nz"));
            flow.Blocks.Add(p);
            return flow;
        }
        private FlowDocument waikatoFOFlow()
        {
            FlowDocument flow = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Waikato\n")));
            p.Inlines.Add(new Run("Sharon Robertson\nPhone: 021 858 903\nEmail: srobertson@childcancer.org.nz"));
            flow.Blocks.Add(p);
            return flow;
        }
        private FlowDocument taurangaFOFlow()
        {
            FlowDocument flow = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Tauranga\n")));
            p.Inlines.Add(new Run("Delwynne Hahunga\nPhone: 07 579 4141 | 021 497 859\nEmail: dhahunga@childcancer.org.nz"));
            flow.Blocks.Add(p);
            return flow;
        }
        private FlowDocument wellFOFlow()
        {
            FlowDocument flow = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Wellington Family Place\n")));
            p.Inlines.Add(new Run("27 Riddiford Street\nNewtown\nWellington\nPhone: (04) 389 2620"));
            flow.Blocks.Add(p);
            return flow;
        }
        private FlowDocument canterburyFOFlow()
        {
            FlowDocument flow = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Canterbury/West Coast\n")));
            p.Inlines.Add(new Run("Clare Wilkinson\nPhone: 03 365 1485\nEmail: cwilkinson@childcancer.org.nz"));
            flow.Blocks.Add(p);
            return flow;
        }
        private FlowDocument otagoFOFlow()
        {
            FlowDocument flow = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Otago / Southland\n")));
            p.Inlines.Add(new Run("Elaine Horn\nPhone:03 471 7258 | 021 733 671 \nEmail: ehorn@childcancer.org.nz"));
            flow.Blocks.Add(p);
            return flow;
        }

        //////////////////////////
        //Family support flow documents
        private FlowDocument auckFSFlow()
        {
            FlowDocument flow = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Auckland\n")));
            p.Inlines.Add(new Run("Janet Masina\nPhone:09 303 9885 \nEmail: jmasina@childcancer.org.nz"));
            flow.Blocks.Add(p);
            return flow;
        }

        private FlowDocument waikatoFSFlow()
        {
            FlowDocument flow = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Waikato\n")));
            p.Inlines.Add(new Run("Robyn Cresswell\nPhone: 021 714 088\nEmail: rcresswell@childcancer.org.nz"));
            flow.Blocks.Add(p);
            return flow;
        }
        private FlowDocument tarawhitiFSFlow()
        {
            FlowDocument flow = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Tarawhiti\n")));
            p.Inlines.Add(new Run("Cheryl Scott\nPhone: 027 361 7000\nEmail: cscott@childcancer.org.nz"));
            flow.Blocks.Add(p);
            return flow;
        }

        private FlowDocument wellFSFlow()
        {
            FlowDocument flow = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Wellington\n")));
            p.Inlines.Add(new Run("Tracy Ward\nPhone: 04 389 2620\nEmail: tward@childcancer.org.nz"));
            flow.Blocks.Add(p);
            return flow;
        }

        private FlowDocument chchFSFlow()
        {
            FlowDocument flow = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Christchurch\n")));
            p.Inlines.Add(new Run("Robin Furley\nPhone: 03 365 1485\nEmail: rfurley@childcancer.org.nz"));
            flow.Blocks.Add(p);
            return flow;
        }

        private FlowDocument dunedinFSFlow() {
            FlowDocument flow = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Dunedin\n")));
            p.Inlines.Add(new Run("Christine Donovan\nPhone: 03 471 7258 \n Email: cdonovan@childcancer.org.nz"));
            flow.Blocks.Add(p);
            return flow;
        }

    }
}