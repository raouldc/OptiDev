using System;
using System.Collections.Generic;
using System.Linq;
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
using P02Project.Resources.xml;

namespace P02Project.Screens
{
    /// <summary>
    /// Interaction logic for FSPage.xaml
    /// </summary>
    public partial class FSPage : UserControl
    {
        public FSPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="filename"></param>
        public FSPage(String filename)
        {
            InitializeComponent();

            //TODO: Set title and subtitle
            PageModel temp;
            String path = System.IO.Path.Combine(System.IO.Path.GetFullPath("."), "Resources/xml/FamilySupport.xml");
            temp = XMLUtilities.GetContentFromFile(path);
            Dictionary<String,PoloroidControl> dictOfPolatiods = new Dictionary<String,PoloroidControl>();

            // initialize the dictionary to store all the polaroids that appear on this page
            dictOfPolatiods.Add("Parent Resources",ParentResourcesPolaroid);
            dictOfPolatiods.Add("Support Services",SupportServicesPolaroid);
            dictOfPolatiods.Add("Scholarships",ScholarshipsPolaroid);
            dictOfPolatiods.Add("Holiday Homes",HolidayHomesPolaroid);
            dictOfPolatiods.Add("Contact List",ContactPolaroid);
            
            // set the color and image of each polaroid
            var obj = temp.ImageList;
            var colour = Util._pageColDict["Family Support"];
            foreach (var item in obj)
            {
                String key = item.id;
                var polobject = dictOfPolatiods[key];
                polobject.setImage(item.Value);
                polobject.setCaption(item.caption);
                polobject.setColour(colour);
            }
        }



        /// <summary>
        /// return the top level page (main window)
        /// </summary>
        /// <returns></returns>
        private TopLevelPage getTopLevelPage()
        {
            FrameworkElement objParent = (FrameworkElement)this.Parent;
            while (objParent.GetType() != typeof(TopLevelPage))
            {
                objParent = (FrameworkElement)objParent.Parent;
            }
            TopLevelPage levelpage = (TopLevelPage)objParent;
            return levelpage;
        }



        /// <summary>
        /// this method called when a polaroid has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Polaroid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TopLevelPage levelpage = getTopLevelPage();
         
            // switch through each polaroid
            switch ((sender as PoloroidControl).text)
            {
                // when "About Us" polaroid clicked, create the content for About Us and set the subtitle of thepage
                case "Parent Resources":
                    levelpage.setContent(new SplitGridView("xml/FamilySupport_ParentResources.xml"));
                    levelpage.setSubtitle("Parent Resources");
                    break;

                // when "Our Ambassadors" polaroid clicked, create the content for Our Ambassadors and set the subtitle of thepage
                case "Support Services":
                    levelpage.setContent(new GridView("Resources/xml/FamilySupport_SupportServices.xml"));
                    levelpage.setSubtitle("Support Services");
                    break;

                // when "Our Stories" polaroid clicked, create the content for Our Stories and set the subtitle of thepage
                case "Scholarships":
                    levelpage.setContent(new GridView("Resources/xml/FamilySupport_Scholarships.xml"));
                    levelpage.setSubtitle("Scholarships");
                    break;

                // when "How We Help" polaroid clicked, create the content for How We Help and set the subtitle of thepage
                case "Holiday Homes":
                    levelpage.setContent(new SplitGridView("xml/FamilySupport_HolidayHomes.xml"));
                    levelpage.setSubtitle("Holiday Homes");
                    break;

                // when "Our History" polaroid clicked, create the content for Our History and set the subtitle of thepage
                case "Contact List":
                    levelpage.setContent(new SplitGridView("xml/FamilySupport_ContactList.xml"));
                    levelpage.setSubtitle("Contact List");
                    break;
                default:
                    break;

            }
        }

    }
}
