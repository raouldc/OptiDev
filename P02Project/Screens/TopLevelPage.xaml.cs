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
        private Stack<UIElement> stackOfContent;

        public TopLevelPage(SurfaceWindow1 parentWindow, String title)
            : base(parentWindow)
        {
            InitializeComponent();

            stackOfContent = new Stack<UIElement>();
            TitleBar.Title.Content = title;
            TitleBar.setTopPage(this);
        }

        //Set the content part of the grid
        public void setContent(UIElement control)
        {

            //remove content from grid (if any) while leaving it on the stack
            if (stackOfContent.Count > 0)
            {
                UIElement oldContent = stackOfContent.Peek();
                pageGrid.Children.Remove(oldContent);
            }
            //Add content to stack if it's not already in it
            if (!stackOfContent.ToArray().Contains(control))
            {
            stackOfContent.Push(control);
            }
            //set control to it's place in the grid
            Grid.SetColumn(control, 0);
            Grid.SetRow(control, 1);
            Grid.SetRowSpan(control, 5);
            pageGrid.Children.Add(control);
        }

        public void setSubtitle(String sub)
        {
            TitleBar.SubTitle.Content = sub;
        }

        public void setTitleColour(Color col)
        {
            TitleBar.setBackground(col);
        }

        public void setButtons(String[] bNames)
        {
            //Set the names of the buttons
            //Needs to be improved so it sets the colours based on the name too
            RightButtons.setButtons(bNames);

        }

        //Go back one screen
        public void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (stackOfContent.Count > 1)
            {
                //pop the top control off the stack
                UIElement old = stackOfContent.Pop();
                //remove it from the view
                pageGrid.Children.Remove(old);
                //set next control to be the content
                this.setContent(stackOfContent.Pop());
            }
            else
            {
                ParentWindow.popScreen();
            }
        }

    }
}
