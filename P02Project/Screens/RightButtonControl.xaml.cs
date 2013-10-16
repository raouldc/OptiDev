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
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using P02Project.Resources.xml;
using P02Project.Screens;

namespace P02Project
{
    /// <summary>
    /// This class is responsible for laying out the buttons on the right side of the screen
    /// The colours for these buttons comes from the Util class
    /// </summary>
    public partial class RightButtonControl : UserControl
    {
        /// <summary>
        /// constructor
        /// </summary>
        public RightButtonControl()
        {
            this.InitializeComponent();
        }



        /// <summary>
        /// set the buttons according to the list of the buttons given
        /// </summary>
        /// <param name="bNames">list of all the buttons to be set into the right buttons</param>
        public void setButtons(String[] bNames)
        {
            ButtonStack.Children.Clear();

            // set every give name into the right button
            foreach(String name in bNames)
            {
                RightButton button = new RightButton();

                button.Width = Width;
                button.Height = 160;

                //Need ot set a 15 margin on the right to make the shadow visible
                button.Margin = new Thickness(0, 0, 15, 15);

                button.Colour = Util._pageColDict[name];
                button.Caption = name;

                button.Foreground = new SolidColorBrush(Colors.White);

                button.MouseUp += new MouseButtonEventHandler(Button_Click);

                ButtonStack.Children.Add(button);
            }            
        }



        /// <summary>
        /// This event takes care of moving around contents of the stack and the re-laying the buttons on the right
        /// </summary>
        /// <param name="sender">The sender needs to be of type RightButton</param>
        /// <param name="e"></param>
        private void Button_Click(object sender, MouseButtonEventArgs e)
        {
            TopWindow ParentWindow = (TopWindow)Window.GetWindow(this);
            TopLevelPage nextScreen;

            String caption = (sender as RightButton).Caption;
            Color colour = (sender as RightButton).Colour;

            Console.WriteLine("Button clocked - {0}", caption);
            //Set next screen to add to the stack and it's contents depending on the button clicked
            String path;
            switch (caption)
            {
                case "About":
                    nextScreen = new TopLevelPage(ParentWindow, "About");
                    path = System.IO.Path.Combine(System.IO.Path.GetFullPath("."), "Resources/xml/About.xml");
                    ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("About"), colour, new GridView(XMLUtilities.GetContentFromFile(path)), "");
                    break;

                case "News":
                    nextScreen = new TopLevelPage(ParentWindow, "News");
                    ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("News"), colour, new UserControl(), "");
                    break;

                case "How Can I Help?":
                    
                    nextScreen = new TopLevelPage(ParentWindow, "How Can I Help?");
                    ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("How Can I Help?"), colour, new hcihHomeControl(nextScreen), "");
                    break;

                case "Events":
                    nextScreen = new TopLevelPage(ParentWindow, "Events");
                    ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("Events"), colour, new UserControl(), "");
                    break;

                case "Family Support":
                    nextScreen = new TopLevelPage(ParentWindow, "Family Support");
                    ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("Family Support"), colour, new UserControl(), "");
                    break;

                case "Play Beads":
                    nextScreen = new TopLevelPage(ParentWindow, "Play Beads");
                    ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("Play Beads"), colour, new UserControl(), "");
                    break;

                case "Contact Us":
                    nextScreen = new TopLevelPage(ParentWindow, "Contact Us");
                    ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("Contact Us"), colour, new ContactUs(), "");
                    break;

                default:
                    //This should never happen.
                    throw new System.ArgumentException("Button Target not defined. Button caption: " + caption, "sender");
            }
        }


    }
}