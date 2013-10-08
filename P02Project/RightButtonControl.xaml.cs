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
        public RightButtonControl()
        {
            this.InitializeComponent();
        }

        public void setButtons(String[] bNames)
        {
            //Button1.Content = bNames[0];
            //Button1.Background = new SolidColorBrush(Util._pageColDict[bNames[0]]);

            //Button2.Content = bNames[1];
            //Button2.Background = new SolidColorBrush(Util._pageColDict[bNames[1]]);

            //Button3.Content = bNames[2];
            //Button3.Background = new SolidColorBrush(Util._pageColDict[bNames[2]]);

            //Button4.Content = bNames[3];
            //Button4.Background = new SolidColorBrush(Util._pageColDict[bNames[3]]);

            //Button5.Content = bNames[4];
            //Button5.Background = new SolidColorBrush(Util._pageColDict[bNames[4]]);

            //Button6.Content = bNames[5];
            //Button6.Background = new SolidColorBrush(Util._pageColDict[bNames[5]]);

            ButtonStack.Children.Clear();

            foreach(String name in bNames)
            {
                Button button = new Button();

                button.Width = Width;
                button.Height = 150;
                button.Margin = new Thickness(0,0,0,20);

                button.Background = new SolidColorBrush(Util._pageColDict[name]);
                button.Content = name;

                button.Foreground = new SolidColorBrush(Colors.White);

                ButtonStack.Children.Add(button);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SurfaceWindow1 parentWindow = (SurfaceWindow1)Window.GetWindow(this);
            Screen nextScreen = null;
            String cont = "";
            cont = (String)(sender as SurfaceButton).Content;
            Console.WriteLine("Button clocked - {0}", cont);
            //Set next screen to add to the stack and it's contents depending on the button clicked
            switch ((String)(sender as SurfaceButton).Content)
            {

                case "About":
                    nextScreen = new TopLevelPage(parentWindow, "About");
                    ((TopLevelPage)nextScreen).setTitleColour(Util._pageColDict["About"]);
                    ((TopLevelPage)nextScreen).setButtons(new String[6] { "Family Support", "How Can I Help?", "News", "Events", "Play Beads", "Contact Us" });
                    //((TopLevelPage)nextScreen).setContent(new Controls."CONTENT CONTROL NAME HERE");
                    break;

                case "Family Support":
                    nextScreen = new TopLevelPage(parentWindow, "Family Support");
                    ((TopLevelPage)nextScreen).setButtons(new String[6] { "About", "How Can I Help?", "News", "Events", "Play Beads", "Contact Us" });
                    ((TopLevelPage)nextScreen).setTitleColour(Util._pageColDict["Family Support"]);
                    //((TopLevelPage)nextScreen).setContent(new Controls."CONTENT CONTROL NAME HERE");
                    break;

                case "How Can I Help?":
                    nextScreen = new TopLevelPage(parentWindow, "How Can I Help?");
                    ((TopLevelPage)nextScreen).setButtons(new String[6] { "About", "Family Support", "News", "Events", "Play Beads", "Contact Us" });
                    ((TopLevelPage)nextScreen).setTitleColour(Util._pageColDict["How Can I Help?"]);
                    //((TopLevelPage)nextScreen).setContent(new Controls."CONTENT CONTROL NAME HERE");
                    break;

                case "News":
                    nextScreen = new TopLevelPage(parentWindow, "News");
                    ((TopLevelPage)nextScreen).setTitleColour(Util._pageColDict["News"]);
                    ((TopLevelPage)nextScreen).setButtons(new String[6] { "About", "Family Support", "How Can I Help?", "Events", "Play Beads", "Contact Us" });
                    //((TopLevelPage)nextScreen).setContent(new Controls."CONTENT CONTROL NAME HERE");
                    break;

                case "Events":
                    nextScreen = new TopLevelPage(parentWindow, "Events");
                    ((TopLevelPage)nextScreen).setButtons(new String[6] { "About", "Family Support", "How Can I Help?", "News", "Play Beads", "Contact Us" });
                    ((TopLevelPage)nextScreen).setTitleColour(Util._pageColDict["Events"]);
                    //((TopLevelPage)nextScreen).setContent(new Controls."CONTENT CONTROL NAME HERE");
                    break;

                case "Play Beads":
                    nextScreen = new TopLevelPage(parentWindow, "Play Beads");
                    ((TopLevelPage)nextScreen).setButtons(new String[6] { "About", "Family Support", "How Can I Help?", "News", "Events", "Contact Us" });
                    ((TopLevelPage)nextScreen).setTitleColour(Util._pageColDict["Play Beads"]);
                    //((TopLevelPage)nextScreen).setContent(new Controls."CONTENT CONTROL NAME HERE");
                    break;

                case "Contact Us":
                    nextScreen = new TopLevelPage(parentWindow, "Contact Us");
                    ((TopLevelPage)nextScreen).setButtons(new String[6] { "About", "Family Support", "How Can I Help?", "News", "Events", "Play Beads" });
                    ((TopLevelPage)nextScreen).setTitleColour(Util._pageColDict["Contact Us"]);
                    //((TopLevelPage)nextScreen).setContent(new Controls."CONTENT CONTROL NAME HERE");
                    break;

                default:
                    //This should never happen.
                    nextScreen = null;
                    break;
            }

            //Go back to home first so dont end up in a maze
            parentWindow.popAll();
            //Go to new screen
            parentWindow.pushScreen(nextScreen);
        }


    }
}