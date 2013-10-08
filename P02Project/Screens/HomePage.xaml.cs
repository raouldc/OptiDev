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
using Microsoft.Surface.Presentation.Input;
using System.Windows.Media.Animation;
using P02Project.Screens;

namespace P02Project
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Screen
    {
        // screen resolution WIDTH * HEIGHT is a ratio of 16:09
        public static readonly int WIDTH = 1280;
        public static readonly int HEIGHT = 720;

        // H_CCF_TITLE: is kept for CCF logo and view title.
        public static readonly int H_CCF_TITLE = HEIGHT / 6;

        // right hand side column kept for the tiles link to different pages (it is shown in all views except home view).
        // W_LINK_TITLE : width of each tile
        // H_LINK_TITLE : height of each tile
        public static readonly int W_LINK_TILE = WIDTH * 3 / 16;
        public static readonly int H_LINK_TILE = HEIGHT / 6;

        // dictionary stores all the ScatterViewItem with its embedded Image and SurfaceButton represent the 7 main tiles
        // about, news, events, contactUs, HowCanIHelp, FamilySupport, PlayBeads
        private Dictionary<String, SVIWithImgBtn> _dictOfAllHomeTiles;

        public HomePage(SurfaceWindow1 parentWindow)
            : base(parentWindow)
        {
            this.InitializeComponent();
        }


        //// this method called when the surface app has just been created.
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // the ScatterViewItem (s) that represent each tile that links to each secion of the app
            // the Image (s) that embbeded in the scatterviewitem
            // the SurfaceButton (s) that embbeded in the scatterviewitem
            //_dictOfAllHomeTiles = new Dictionary<string, SVIWithImgBtn>();
            //_dictOfAllHomeTiles.Add(_aboutSVIButton.ToString(), new SVIWithImgBtn(_aboutSVI, _aboutSVIImage, _aboutSVIButton));
            //_dictOfAllHomeTiles.Add(_familySupportSVIButton.ToString(), new SVIWithImgBtn(_familySupportSVI, _familySupportSVIImage, _familySupportSVIButton));
            //_dictOfAllHomeTiles.Add(_howCanIHelpSVIButton.ToString(), new SVIWithImgBtn(_howCanIHelpSVI, _howCanIHelpSVIImage, _howCanIHelpSVIButton));
            //_dictOfAllHomeTiles.Add(_newsSVIButton.ToString(), new SVIWithImgBtn(_newsSVI, _newsSVIImage, _newsSVIButton));
            //_dictOfAllHomeTiles.Add(_eventsSVIButton.ToString(), new SVIWithImgBtn(_eventsSVI, _eventsSVIImage, _eventsSVIButton));
            //_dictOfAllHomeTiles.Add(_playBeadsSVIButton.ToString(), new SVIWithImgBtn(_playBeadsSVI, _playBeadsSVIImage, _playBeadsSVIButton));
            //_dictOfAllHomeTiles.Add(_contactUsSVIButton.ToString(), new SVIWithImgBtn(_contactUsSVI, _contactUsSVIImage, _contactUsSVIButton));

            about.setImage("abt.png");
            about.setCaption("About");
            about.setColour(Util._pageColDict["About"]);

            familySupport.setImage("FS.png");
            familySupport.setCaption("Family Support");
            familySupport.setColour(Util._pageColDict["Family Support"]);

            howCanIHelp.setImage("howCanIHelp.png");
            howCanIHelp.setCaption("How Can I Help?");
            howCanIHelp.setColour(Util._pageColDict["How Can I Help?"]);

            news.setImage("news.png");
            news.setCaption("News");
            news.setColour(Util._pageColDict["News"]);

            events.setImage("events.png");
            events.setCaption("Events");
            events.setColour(Util._pageColDict["Events"]);

            contactUs.setImage("contact.png");
            contactUs.setCaption("Contact Us");
            contactUs.setColour(Util._pageColDict["Contact Us"]);

            playBeads.setImage("beads.png");
            playBeads.setCaption("Play Beads");
            playBeads.setColour(Util._pageColDict["Play Beads"]);
        }


        //// It checks what button is clicked, then call to the corresponding function to handle the changing of the coentent
        //// and change the color of the title bar accordingly
        private void changeContentBasedOnClickedButton(SurfaceButton sviButton)
        {

        }

        private void homeView_aButtonIsClicked(Object sender, RoutedEventArgs e)
        {
            // x,y of the end point of the animation
            int endPointX = WIDTH - (W_LINK_TILE / 2);
            int endPointY = -H_LINK_TILE / 2;

            // a temporary button, will use to point to a clicked button
            SurfaceButton clickedButton = null;

            // iterte on each tile to animate it.
            foreach (KeyValuePair<String, SVIWithImgBtn> pair in _dictOfAllHomeTiles)
            {
                SVIWithImgBtn sviWthImgBtn = pair.Value;

                ScatterViewItem svi = sviWthImgBtn._svi;
                SurfaceButton sviButton = sviWthImgBtn._sviBtn;
                Image sviImage = sviWthImgBtn._sviImg;

                // declare an endpoint of the animation
                Point endPoint = new Point(endPointX, endPointY);

                // the tile that is clicked must stay in the middle
                if (sender.Equals(sviButton)) endPoint = new Point(WIDTH / 2, HEIGHT / 2);
                // other tiles move to the right
                else endPointY += H_LINK_TILE;

                // call a helper method to animate the tile
                //helperHomeViewAnimator(svi, sviButton, sviImage, endPoint);

                // collapsed (hide) the clicked tile
                // set clickedButton to point to the clicked tile
                if (sender.Equals(sviButton))
                {
                    clickedButton = sviButton;
                    //svi.Visibility = System.Windows.Visibility.Collapsed;
                }
            }

            //    // call a helper method to change the content based on the button that is clicked
            changeContentBasedOnClickedButton(clickedButton);
        }

        //// a helper method for homeView_aButtonIsClicked
        //// this method animates the given ScatterViewItem
        private void helperHomeViewAnimator(ScatterViewItem svi, SurfaceButton sviButton, Image sviImage, Point endPoint)
        {

            Storyboard stb = new Storyboard();
            PointAnimation moveCenter = new PointAnimation();
            // the starting point of the animation
            moveCenter.From = svi.ActualCenter;

            // set the scatterViewItem to be visible
            svi.Visibility = System.Windows.Visibility.Visible;
            // change its size
            svi.Width = W_LINK_TILE;
            svi.Height = H_LINK_TILE;
            svi.Opacity = 100;

            // showing the button
            sviButton.Opacity = 100;

            // turnoff the image that embbeded in the scatter view.
            sviImage.Opacity = 0;

            // set the color our extension area in the title bar (the grid row=0, column=1 and 2)
            _titleExtension1.Opacity = 0;
            _titleExtension2.Opacity = 0;

            // end point of the animation
            moveCenter.To = endPoint;
            // set animation duration
            moveCenter.Duration = new Duration(TimeSpan.FromSeconds(1.0));
            // set the animation and points into the storyboard
            stb.Children.Add(moveCenter);
            Storyboard.SetTarget(moveCenter, svi);
            Storyboard.SetTargetProperty(moveCenter, new PropertyPath(ScatterViewItem.CenterProperty));
            // start animation
            stb.Begin(this);
        }

        private void poloriod_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Screen nextScreen = null;

            //Set next screen to add to the stack and it's contents depending on the button clicked
            switch ((sender as PoloroidControl).text)
            {
                case "About":
                    nextScreen = new TopLevelPage(ParentWindow, "About");
                    ((TopLevelPage)nextScreen).setTitleColour(about.colour);
                    ((TopLevelPage)nextScreen).setButtons(new String[6] { "Family Support", "How Can I Help?", "News", "Events", "Play Beads", "Contact Us" });
                    //((TopLevelPage)nextScreen).setContent(new Controls."CONTENT CONTROL NAME HERE");
                    break;
                case "Family Support":
                    nextScreen = new TopLevelPage(ParentWindow, "Family Support");
                    ((TopLevelPage)nextScreen).setButtons(new String[6] { "About", "How Can I Help?", "News", "Events", "Play Beads", "Contact Us" });
                    ((TopLevelPage)nextScreen).setTitleColour(familySupport.colour);
                    //((TopLevelPage)nextScreen).setContent(new Controls."CONTENT CONTROL NAME HERE");
                    break;
                case "How Can I Help?":
                    nextScreen = new TopLevelPage(ParentWindow, "How Can I Help?");
                    ((TopLevelPage)nextScreen).setButtons(new String[6] { "About", "Family Support", "News", "Events", "Play Beads", "Contact Us" });
                    ((TopLevelPage)nextScreen).setTitleColour(howCanIHelp.colour);
                    //((TopLevelPage)nextScreen).setContent(new Controls."CONTENT CONTROL NAME HERE");
                    break;
                case "News":
                    nextScreen = new TopLevelPage(ParentWindow, "News");
                    ((TopLevelPage)nextScreen).setTitleColour(news.colour);
                    ((TopLevelPage)nextScreen).setButtons(new String[6] { "About", "Family Support", "How Can I Help?", "Events", "Play Beads", "Contact Us" });
                    //((TopLevelPage)nextScreen).setContent(new Controls."CONTENT CONTROL NAME HERE");
                    break;
                case "Events":
                    nextScreen = new TopLevelPage(ParentWindow, "Events");
                    ((TopLevelPage)nextScreen).setButtons(new String[6] { "About", "Family Support", "How Can I Help?", "News", "Play Beads", "Contact Us" });
                    ((TopLevelPage)nextScreen).setTitleColour(events.colour);
                    //((TopLevelPage)nextScreen).setContent(new Controls."CONTENT CONTROL NAME HERE");
                    break;
                case "Play Beads":
                    nextScreen = new TopLevelPage(ParentWindow, "Play Beads");
                    ((TopLevelPage)nextScreen).setButtons(new String[6] { "About", "Family Support", "How Can I Help?", "News", "Events", "Contact Us" });
                    ((TopLevelPage)nextScreen).setTitleColour(playBeads.colour);
                    //((TopLevelPage)nextScreen).setContent(new Controls."CONTENT CONTROL NAME HERE");
                    break;
                case "Contact Us":
                    nextScreen = new TopLevelPage(ParentWindow, "Contact Us");
                    ((TopLevelPage)nextScreen).setButtons(new String[6] { "About", "Family Support", "How Can I Help?", "News", "Events", "Play Beads" });
                    ((TopLevelPage)nextScreen).setTitleColour(contactUs.colour);
                    //((TopLevelPage)nextScreen).setContent(new Controls."CONTENT CONTROL NAME HERE");
                    break;
                default:
                    //This should never happen.
                    nextScreen = null;
                    break;
            }

            //nextScreen should never be null
            ParentWindow.pushScreen(nextScreen);
        }
    }
}