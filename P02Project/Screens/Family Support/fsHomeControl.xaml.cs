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
        private SurfaceScrollViewer scroll;

        private ScatterViewItem arrowtown;
        private ScatterViewItem taupo;
        private ScatterViewItem hawkesbay;

        /// <summary>
        /// Constructor
        /// </summary>
		public fsHomeControl()
		{
			this.InitializeComponent();
            
            sel = new SolidColorBrush(Util._pageColDict["fsSelected"]);
            unsel = new SolidColorBrush(Util._pageColDict["fsUnSelected"]);

            scholarship_Click(null, null);
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
            scholarship.Effect = new DropShadowEffect(); 

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
            scholarship.Effect = new DropShadowEffect();

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
            scholarshipText.FontSize = 24;
            scholarshipText.Margin = new Thickness(10);
            scholarshipText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff000000"));
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
            pResources.Effect = new DropShadowEffect(); 

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
            pResources.Effect = new DropShadowEffect();

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
            hHomes.Effect = new DropShadowEffect(); 

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
            hHomes.Effect = new DropShadowEffect();

            // set the content of the textbox
            text.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00000000"));
            text.Content = hHomesContent();
            text.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
        }

        private void taupo_MouseUp(object sender, MouseButtonEventArgs e)
        {

            scroll.Content = taupoContent();
            ((PoloroidControl)hawkesbay.Content).removeGlow();
            ((PoloroidControl)arrowtown.Content).removeGlow();
            ((PoloroidControl)taupo.Content).setGlow();

        }

        private void arrowtown_MouseUp(object sender, MouseButtonEventArgs e)
        {
            scroll.Content = arrowtownContent();

            ((PoloroidControl)hawkesbay.Content).removeGlow();
            ((PoloroidControl)arrowtown.Content).setGlow();
            ((PoloroidControl)taupo.Content).removeGlow();


        }

        private void hawkesBay_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
            scroll.Content = hawkesBayContent();
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
            cList.Effect = new DropShadowEffect();

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
            cList.Effect = new DropShadowEffect();

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

            TextBlock pResourcesText1 = new TextBlock();
            pResourcesText1.TextAlignment = TextAlignment.Left;
            pResourcesText1.FontSize = 24;
            pResourcesText1.Margin = new Thickness(10);
            pResourcesText1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff000000"));
            pResourcesText1.Inlines.Add(new Bold(new Run("More Information \n")));
            pResourcesText1.Inlines.Add(new Run("If you are ready to write your will, visit http://www.childcancer.org.nz/getattachment/How-you-can-help/fsPol/Bequest.pdf.aspx for some official wording to assist you. \n\n"));
            pResourcesText1.Inlines.Add(new Run("Thank you so much for considering leaving a gift to Child Cancer Foundation in your will. If you do decide to leave a legacy or bequest to help support our Child Cancer services, please let us know as this will allow us to thank you for your gift and offer you a closer relationship with us. It does not, however, legally bind you to support us in any way and the information will be treated in the strictest of confidence. \n\n"));

            pResourcesText1.Inlines.Add(new Run("For more information please contact:  \n\n"));
            pResourcesText1.Inlines.Add(new Bold(new Run("Darragh O'Riordan PHN ")));
            pResourcesText1.Inlines.Add(new Run("09 303 9882 | "));
            pResourcesText1.Inlines.Add(new Bold(new Run("EML ")));
            pResourcesText1.Inlines.Add(new Run("doriordan@childcancer.org.nz\n"));

            contentStackPanel.Children.Add(pResourcesText1);
            return contentStackPanel;
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
            pResourcesText1.FontSize = 24;
            pResourcesText1.Margin = new Thickness(10);
            pResourcesText1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff000000"));
            pResourcesText1.Inlines.Add(new Bold(new Run("Parent Resources \n")));
            pResourcesText1.Inlines.Add(new Run("Child Cancer Foundation aims to provide up-to-date information for families. Below is a list of websites providing additional information, research documents and details about child cancer from around the world.\n\n"));

            pResourcesText1.Inlines.Add(new Bold(new Run("Kidscope\n")));
            pResourcesText1.Inlines.Add(new Run("www.kidscope.org\nAn organization which has been formed to help families and children better understand the effects of cancer and chemotherapy.\n\n"));

            pResourcesText1.Inlines.Add(new Bold(new Run("CancerCare, Inc.\n")));
            pResourcesText1.Inlines.Add(new Run("www.cancercareinc.org\n\n"));

            pResourcesText1.Inlines.Add(new Bold(new Run("Chemo Kids\n")));
            pResourcesText1.Inlines.Add(new Run("http://www.chemo4kids.com/cancer-resources/\nThis site offers simplified information about chemotherapy and its use to treat cancer.\new\n"));

            pResourcesText1.Inlines.Add(new Bold(new Run("Candlelighters\n")));
            pResourcesText1.Inlines.Add(new Bold(new Run("www.candlelighters.org/ \nThe Candlelighters mission is to educate, support, serve, and advocate for families of children with cancer, survivors of childhood cancer and professionals who care for them.\n\n")));

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

            scroll = new SurfaceScrollViewer();
            //scroll.Width = 850;
            scroll.Height = 300;
            scroll.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4fffffff"));

            
            TextBlock prompt = new TextBlock();
            prompt.TextAlignment = TextAlignment.Center;
            prompt.FontSize = 24;
            prompt.Margin = new Thickness(10);
            prompt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff707070"));
            prompt.Inlines.Add(new Run("Click on the images below to see information or use two fingers to zoom\n"));
    
            contentStackPanel.Children.Add(prompt);
            contentStackPanel.Children.Add(scatter);
            contentStackPanel.Children.Add(scroll);

            scroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            scroll.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            arrowtown = new ScatterViewItem();
            arrowtown.Content = new PoloroidControl("images/arrowtown.jpg","",(Color)ColorConverter.ConvertFromString("#00000000"));
            arrowtown.Height = 200;
            arrowtown.Width = 300;
            arrowtown.AddHandler(UIElement.MouseUpEvent, new MouseButtonEventHandler(arrowtown_MouseUp),true);
            scatter.Items.Add(arrowtown);

            taupo = new ScatterViewItem();
            taupo.Content = new PoloroidControl("images/taupo.jpg", "", (Color)ColorConverter.ConvertFromString("#00000000"));
            taupo.Height = 200;
            taupo.Width = 300;
            taupo.AddHandler(UIElement.MouseUpEvent, new MouseButtonEventHandler(taupo_MouseUp), true);
            scatter.Items.Add(taupo);

            hawkesbay = new ScatterViewItem();
            hawkesbay.Content = new PoloroidControl("images/hawkesBay.jpg", "", (Color)ColorConverter.ConvertFromString("#00000000"));
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
            taupoText.FontSize = 24;
            taupoText.Margin = new Thickness(10);
            taupoText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff000000"));
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
            taupoText.FontSize = 24;
            taupoText.Margin = new Thickness(10);
            taupoText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff000000"));
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
            taupoText.FontSize = 24;
            taupoText.Margin = new Thickness(10);
            taupoText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff000000"));
            taupoText.Inlines.Add(new Bold(new Run("Hawkes Bay Little Elms \n")));
            taupoText.Inlines.Add(new Run("The Trucking for Hawkes Bay Child Cancer Trust owns and manages the Little Elms complex in Orchard Road, Hastings, Hawkes Bay. Families of child cancer patients from around the country are able to use the holiday house to have some much needed “time out”. The Holiday house offers three-bedrooms, two-bathrooms and is fully furnished.\n\n"));
            //taupoText.Inlines.Add(new Run("Child Cancer Foundation is grateful to the dedicated truckers and sponsors in the Hawkes Bay region for providing this facility.\n\n"));
            taupoText.Inlines.Add(new Run("If your family would like to book a holiday home please contact:\nMelissa Walker | PHN 03 365 1485 | EML mwalker@childcancer.org.nz\n"));
            contentStackPanel.Children.Add(taupoText);
            return contentStackPanel;
        }


	}
}