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
using System.Windows.Media.Effects;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Maps.MapControl.WPF;
using P02Project.Screens;

namespace P02Project
{
	/// <summary>
	/// Interaction logic for fsHomeControl.xaml
	/// </summary>
	public partial class fsHomeControl : UserControl
	{
        private SolidColorBrush unsel;
        private SolidColorBrush sel;

        private ScatterView scatter;
        private SurfaceScrollViewer hhscroll;

        private SurfaceScrollViewer mscroll;

        private ScatterViewItem arrowtown;
        private ScatterViewItem taupo;
        private ScatterViewItem hawkesbay;

        Map map;
        Pushpin aucklandPin;
            Pushpin christchurchPin;
            Pushpin dunedinPin;
            Pushpin wellingtonPin;

        /// <summary>
        /// Constructor
        /// </summary>
		public fsHomeControl()
		{
			this.InitializeComponent();
            
            sel = new SolidColorBrush(Util._pageColDict["fsSelected"]);
            unsel = new SolidColorBrush(Util._pageColDict["fsUnSelected"]);

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

            scholarship.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            pResources.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            cList.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            hHomes.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;

            scholarship_Click(null, null);

            fsPol.removeTouch();
            fsPol.setShadow(10,0.3,(Color)ColorConverter.ConvertFromString("#ff7f7f7f"));
            fsPol.removeBorder();
		}

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
        /// This method called when the "One Off Donation" button has been clicked
        /// </summary>
        /// <param name="sender"> the button that has been clicked</param>
        /// <param name="e"></param>
        private void scholarship_Click(object sender, RoutedEventArgs e)
        {

            // set image
            fsPol.setImage("images\\KidWithHat.png");

            //remove drop shadow from other buttons
            ResetBtnEffects();
            //Set the colour of the scholarship btn to be selected
            scholarship.Background = sel;
            //add drop shadow
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            scholarship.Effect = dShdow; 

            text.Content = scholarshipContent();
        }

        private void schol_TouchDown(object sender, TouchEventArgs e)
        {
            // set image
            fsPol.setImage("images\\KidWithHat.png");

            //remove drop shadow from other buttons
            ResetBtnEffects();
            //Set the colour of the scholarship btn to be selected
            scholarship.Background = sel;
            //add drop shadow
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            scholarship.Effect = dShdow;

            text.Content = scholarshipContent();
        }
        /// <summary>
        /// the helper method to generate the content when the "One Off Donation" has been clicked
        /// </summary>
        /// <returns></returns>
        private StackPanel scholarshipContent()
        {
            //Set content to one off donation
            StackPanel contentStackPanel = new StackPanel();

            TextBlock scholarshipText = new TextBlock();
            scholarshipText.TextAlignment = TextAlignment.Left;
            scholarshipText.FontSize = Util.contentTextSize;
            scholarship.FontFamily = Util.contentTextFont;
            scholarshipText.Margin = new Thickness(10);
            scholarshipText.Foreground = new SolidColorBrush(Util.contentTextColor);
            scholarshipText.Inlines.Add(new Bold(new Run("Scholarships \n")));
            scholarshipText.Inlines.Add(new Run("The Child Cancer Foundation Scholarship Fund aims to assist children aged 0 to 12 years with cancer, their siblings aged 0 to 12 years, or parents, achieve their personal education and developmental goals. Any activity that has the potential to educationally or developmentally benefit the applicant will be considered.\n"));
            scholarshipText.Inlines.Add(new Run("The Scholarship sub-committee, which meets four times a year, receives and considers all applications. Allocations made depend on the funds available and are made according to the policy guidelines of the Child Cancer Foundation.\n"));
            scholarshipText.Inlines.Add(new Run("All application enquiries should be directed to your local Family Support Coordinator.\nFor administration support please contact:\n"));
            scholarshipText.Inlines.Add(new Bold(new Run("Alison O'Connor  PHN ")));
            scholarshipText.Inlines.Add(new Run("(04) 389 2620 or "));
            scholarshipText.Inlines.Add(new Bold(new Run("email ")));
            scholarshipText.Inlines.Add(new Run("aoconnor@childcancer.org.nz\n"));


            contentStackPanel.Children.Add(scholarshipText);
            return contentStackPanel;
        }


