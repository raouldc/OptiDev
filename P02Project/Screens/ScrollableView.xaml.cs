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

namespace P02Project.Screens
{
    /// <summary>
    /// Interaction logic for ScrollableView.xaml
    /// </summary>
    public partial class ScrollableView : UserControl
    {
        private List<PoloroidWithText> listOfObjects;
        int listItemInFocus;
        public ScrollableView()
        {
            InitializeComponent();
            listOfObjects = new List<PoloroidWithText>();
            //add new poloroidWithTexts with all the data specified
            PoloroidWithText p0 = new PoloroidWithText();
            p0.setTitle("0");
            addPoloroidtoList(p0);
            PoloroidWithText p1 = new PoloroidWithText();
            p1.setTitle("1");
            addPoloroidtoList(p1);
            PoloroidWithText p2 = new PoloroidWithText();
            p2.setTitle("2");
            addPoloroidtoList(p2);
            PoloroidWithText p3 = new PoloroidWithText();
            p3.setTitle("3");
            addPoloroidtoList(p3);
            PoloroidWithText p4 = new PoloroidWithText();
            p4.setTitle("4");
            addPoloroidtoList(p4);
            listView.ScrollIntoView(0);
            listItemInFocus = 0;
            

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
            if (listItemInFocus > 0)
            {
                PoloroidWithText previousPoloroid = listOfObjects[listItemInFocus-1];
                listView.ScrollIntoView(previousPoloroid);
                listItemInFocus--;
            }
        }

        private void right_clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (listItemInFocus < listOfObjects.Count - 1)
            {
                PoloroidWithText nextPoloroid = listOfObjects[listItemInFocus + 1];
                listView.ScrollIntoView(nextPoloroid);
                listItemInFocus++;
            }
            
        }
    }
}
