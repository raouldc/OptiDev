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
using P02Project.Screens;

namespace P02Project
{
    /// <summary>
    /// Interaction logic for RightButtonControl.xaml
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
                button.Margin = new Thickness(0, 0, 15, 15);

                button.Colour = Util._pageColDict[name];
                button.Caption = name;

                button.Foreground = new SolidColorBrush(Colors.White);

                button.MouseUp += new MouseButtonEventHandler(Button_Click);

                ButtonStack.Children.Add(button);
            }            
        }



        /// <summary>
        /// this method called when a button of the right buttons has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, MouseButtonEventArgs e)
        {
            SurfaceWindow1 ParentWindow = (SurfaceWindow1)Window.GetWindow(this);
            TopLevelPage nextScreen;

            String cont = (sender as RightButton).Caption;
            Color colour = (sender as RightButton).Colour;

            Console.WriteLine("Button clocked - {0}", cont);
            //Set next screen to add to the stack and it's contents depending on the button clicked
            switch (cont)
            {
                case "About":
                    nextScreen = new TopLevelPage(ParentWindow, "About");
                    ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("About"), colour, new FunkyGrid("xml/About.xml"), "");
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
                    nextScreen = null;
                    break;
            }
        }


    }
}