        /// <summary>
        /// This method called when the "On Going Donation" button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pResources_Click(object sender, RoutedEventArgs e)
        {
            // set image
            fsPol.setImage("images\\MotherandChild.png");

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

        private void pRes_TouchDown(object sender, TouchEventArgs e)
        {
            // set image
            fsPol.setImage("images\\MotherandChild.png");

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
        /// This method called when the "Workplace Giving" button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hHomes_Click(object sender, RoutedEventArgs e)
        {
            // set image
            fsPol.setImage("images\\SmilingRelative.png");

            //Set the background colours of the buttons
            ResetBtnEffects();
            //Set holiday homes to be selected
            hHomes.Background = sel;

            //add drop shadow
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            hHomes.Effect = dShdow; 

            // set the content of the textbox
            text.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00000000"));
            text.Content = hHomesContent();
            text.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
        }

        private void hHomes_TouchDown(object sender, TouchEventArgs e)
        {
            fsPol.setImage("images\\SmilingRelative.png");

            //Set the background colours of the buttons
            ResetBtnEffects();
            //Set holiday homes to be selected
            hHomes.Background = sel;

            //add drop shadow
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            hHomes.Effect = dShdow;

            // set the content of the textbox
            text.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00000000"));
            text.Content = hHomesContent();
            text.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
        }

        private void taupo_MouseUp(object sender, MouseButtonEventArgs e)
        {

            hhscroll.Content = taupoContent();
            ((PoloroidControl)hawkesbay.Content).removeGlow();
            ((PoloroidControl)arrowtown.Content).removeGlow();
            ((PoloroidControl)taupo.Content).setGlow();

        }

        private void arrowtown_MouseUp(object sender, MouseButtonEventArgs e)
        {
            hhscroll.Content = arrowtownContent();

            ((PoloroidControl)hawkesbay.Content).removeGlow();
            ((PoloroidControl)arrowtown.Content).setGlow();
            ((PoloroidControl)taupo.Content).removeGlow();


        }

        private void hawkesBay_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
            hhscroll.Content = hawkesBayContent();
            ((PoloroidControl)hawkesbay.Content).setGlow();
            ((PoloroidControl)arrowtown.Content).removeGlow();
            ((PoloroidControl)taupo.Content).removeGlow();

        }

        /// <summary>
        /// This method called when the "More Information" button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cList_Click(object sender, RoutedEventArgs e)
        {
            // set image
            fsPol.setImage("images\\TwoGirls.png");

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
            text.Content = cListContent();
        }

        private void cList_TouchDown(object sender, TouchEventArgs e)
        {
            // set image
            fsPol.setImage("images\\TwoGirls.png");

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
            text.Content = cListContent();
        }
        /// <summary>
        /// the helper method to generate the content when the "More Information" has been clicked
        /// </summary>
        /// <returns></returns>
        private StackPanel cListContent()
        {
            //Set content to on going donation
            StackPanel contentStackPanel = new StackPanel();


            var provider = new ApplicationIdCredentialsProvider("AtabbySpgE9zdS1c5C4Pp1FHWjbxM_nHqIBmfZ--pFwtM0Vddbw7-bfUMBW-FBao");

            // Set up the Bing map control
            map = new Map();
            map.Mode = new AerialMode(labels: true);
            map.CredentialsProvider = provider;
            map.HorizontalAlignment = HorizontalAlignment.Stretch;
            map.VerticalAlignment = VerticalAlignment.Stretch;
            map.Center = new Location(-41, 174);
            map.ZoomLevel = 6.0;
            // Render the map control over the top of the loading text in the map panel
            //MapPanel.Children.Add(map);
            //MapControl map = new MapControl();
            map.Height = 550;

            // The pushpin to add to the map.
            aucklandPin = new Pushpin();
            aucklandPin.Location = new Location(-36.843880, 174.767746);

            // Adds the pushpin to the map.
            map.Children.Add(aucklandPin);

            // The pushpin to add to the map.
            christchurchPin = new Pushpin();
            christchurchPin.Location = new Location(-43.531010,172.637787);

            // Adds the pushpin to the map.
            map.Children.Add(christchurchPin);

            // The pushpin to add to the map.
            dunedinPin = new Pushpin();
            dunedinPin.Location = new Location(-45.873489,170.503967);

            // Adds the pushpin to the map.
            map.Children.Add(dunedinPin);
            // The pushpin to add to the map.
            wellingtonPin = new Pushpin();
            wellingtonPin.Location = new Location(-41.288940,174.776276);

            // Adds the pushpin to the map.
            map.Children.Add(wellingtonPin);


            map.AddHandler(UIElement.TouchDownEvent, new EventHandler<TouchEventArgs>(MapWithPushpins_TouchDown), true);
            map.AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(MapWithPushpins_MouseDown), true);
            
            mscroll = new SurfaceScrollViewer();
            //scroll.Width = 850;
            mscroll.Height = 300;
            mscroll.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4fffffff"));


            TextBlock prompt = new TextBlock();
            prompt.TextAlignment = TextAlignment.Center;
            prompt.FontSize = Util.contentTextSize;
            prompt.Margin = new Thickness(10);
            prompt.FontFamily = Util.contentTextFont;
            prompt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff707070"));
            prompt.Inlines.Add(new Run("Click on the pins to see their contact information\n"));

            mscroll.Content = prompt;

            contentStackPanel.Children.Add(map);
            contentStackPanel.Children.Add(mscroll);

            mscroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            mscroll.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            
            //TextBlock pResourcesText1 = new TextBlock();
            //pResourcesText1.TextAlignment = TextAlignment.Left;
            //pResourcesText1.FontSize = Util.contentTextSize;
            //pResourcesText1.Margin = new Thickness(10);
            //pResourcesText1.FontFamily = Util.contentTextFont;
            //pResourcesText1.Foreground = new SolidColorBrush(Util.contentTextColor);
            //pResourcesText1.Inlines.Add(new Bold(new Run("More Information \n")));
            //pResourcesText1.Inlines.Add(new Run("If you are ready to write your will, visit http://www.childcancer.org.nz/getattachment/How-you-can-help/fsPol/Bequest.pdf.aspx for some official wording to assist you. \n\n"));
            //pResourcesText1.Inlines.Add(new Run("Thank you so much for considering leaving a gift to Child Cancer Foundation in your will. If you do decide to leave a legacy or bequest to help support our Child Cancer services, please let us know as this will allow us to thank you for your gift and offer you a closer relationship with us. It does not, however, legally bind you to support us in any way and the information will be treated in the strictest of confidence. \n\n"));

            //pResourcesText1.Inlines.Add(new Run("For more information please contact:  \n\n"));
            //pResourcesText1.Inlines.Add(new Bold(new Run("Darragh O'Riordan PHN ")));
            //pResourcesText1.Inlines.Add(new Run("09 303 9882 | "));
            //pResourcesText1.Inlines.Add(new Bold(new Run("EML ")));
            //pResourcesText1.Inlines.Add(new Run("doriordan@childcancer.org.nz\n"));
            // Load the application Id credentials required for the Bing map
            
            return contentStackPanel;
        }


