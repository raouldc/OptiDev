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
        public ScrollableView(string pageType)
        {
            InitializeComponent();
            listOfObjects = new List<PoloroidWithText>();

            //add new poloroidWithTexts with all the data specified
            var temp = XMLUtilities.GetContentFromPage(@"http://www.childcancer.org.nz/News-and-events/"+ pageType +".aspx");
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
                polaroid.setPlace(pageType == "Events"
                                      ? nodeText.Where(t => t.type == "place").FirstOrDefault().Value
                                      : "");
                var image = temp.ImageList.Where(img => img.node == "" + n).FirstOrDefault();
                if (image != null)
                    polaroid.setImage(image.Value);
                addPoloroidtoList(polaroid);
                n++;
            }

        }
     

        private void addPoloroidtoList(PoloroidWithText pol)
        {
            listOfObjects.Add(pol);
            listView.addContent(pol);
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void left_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {

           // double horiz = listView.ScrollViewer.HorizontalOffset;
            //listView.ScrollViewer.ScrollToHorizontalOffset((int)horiz - 1);

        }

        private void right_clicked(object sender, System.Windows.RoutedEventArgs e)
        {
           
                //double horiz = listView.ScrollViewer.HorizontalOffset;
                //listView.ScrollViewer.ScrollToHorizontalOffset((int)horiz+1);
        }
        /*resizes elements as you switch between polaroids 
         * unused so far
         * implementation not fully correct
         */
        private void resizeAllUnusedElements(int prevSelectedIndex, int currentSelectedIndex)
        {
            //scale the previous one down
            var scaleUpValue = 1.05;
            var scaleUp = new ScaleTransform(scaleUpValue, scaleUpValue);
            
            var scaleDownvalue = 1 / scaleUpValue;
            var scaleDown = new ScaleTransform(scaleDownvalue, scaleDownvalue);
            listOfObjects[prevSelectedIndex].RenderTransform=scaleDown;
            listOfObjects[currentSelectedIndex].RenderTransform = scaleUp;
            //scale the current one up
        }

    }
}
