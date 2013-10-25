#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using P02Project.Utils;

#endregion

namespace P02Project.Screens
{
    /// <summary>
    ///     Interaction logic for TopLevelPage.xaml
    /// </summary>
    public partial class TopLevelPage : Screen
    {
        // stack of the screens and the subtitle
        private readonly Stack<UIElement> stackOfContent;
        private readonly Stack<String> stackSubtitle;
        protected List<Animatiable> components;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="parentWindow">
        ///     This accesses the window that contains the stack.
        ///     The buttons need to go through the stack
        /// </param>
        /// <param name="title">Set title bar</param>
        public TopLevelPage(TopWindow parentWindow, String title)
            : base(parentWindow)
        {
            InitializeComponent();

            // initalize the stacks and set the title of the screen
            stackOfContent = new Stack<UIElement>();
            TitleBar.Title.Content = title;
            TitleBar.setTopPage(this);
            stackSubtitle = new Stack<String>();
            RightButtons.setButtons(Util.getLinks(title));

            components = new List<Animatiable>();

            components.Add(RightButtons);
        }

        public void AnimateOut()
        {
            foreach (Animatiable a in components)
            {
                a.AnimateOut();
            }
        }

        public void AnimateIn()
        {
            foreach (Animatiable a in components)
            {
                a.AnimateIn();
            }
        }

        /// <summary>
        ///     Set the content part of the grid
        /// </summary>
        /// <param name="control">Sets the inner child contents of the page</param>
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


        /// <summary>
        ///     set the subtitle of the screen
        /// </summary>
        /// <param name="sub"></param>
        public void setSubtitle(String sub)
        {
            TitleBar.setSubtitle(sub);
            stackSubtitle.Push(sub);
        }


        /// <summary>
        ///     get the subtitle of the screen
        /// </summary>
        /// <returns></returns>
        public String getSubtitle()
        {
            return TitleBar.SubTitle.Content.ToString();
        }


        /// <summary>
        ///     set the color of the title of the screen
        /// </summary>
        /// <param name="col"></param>
        public void setTitleColour(Color col)
        {
            TitleBar.setColour(col);
        }

        /// <summary>
        ///     set the right buttons
        /// </summary>
        /// <param name="bNames">
        ///     Array of buttons to go on the right side.
        ///     This array should be of size 7 at all times
        /// </param>
        public void setButtons(String[] bNames)
        {
            //Set the names of the buttons
            RightButtons.setButtons(bNames);
        }

        /// <summary>
        ///     This method called when the Back button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (stackOfContent.Count > 1)
            {
                //pop the top control off the stack
                UIElement old = stackOfContent.Pop();

                try
                {
                    (old as Animatiable).AnimateOut();
                }
                catch (NullReferenceException)
                {
                }

                //remove it from the view
                pageGrid.Children.Remove(old);
                //set next control to be the content
                UIElement newContent = stackOfContent.Pop();
                setContent(newContent);

                try
                {
                    (newContent as Animatiable).AnimateIn();
                }
                catch (NullReferenceException)
                {
                }

                stackSubtitle.Pop();

                // set the subtitle according to the subtitle that store in the stack
                if (stackSubtitle.Count < 1)
                {
                    setSubtitle("");
                }
                else
                {
                    String sub = stackSubtitle.Pop();
                    setSubtitle(sub);
                }
            }
            else
            {
                ParentWindow.popScreen();
            }
        }

        public void HomeButton_Click()
        {
            ParentWindow.popScreen();
        }
    }
}