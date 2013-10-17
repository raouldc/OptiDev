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
using System.Windows.Media.Animation;
using P02Project.Resources.xml;

namespace P02Project.Screens
{
    /// <summary>
    /// Interaction logic for ScrollableView.xaml
    /// </summary>
    public partial class ScrollableView : UserControl
    {
        private List<PoloroidWithText> listOfObjects;
        private string pageType;
        public ScrollableView(string pageType)
        {
            InitializeComponent();
            this.pageType = pageType;
            listOfObjects = new List<PoloroidWithText>();

            //add new poloroidWithTexts with all the data specified
            var temp = XMLUtilities.GetContentFromPage(@"http://www.childcancer.org.nz/News-and-events/"+ this.pageType +".aspx");
            var n = 1;
            while (true)
            {
                var nodeText = temp.TextList.Where(text => text.node == ""+n).ToList();
                if (nodeText.Count == 0)
                    break;
                var polaroid = new PoloroidWithText();
                polaroid.setTitle(nodeText.Where(t => t.type == "title").FirstOrDefault().Value);
                polaroid.setDate(nodeText.Where(t => t.type == "date").FirstOrDefault().Value);
                polaroid.setDescription(nodeText.Where(t => t.type == "info").FirstOrDefault().Value);
                if (pageType == "Events")
                    polaroid.setPlace(nodeText.Where(t => t.type == "place").FirstOrDefault().Value);
                addPoloroidtoList(polaroid);
                n++;
            }

//            PoloroidWithText p0 = new PoloroidWithText();
//            p0.setTitle("Hello There Event!");
//            p0.setDate(new DateTime());
//            p0.setDescription("some long description. some long description. some long description. some long description. some long description. some long description. some long description. some long description. some long description. some long description. some long description. some long description. some long description. some long description. some long description. some long description. \nsome long description. some long description. some long description. some long description. some long description. some long description. some long description. some long description. some long description. some long description. some long description. some long description. some long description. some long description. some long description. ");
//            p0.setImage("images/Stories/Emma.png");
//            addPoloroidtoList(p0);
//            PoloroidWithText p1 = new PoloroidWithText();
//            p1.setTitle("1");
//            addPoloroidtoList(p1);
//            PoloroidWithText p2 = new PoloroidWithText();
//            p2.setTitle("2");
//            addPoloroidtoList(p2);
//            PoloroidWithText p3 = new PoloroidWithText();
//            p3.setTitle("3");
//            addPoloroidtoList(p3);
//            PoloroidWithText p4 = new PoloroidWithText();
//            p4.setTitle("4");
//            addPoloroidtoList(p4);
            listView.ScrollIntoView(0);

          

        }
     

        private void addPoloroidtoList(PoloroidWithText pol)
        {
            listOfObjects.Add(pol);
            listView.Items.Add(pol);
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void left_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {

            double horiz = listView.ScrollViewer.HorizontalOffset;
            listView.ScrollViewer.ScrollToHorizontalOffset((int)horiz - 1);

        }

        private void right_clicked(object sender, System.Windows.RoutedEventArgs e)
        {
           
                double horiz = listView.ScrollViewer.HorizontalOffset;
                listView.ScrollViewer.ScrollToHorizontalOffset((int)horiz+1);
        }
        /*resizes elements as you switch between polaroids 
         * unused so far
         * implementation not fully correct
         */
        private void resizeAllUnusedElements(int prevSelectedIndex, int currentSelectedIndex)
        {
            //scale the previous one down
            double scaleUpValue = 1.05;
            ScaleTransform scaleUp = new ScaleTransform(scaleUpValue, scaleUpValue);
            
            double scaleDownvalue = 1 / scaleUpValue;
            ScaleTransform scaleDown = new ScaleTransform(scaleDownvalue, scaleDownvalue);
            listOfObjects[prevSelectedIndex].RenderTransform=scaleDown;
            listOfObjects[currentSelectedIndex].RenderTransform = scaleUp;
            //scale the current one up
        }

    }
}
