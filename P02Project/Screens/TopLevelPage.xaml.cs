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

namespace P02Project.Screens
{
    /// <summary>
    /// Interaction logic for TopLevelPage.xaml
    /// </summary>
    public partial class TopLevelPage : Screen
    {
        public TopLevelPage(SurfaceWindow1 parentWindow, String title) : base(parentWindow)
		{
			InitializeComponent();
            TitleBar.Title.Content = title;
		}

        //Set the content part of the grid
        public void setContent(UIElement control)
        {
            Grid.SetColumn(control, 0);
            Grid.SetRow(control, 1);
            Grid.SetRowSpan(control, 5);
            pageGrid.Children.Add(control);
        }

        public void setSubtitle(String sub)
        {
            TitleBar.SubTitle.Content = sub;
        }

        public void setTitleColour(Brush bg)
        {
            TitleBar.BarBG.Background = bg;
        }

        public void setButtons(String[] bNames)
        {
            //Set the names of the buttons
            //Needs to be improved so it sets the colours based on the name too
            
            RightButtons.Button1.Content = bNames[0];
            RightButtons.Button2.Content = bNames[1];
            RightButtons.Button3.Content = bNames[2];
            RightButtons.Button4.Content = bNames[3];
            RightButtons.Button5.Content = bNames[4];
            RightButtons.Button6.Content = bNames[5];
        
        }

        //Go back one screen
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //ParentWindow.popScreen();
        }

    }
}