        private void MapWithPushpins_TouchDown(object sender, TouchEventArgs e)
        {
            // Disables the default touch down behavior.
            e.Handled = true;

            // Determine the location to place the pushpin at on the map.

            //Get the touch down coordinates
            TouchPoint touchPosition = e.GetTouchPoint(this);
            //Convert the mouse coordinates to a location on the map
            Location pinLocation = map.ViewportPointToLocation(touchPosition.Position);
            double auckdist = Math.Sqrt(Math.Pow(aucklandPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(aucklandPin.Location.Longitude - pinLocation.Longitude, 2));
            double chchdist = Math.Sqrt(Math.Pow(christchurchPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(christchurchPin.Location.Longitude - pinLocation.Longitude, 2));
            double dundist = Math.Sqrt(Math.Pow(dunedinPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(dunedinPin.Location.Longitude - pinLocation.Longitude, 2));
            double welldist = Math.Sqrt(Math.Pow(wellingtonPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(wellingtonPin.Location.Longitude - pinLocation.Longitude, 2));
            if (auckdist > -1 && auckdist < 1)
            {
                mscroll.Content = aucklandContent();
            }else if(chchdist > -1 && chchdist < 1){
                mscroll.Content = christchurchContent();
            }else if(dundist > -1 && dundist < 1){
                mscroll.Content = dunedinContent();
            }
            else if (welldist > -1 && welldist < 1)
            {
                mscroll.Content = wellingtonContent();
            }
          
            // Adds the pushpin to the map.
            //map.Children.Add(pin);
        }

        private void MapWithPushpins_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Disables the default touch down behavior.
            e.Handled = true;

            // Determine the location to place the pushpin at on the map.

            //Get the touch down coordinates
            Point touchPosition = e.GetPosition(this);
            //Convert the mouse coordinates to a location on the map
            Location pinLocation = map.ViewportPointToLocation(touchPosition);
            double auckdist = Math.Sqrt(Math.Pow(aucklandPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(aucklandPin.Location.Longitude - pinLocation.Longitude, 2));
            double chchdist = Math.Sqrt(Math.Pow(christchurchPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(christchurchPin.Location.Longitude - pinLocation.Longitude, 2));
            double dundist = Math.Sqrt(Math.Pow(dunedinPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(dunedinPin.Location.Longitude - pinLocation.Longitude, 2));
            double welldist = Math.Sqrt(Math.Pow(wellingtonPin.Location.Latitude - pinLocation.Latitude, 2) + Math.Pow(wellingtonPin.Location.Longitude - pinLocation.Longitude, 2));
            if (auckdist > -10 && auckdist < 10)
            {
                mscroll.Content = aucklandContent();
            }
            else if (chchdist > -10 && chchdist < 10)
            {
                mscroll.Content = christchurchContent();
            }
            else if (dundist > -10 && dundist < 10)
            {
                mscroll.Content = dunedinContent();
            }
            else if (welldist > -10 && welldist < 10)
            {
                mscroll.Content = wellingtonContent();
            }

            // Adds the pushpin to the map.
            //map.Children.Add(pin);
        }
        /// <summary>
        /// the helper method to generate the content when the "On Going Donation" has been clicked
        /// </summary>
        /// <returns></returns>
        private StackPanel pResourcesContent()
        {
            //Set content to on going donation
            StackPanel contentStackPanel = new StackPanel();
            
            TextBlock pResourcesText1 = new TextBlock();
            pResourcesText1.TextAlignment = TextAlignment.Left;
            pResourcesText1.FontSize = Util.contentTextSize;
            pResourcesText1.FontFamily = Util.contentTextFont;
            pResourcesText1.Margin = new Thickness(10);
            pResourcesText1.Foreground = new SolidColorBrush(Util.contentTextColor);
            pResourcesText1.Inlines.Add(new Bold(new Run("Parent Resources \n")));
            pResourcesText1.Inlines.Add(new Run("Child Cancer Foundation aims to provide up-to-date information for families. Below is a list of websites providing additional information, research documents and details about child cancer from around the world.\n\n"));

            pResourcesText1.Inlines.Add(new Bold(new Run("Kidscope\n")));
            pResourcesText1.Inlines.Add(new Run("www.kidscope.org\nAn organization which has been formed to help families and children better understand the effects of cancer and chemotherapy.\n\n"));

            pResourcesText1.Inlines.Add(new Bold(new Run("CancerCare, Inc.\n")));
            pResourcesText1.Inlines.Add(new Run("www.cancercareinc.org\n\n"));

            pResourcesText1.Inlines.Add(new Bold(new Run("Chemo Kids\n")));
            pResourcesText1.Inlines.Add(new Run("http://www.chemo4kids.com/cancer-resources/\nThis site offers simplified information about chemotherapy and its use to treat cancer.\n\n"));

            pResourcesText1.Inlines.Add(new Bold(new Run("Candlelighters\n")));
            pResourcesText1.Inlines.Add(new Run("www.candlelighters.org/ \nThe Candlelighters mission is to educate, support, serve, and advocate for families of children with cancer, survivors of childhood cancer and professionals who care for them.\n\n"));

            pResourcesText1.Inlines.Add(new Bold(new Run("ACT\n")));
            pResourcesText1.Inlines.Add(new Run("www.act.org.uk \nThe site of the Association for Children with life-threatening or terminal conditions and their families. This site is in the process of redevelopment and will include access to a web-based research journal called LitpaedpalLit.\n\n"));
            
            pResourcesText1.Inlines.Add(new Bold(new Run("International Confederation of Child Cancer Parent Organisations\n")));
            pResourcesText1.Inlines.Add(new Run("www.icccpo.org\n\n"));

            pResourcesText1.Inlines.Add(new Bold(new Run("Action for Children and Youth in Aotearoa\n")));
            pResourcesText1.Inlines.Add(new Run("www.acya.org.nz \nThis site has many excellent documents relating to areas of rights of children and youth.\n\n"));
            
            contentStackPanel.Children.Add(pResourcesText1);
            return contentStackPanel;
        }

        /// <summary>
        /// the helper method to generate the content when the "Workplac Giving" has been clicked
        /// </summary>
        /// <returns></returns>
        private StackPanel hHomesContent()
        {
            //h = 1046, w = 860
            //Set content to on going donation
            StackPanel contentStackPanel = new StackPanel();
            scatter = new ScatterView();
            //scatter.Width = 850;
            scatter.Height = 500;
            scatter.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7fffffff"));

            hhscroll = new SurfaceScrollViewer();
            //scroll.Width = 850;
            hhscroll.Height = 300;
            hhscroll.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4fffffff"));

            
            TextBlock prompt = new TextBlock();
            prompt.TextAlignment = TextAlignment.Center;
            prompt.FontSize = Util.contentTextSize;
            prompt.Margin = new Thickness(10);
            prompt.FontFamily = Util.contentTextFont;
            prompt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff707070"));
            prompt.Inlines.Add(new Run("Click on the images below to see information or use two fingers to zoom\n"));
    
            contentStackPanel.Children.Add(prompt);
            contentStackPanel.Children.Add(scatter);
            contentStackPanel.Children.Add(hhscroll);

            hhscroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            hhscroll.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            arrowtown = new ScatterViewItem();
            arrowtown.Content = new PoloroidControl("images/arrowtown.jpg","",(Color)ColorConverter.ConvertFromString("#00000000"));
            (arrowtown.Content as PoloroidControl).removeBorder();
            arrowtown.Height = 200;
            arrowtown.Width = 300;
            arrowtown.AddHandler(UIElement.MouseUpEvent, new MouseButtonEventHandler(arrowtown_MouseUp),true);
            scatter.Items.Add(arrowtown);

            taupo = new ScatterViewItem();
            taupo.Content = new PoloroidControl("images/taupo.jpg", "", (Color)ColorConverter.ConvertFromString("#00000000"));
            (taupo.Content as PoloroidControl).removeBorder();
            taupo.Height = 200;
            taupo.Width = 300;
            taupo.AddHandler(UIElement.MouseUpEvent, new MouseButtonEventHandler(taupo_MouseUp), true);
            scatter.Items.Add(taupo);

            hawkesbay = new ScatterViewItem();
            hawkesbay.Content = new PoloroidControl("images/hawkesBay.jpg", "", (Color)ColorConverter.ConvertFromString("#00000000"));
            (hawkesbay.Content as PoloroidControl).removeBorder();
            hawkesbay.Height = 200;
            hawkesbay.Width = 300;
            hawkesbay.AddHandler(UIElement.MouseUpEvent, new MouseButtonEventHandler(hawkesBay_MouseUp), true);
            scatter.Items.Add(hawkesbay);

            hawkesBay_MouseUp(null,null);
            return contentStackPanel;
        }

        private StackPanel taupoContent() {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock taupoText = new TextBlock();
            taupoText.TextAlignment = TextAlignment.Left;
            taupoText.FontSize = Util.contentTextSize;
            taupoText.FontFamily = Util.contentTextFont;
            taupoText.Margin = new Thickness(10);
            taupoText.Foreground = new SolidColorBrush(Util.contentTextColor);
            taupoText.Inlines.Add(new Bold(new Run("Taupo Sunshine Lodge Holiday Home \n")));
            taupoText.Inlines.Add(new Run("Child Cancer Foundation has a Sunshine Lodge holiday home in Taupo.The Lockwood house offers three-bedrooms, a bathroom and is fully furnished.\n\n"));
            //taupoText.Inlines.Add(new Run("The Foundation has been able to provide families with this opportunity through the generosity of the Professionals Real Estate Group who have funded and maintained the Taupo home. The Foundation is grateful for the ongoing partnership with the Professionals in working together to meet the needs of children with cancer and their families. The Professionals are a Gold Star sponsor supporting our nationwide holiday service. Professionals have supported The Child Cancer Foundation for 16 years, raising over $3.4 million.\n\n"));
            taupoText.Inlines.Add(new Run("If your family would like to book a holiday home please contact:\nMelissa Walker | PHN 03 365 1485 | EML mwalker@childcancer.org.nz\n"));
            contentStackPanel.Children.Add(taupoText);
            return contentStackPanel;
        }

        private StackPanel arrowtownContent() {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock taupoText = new TextBlock();
            taupoText.TextAlignment = TextAlignment.Left;
            taupoText.FontSize = Util.contentTextSize;
            taupoText.FontFamily = Util.contentTextFont;
            taupoText.Margin = new Thickness(10);
            taupoText.Foreground = new SolidColorBrush(Util.contentTextColor);
            taupoText.Inlines.Add(new Bold(new Run("Arrowtown \n")));
            taupoText.Inlines.Add(new Run("The new Child Cancer Foundation Arrowtown Holiday Home was officially opened in June, 2012.The new Arrowfield Mews property is a three bedroom, two bathroom, two storey, well insulated and sunny house, well suited to the requirement of CCF families. The house is walking distance from the main Arrowtown shopping / entertainment area, close to public transport and opposite the Millbrook golf course.\n\n"));
            //taupoText.Inlines.Add(new Run("The house is owned by Child Cancer Foundation Otago/Southland Accommodation Trust, (OSAT). The trust was set up in the 1980s to provide accommodation for Otago and Southland children with cancer and their families. Funds provided for the house have been donated by individuals and businesses throughout Otago/Southland over a long period of time. \n\n"));
            taupoText.Inlines.Add(new Run("If your family would like to book a holiday home please contact:\nMelissa Walker | PHN 03 365 1485 | EML mwalker@childcancer.org.nz\n"));
            contentStackPanel.Children.Add(taupoText);
            return contentStackPanel;
        }

        private StackPanel hawkesBayContent() {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock taupoText = new TextBlock();
            taupoText.TextAlignment = TextAlignment.Left;
            taupoText.FontSize = Util.contentTextSize;
            taupoText.FontFamily = Util.contentTextFont;
            taupoText.Margin = new Thickness(10);
            taupoText.Foreground = new SolidColorBrush(Util.contentTextColor);
            taupoText.Inlines.Add(new Bold(new Run("Hawkes Bay Little Elms \n")));
            taupoText.Inlines.Add(new Run("The Trucking for Hawkes Bay Child Cancer Trust owns and manages the Little Elms complex in Orchard Road, Hastings, Hawkes Bay. Families of child cancer patients from around the country are able to use the holiday house to have some much needed “time out”. The Holiday house offers three-bedrooms, two-bathrooms and is fully furnished.\n\n"));
            //taupoText.Inlines.Add(new Run("Child Cancer Foundation is grateful to the dedicated truckers and sponsors in the Hawkes Bay region for providing this facility.\n\n"));
            taupoText.Inlines.Add(new Run("If your family would like to book a holiday home please contact:\nMelissa Walker | PHN 03 365 1485 | EML mwalker@childcancer.org.nz\n"));
            contentStackPanel.Children.Add(taupoText);
            return contentStackPanel;
        }

        private StackPanel aucklandContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock taupoText = new TextBlock();
            taupoText.TextAlignment = TextAlignment.Left;
            taupoText.FontSize = Util.contentTextSize;
            taupoText.FontFamily = Util.contentTextFont;
            taupoText.Margin = new Thickness(10);
            taupoText.Foreground = new SolidColorBrush(Util.contentTextColor);
            taupoText.Inlines.Add(new Bold(new Run("Family Support - Auckland﻿ \n")));
            taupoText.Inlines.Add(new Run("Janet Masina	 \n(09) 303 9885	jmasina@childcancer.org.nz\n\nMary Mangan	 \n(09) 303 9971	mmangan@childcancer.org.nz\n"));
            contentStackPanel.Children.Add(taupoText);
            return contentStackPanel;
        }

        private StackPanel dunedinContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock taupoText = new TextBlock();
            taupoText.TextAlignment = TextAlignment.Left;
            taupoText.FontSize = Util.contentTextSize;
            taupoText.FontFamily = Util.contentTextFont;
            taupoText.Margin = new Thickness(10);
            taupoText.Foreground = new SolidColorBrush(Util.contentTextColor);
            taupoText.Inlines.Add(new Bold(new Run("Family Support - Dunedin﻿ \n")));
            taupoText.Inlines.Add(new Run("Christine Donovan	\n(03) 471 7258	cdonovan@childcancer.org.nz\n"));
            contentStackPanel.Children.Add(taupoText);
            return contentStackPanel;
        }

        private StackPanel christchurchContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock taupoText = new TextBlock();
            taupoText.TextAlignment = TextAlignment.Left;
            taupoText.FontSize = Util.contentTextSize;
            taupoText.FontFamily = Util.contentTextFont;
            taupoText.Margin = new Thickness(10);
            taupoText.Foreground = new SolidColorBrush(Util.contentTextColor);
            taupoText.Inlines.Add(new Bold(new Run("Family Support - Christchurch \n")));
            taupoText.Inlines.Add(new Run("Christine Graham	 \n(03) 365 1485	cgraham@childcancer.org.nz\n\nDiane Kerr\n021 838 142	dkerr@childcancer.org.nz\n"));
            contentStackPanel.Children.Add(taupoText);
            return contentStackPanel;
        }

        private StackPanel wellingtonContent()
        {
            StackPanel contentStackPanel = new StackPanel();

            TextBlock taupoText = new TextBlock();
            taupoText.TextAlignment = TextAlignment.Left;
            taupoText.FontSize = Util.contentTextSize;
            taupoText.FontFamily = Util.contentTextFont;
            taupoText.Margin = new Thickness(10);
            taupoText.Foreground = new SolidColorBrush(Util.contentTextColor);
            taupoText.Inlines.Add(new Bold(new Run("Family Support - Wellington \n")));
            taupoText.Inlines.Add(new Run("Sally Black\n(04) 389 2620	sblack@childcancer.org.nz\n\nTracy Ward	 \n(04) 389 2620	tward@childcancer.org.nz\n"));
            contentStackPanel.Children.Add(taupoText);
            return contentStackPanel;
        }

	}
}