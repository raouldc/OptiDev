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
    /// Interaction logic for FunkyGrid.xaml
    /// </summary>
    public partial class FunkyGrid : UserControl
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public FunkyGrid()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="filename"></param>
        public FunkyGrid(String filename)
        {
            InitializeComponent();

            //TODO: Set title and subtitle
            PageModel temp;
            String path = System.IO.Path.Combine(System.IO.Path.GetFullPath("."), "Resources/xml/About.xml");
            temp = XMLUtilities.GetContentFromFile(path);
            Dictionary<String,PoloroidControl> dictOfPolatiods = new Dictionary<String,PoloroidControl>();

            // initialize the dictionary to store all the polaroids that appear on this page
            dictOfPolatiods.Add("About Us",AboutUsPolaroid);
            dictOfPolatiods.Add("Our Ambassadors",OurAmbassadorsPolaroid);
            dictOfPolatiods.Add("Our Stories",OurStoriesPolaroid);
            dictOfPolatiods.Add("How we Help",HowWeCanHelpPolaroid);
            dictOfPolatiods.Add("Our History",OurHistoryPolaroid);
            
            // set the color and image of each polaroid
            var obj = temp.ImageList;
            var colour = Util._pageColDict["About"];
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
                case "About Us":
                    levelpage.setContent(new SplitGridView("xml/About_AboutUs.xml"));
                    levelpage.setSubtitle("About Us");
                    break;

                // when "Our Ambassadors" polaroid clicked, create the content for Our Ambassadors and set the subtitle of thepage
                case "Our Ambassadors":
                    levelpage.setContent(new GridView("Resources/xml/About_OurAmbassadors.xml"));
                    levelpage.setSubtitle("Our Ambassadors");
                    break;

                // when "Our Stories" polaroid clicked, create the content for Our Stories and set the subtitle of thepage
                case "Our Stories":
                    levelpage.setContent(new GridView("Resources/xml/About_OurStories.xml"));
                    levelpage.setSubtitle("Our Stories");
                    break;

                // when "How We Help" polaroid clicked, create the content for How We Help and set the subtitle of thepage
                case "How We Help":
                    levelpage.setContent(new SplitGridView("xml/About_HowWeHelp.xml"));
                    levelpage.setSubtitle("How We Help");
                    break;

                // when "Our History" polaroid clicked, create the content for Our History and set the subtitle of thepage
                case "Our History":
                    levelpage.setContent(new SplitGridView("xml/About_OurHistory.xml"));
                    levelpage.setSubtitle("Our History");
                    break;
                default:
                    break;

            }
        }
    }
}
