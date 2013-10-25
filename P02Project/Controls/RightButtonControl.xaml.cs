#region

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using P02Project.Resources.xml;
using P02Project.Screens;
using P02Project.Screens.BeadsOfCourage;
using P02Project.Utils;

#endregion

namespace P02Project
{
    /// <summary>
    ///     This class is responsible for laying out the buttons on the right side of the screen
    ///     The colours for these buttons comes from the Util class
    /// </summary>
    public partial class RightButtonControl : UserControl, Animatiable
    {
        private Storyboard sbIn;

        /// <summary>
        ///     constructor
        /// </summary>
        public RightButtonControl()
        {
            InitializeComponent();
        }


        public void AnimateIn()
        {
            sbIn.Begin();
        }

        public void AnimateOut()
        {
        }

        /// <summary>
        ///     set the buttons according to the list of the buttons given
        /// </summary>
        /// <param name="bNames">list of all the buttons to be set into the right buttons</param>
        public void setButtons(String[] bNames)
        {
            ButtonStack.Children.Clear();
            sbIn = new Storyboard();
            int count = 0;

            // set every give name into the right button
            foreach (String name in bNames)
            {
                RightButton button = new RightButton();

                button.Width = 197;
                button.Height = 137;

                //button.Name = "but" + name.Replace(" ", "");

                //Need ot set a 15 margin on the right to make the shadow visible
                button.Margin = new Thickness(0, 0, 15, 15);
                button.HorizontalAlignment = HorizontalAlignment.Left;

                button.Colour = Util._pageColDict[name];
                button.Caption = name;

                button.Foreground = new SolidColorBrush(Colors.White);

                button.MouseUp += Button_Click;

                ButtonStack.Children.Add(button);

                ThicknessAnimation pan = new ThicknessAnimation();
                pan.From = new Thickness(300, 0, 15, 15);
                pan.To = new Thickness(0, 0, 15, 15);
                pan.Duration = new Duration(TimeSpan.FromMilliseconds(100 + 50*(count++)));

                sbIn.Children.Add(pan);
                Storyboard.SetTarget(pan, button);
                Storyboard.SetTargetProperty(pan, new PropertyPath(MarginProperty));
            }
        }


        /// <summary>
        ///     This event takes care of moving around contents of the stack and the re-laying the buttons on the right
        /// </summary>
        /// <param name="sender">The sender needs to be of type RightButton</param>
        /// <param name="e"></param>
        private void Button_Click(object sender, MouseButtonEventArgs e)
        {
            TopWindow ParentWindow = (TopWindow) Window.GetWindow(this);
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
                    path = Path.Combine(Path.GetFullPath("."), "Resources/xml/About.xml");
                    ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("About"), colour,
                        new GridView(XMLUtilities.GetContentFromFile(path)), "");
                    break;

                case "News":
                    nextScreen = new TopLevelPage(ParentWindow, "News");
                    ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("News"), colour, new ScrollableView("News"),
                        "");
                    break;

                case "How Can I Help?":

                    nextScreen = new TopLevelPage(ParentWindow, "How Can I Help?");
                    ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("How Can I Help?"), colour,
                        new hcihHomeControl(nextScreen), "");
                    break;

                case "Events":
                    nextScreen = new TopLevelPage(ParentWindow, "Events");
                    ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("Events"), colour,
                        new ScrollableView("Events"), "");
                    break;

                case "Family Support":
                    nextScreen = new TopLevelPage(ParentWindow, "Family Support");
                    ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("Family Support"), colour,
                        new fsHomeControl(), "");
                    break;

                case "Beads of Courage":
                    nextScreen = new TopLevelPage(ParentWindow, "Beads of Courage");
                    ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("Beads of Courage"), colour,
                        new BeadsOfCourage(), "");
                    break;

                case "Contact Us":
                    nextScreen = new TopLevelPage(ParentWindow, "Contact Us");
                    ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("Contact Us"), colour, new ContactUs(), "");
                    break;

                case "Twitter":
                    nextScreen = new TopLevelPage(ParentWindow, "Twitter");
                    ParentWindow.pushScreenOnStack(nextScreen, Util.getLinks("Twitter"), colour,
                        new TwitterList(nextScreen), "Our Tweets");
                    break;

                default:
                    //This should never happen.
                    throw new ArgumentException("Button Target not defined. Button caption: " + caption, "sender");
            }
        }
    }
}