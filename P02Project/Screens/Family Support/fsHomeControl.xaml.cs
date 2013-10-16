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
            supService.Background = unsel;
            hHomes.Background = unsel;
            cList.Background = unsel;

            scholarship.Effect = null;
            pResources.Effect = null;
            supService.Effect = null;
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

        /// <summary>
        /// This method called when the "Lasting Legacy" button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supService_Click(object sender, RoutedEventArgs e)
        {
            // set image
            fsPol.setImage("images\\Beads1.png");

            //Set the background colours of the buttons
            ResetBtnEffects();
            //Set sup service to be selected
            supService.Background = sel;
            //add drop shadow
            supService.Effect = new DropShadowEffect(); 

            // set the content of the text box
            text.Content = supServiceContent();
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
            text.Content = hHomesContent();
            text.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
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



        /// <summary>
        /// the helper method to generate the content when the "One Off Donation" has been clicked
        /// </summary>
        /// <returns></returns>
        private StackPanel scholarshipContent() {
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
        /// the helper method to generate the content when the "Lasting Legacy" has been clicked
        /// </summary>
        /// <returns></returns>
        private StackPanel supServiceContent()
        {
            //Set content to on going donation
            StackPanel contentStackPanel = new StackPanel();

            TextBlock supServiceText = new TextBlock();
            supServiceText.TextAlignment = TextAlignment.Left;
            supServiceText.FontSize = 24;
            supServiceText.Margin = new Thickness(10);
            supServiceText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff000000"));
            supServiceText.Inlines.Add(new Bold(new Run("Support Services\n")));
            supServiceText.Inlines.Add(new Run("Our Family Support team work in conjunction with the foundation’s branch members (parents, caregivers, and volunteers) to deliver a range of support services to ensure every child and their family walking the child cancer journey will never feel alone.\n"));
            supServiceText.Inlines.Add(new Run("Our Family Support Coordinators provide support to children and their families in hospital, at home, and in the community. They offer individual and group support, information, financial assistance, and advocacy. Our Coordinators also offer support for bereaved families. They connect similar families and provide a link to other agencies and community support groups.\n"));
            supServiceText.Inlines.Add(new Run(" We offer children with cancer the Beads of Courage®, a registered, therapeutic programme of the Child Cancer Foundation. The programme provides a physical story of a child’s journey recognising their strength and courage during cancer treatments and procedures. Each bead represents a treatment (for example chemotherapy, injections, scans); an experience (hair loss, isolation, fever) or milestone (completion of treatment). The Sibling Beads Programme offers special siblings the opportunity to earn beads by displaying positive behaviour and helpful attitudes to assist their family.\n"));
            supServiceText.Inlines.Add(new Run(" Our 22 voluntary branches comprised of parents, caregivers, and volunteers nationwide host regular social activities to connect families. Parent volunteers offer mutual support and shared experiences.\n"));
            supServiceText.Inlines.Add(new Run("Families are informed and linked nationwide by receiving the “Sharing Magazine,” a publication produced by the foundation three times annually. Families can also access our Family Places (Auckland, Wellington, Christchurch and Dunedin) – day centres where local children and their families, as well as those away from their home towns for treatment, can relax and source information and support from our Coordinators. Our holiday homes (Taupo and Arrowtown) offer families quality time together away from the stressors of the treatment journey or to celebrate a milestone.\n"));
            supServiceText.Inlines.Add(new Run("We offer a Scholarship Programme to assist children with cancer, their siblings, and parents to reach their potential and not be disadvantaged by their cancer journey.\n"));
            
            contentStackPanel.Children.Add(supServiceText);
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
           ScatterView scatter = new ScatterView();
            //scatter.Width = 850;
            scatter.Height = 540;
            scatter.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff000000"));

            SurfaceScrollViewer scroll = new SurfaceScrollViewer();
            //scroll.Width = 850;
            scroll.Height = 300;
            scroll.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffff0000"));

            StackPanel textStackPanel = new StackPanel();
            TextBlock hHomesText1 = new TextBlock();
            hHomesText1.TextAlignment = TextAlignment.Left;
            hHomesText1.FontSize = 24;
            hHomesText1.Margin = new Thickness(10);
            hHomesText1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff000000"));
            hHomesText1.Inlines.Add(new Bold(new Run("Workplace Giving \n")));
            hHomesText1.Inlines.Add(new Run("Workplace giving is a wonderful opportunity for you as an employee to give a regular donation to Child Cancer Foundation from your salary.  It is a simple process organised through your company with your chosen donation amount transfered from your salary to Child Cancer Foundation each pay period eliminating any need to retain tax receipts for each donation. \n\n"));
            hHomesText1.Inlines.Add(new Run("Choose Child Cancer Foundation as your charity of choice at your workplace, and encouraging your co-workers to do the same. It is an easy way for you to support children with cancer and their families. \n\n"));
            hHomesText1.Inlines.Add(new Run("For more information on workplace giving please contact:  \n\n"));
            hHomesText1.Inlines.Add(new Bold(new Run("Sophie Armitage PHN ")));
            hHomesText1.Inlines.Add(new Run("09 303 9972 | "));
            hHomesText1.Inlines.Add(new Bold(new Run("EML ")));
            hHomesText1.Inlines.Add(new Run("sarmitage@childcancer.org.nz\n"));

            contentStackPanel.Children.Add(scatter);
            contentStackPanel.Children.Add(scroll);

            textStackPanel.Children.Add(hHomesText1);
            scroll.Content = textStackPanel;
            scroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            scroll.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            ScatterViewItem item = new ScatterViewItem();
            item.Content = new PoloroidControl("images/TwoGirls.png","",(Color)ColorConverter.ConvertFromString("#00000000"));
            item.Height = 100;
            item.Width = 100;
            scatter.Items.Add(item);

            return contentStackPanel;
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
	}
}