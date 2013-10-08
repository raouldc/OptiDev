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
        public FunkyGrid()
        {
            InitializeComponent();
            //create XML Parameter
            //read and parse XML
            //Set properties of items to the object
        }

        public FunkyGrid(String filename)
        {
            InitializeComponent();
            PageModel temp;
            //TODO: Set title and subtitle
            String path = System.IO.Path.Combine(System.IO.Path.GetFullPath("."), "Resources/xml/About.xml");
            temp = XMLUtilities.GetContentFromFile(path);
            Dictionary<String,PoloroidControl> dictOfPolatiods = new Dictionary<String,PoloroidControl>();

            dictOfPolatiods.Add("About Us",AboutUsPolaroid);
            dictOfPolatiods.Add("Our Ambassadors",OurAmbassadorsPolaroid);
            dictOfPolatiods.Add("Our Stories",OurStoriesPolaroid);
            dictOfPolatiods.Add("How we Help",HowWeCanHelpPolaroid);
            dictOfPolatiods.Add("Our History",OurHistoryPolaroid);
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

        private void Polaroid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement objParent = (FrameworkElement)this.Parent;
            while (objParent.GetType() != typeof(TopLevelPage))
            {
                objParent = (FrameworkElement)objParent.Parent;
            }
            TopLevelPage levelpage = (TopLevelPage)objParent;
            switch ((sender as PoloroidControl).text)
            {
                case "About Us":
                    levelpage.setContent(new SplitGridView("xml/About_AboutUs.xml"));
                    break;
                case "Our Ambassadors":
                    levelpage.setContent(new GridView("Resources/xml/About_OurAmbassadors.xml"));
                    break;
                case "Our Stories":
                    levelpage.setContent(new GridView("Resources/xml/About_OurStories.xml"));
                    break;
                case "How we Help":
                    levelpage.setContent(new SplitGridView("xml/About_HowWeHelp.xml"));
                    break;
                case "Our History":
                    levelpage.setContent(new SplitGridView("xml/About_OurHistory.xml"));
                    break;
                default:
                    break;

            }
        }
    }
}
