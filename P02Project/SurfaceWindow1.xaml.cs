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
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;
using System.Windows.Media.Animation;
using P02Project.Resources.xml;
using P02Project.Screens;

namespace P02Project
{
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
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
        //private Dictionary<String, SVIWithImgBtn> _dictOfAllHomeTiles;
        private Stack<Screen> stackOfScreens;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();

            stackOfScreens = new Stack<Screen>();
            //Setting starting Screen here, maybe should be in one of the other OnXXX methods of this class
            pushScreen(new HomePage(this));
        }

        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

        public void popScreen()
        {
        
            if (stackOfScreens.Count > 1)
            {
                stackOfScreens.Pop();
                this.Content = stackOfScreens.Peek();
                this.WindowState = WindowState.Maximized;
                this.WindowStyle = WindowStyle.None;
            }
        }
        public void pushScreen(Screen screen)
        {
         
            stackOfScreens.Push(screen);
            this.Content = stackOfScreens.Peek();
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.None;

        }

        public void popAll()
        {
           
            while (stackOfScreens.Count > 1)
            {
                stackOfScreens.Pop();
            }
            this.Content = stackOfScreens.Peek();
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.None;
        }

        public void pushScreenOnStack(TopLevelPage nextScreen, String[] buttons, Color colour, UserControl content, String Subtitle)
        {
            nextScreen.setButtons(buttons);
            nextScreen.setTitleColour(colour);
            nextScreen.setContent(content);
            nextScreen.setSubtitle(Subtitle);
            pushScreen(nextScreen);
        }
        //// this method called when the surface app has just been created.
        //protected override void OnInitialized(EventArgs e)
        //{
        //    base.OnInitialized(e);

        //    // the ScatterViewItem (s) that represent each tile that links to each secion of the app
        //    // the Image (s) that embbeded in the scatterviewitem
        //    // the SurfaceButton (s) that embbeded in the scatterviewitem
        //    _dictOfAllHomeTiles = new Dictionary<string, SVIWithImgBtn>();
        //    _dictOfAllHomeTiles.Add(_aboutSVIButton.ToString(), new SVIWithImgBtn(_aboutSVI, _aboutSVIImage, _aboutSVIButton));
        //    _dictOfAllHomeTiles.Add(_familySupportSVIButton.ToString(), new SVIWithImgBtn(_familySupportSVI, _familySupportSVIImage, _familySupportSVIButton));
        //    _dictOfAllHomeTiles.Add(_howCanIHelpSVIButton.ToString(), new SVIWithImgBtn(_howCanIHelpSVI, _howCanIHelpSVIImage, _howCanIHelpSVIButton));
        //    _dictOfAllHomeTiles.Add(_newsSVIButton.ToString(), new SVIWithImgBtn(_newsSVI, _newsSVIImage, _newsSVIButton));
        //    _dictOfAllHomeTiles.Add(_eventsSVIButton.ToString(), new SVIWithImgBtn(_eventsSVI, _eventsSVIImage, _eventsSVIButton));
        //    _dictOfAllHomeTiles.Add(_playBeadsSVIButton.ToString(), new SVIWithImgBtn(_playBeadsSVI, _playBeadsSVIImage, _playBeadsSVIButton));
        //    _dictOfAllHomeTiles.Add(_contactUsSVIButton.ToString(), new SVIWithImgBtn(_contactUsSVI, _contactUsSVIImage, _contactUsSVIButton));
            
        //}


        //// It checks what button is clicked, then call to the corresponding function to handle the changing of the coentent
        //// and change the color of the title bar accordingly
        //private void changeContentBasedOnClickedButton(SurfaceButton sviButton)
        //{
        //    if (sviButton.Equals(_aboutSVIButton))
        //    {
        //        _title.Background = _aboutSVIButton.Background;
        //        changeContentToAboutSection();
        //    }
        //    else if (sviButton.Equals(_familySupportSVIButton))
        //    {
        //        _title.Background = _familySupportSVIButton.Background;
        //        changeContentToFamilySupportSection();
        //    }
        //    else if (sviButton.Equals(_howCanIHelpSVIButton))
        //    {
        //        _title.Background = _howCanIHelpSVIButton.Background;
        //        changeContentToHowCanIHelpSection();
        //    }
        //    else if (sviButton.Equals(_newsSVIButton))
        //    {
        //        _title.Background = _newsSVIButton.Background;
        //        changeContentToNewsSection();
        //    }
        //    else if (sviButton.Equals(_eventsSVIButton))
        //    {
        //        _title.Background = _eventsSVIButton.Background;
        //        changeContentToEventsSection();
        //    }
        //    else if (sviButton.Equals(_playBeadsSVIButton))
        //    {
        //        _title.Background = _playBeadsSVIButton.Background;
        //        changeContentToPlayBeadsSection();
        //    }
        //    else if (sviButton.Equals(_contactUsSVIButton))
        //    {
        //        _title.Background = _contactUsSVIButton.Background;
        //        changeContentToContactUsSection();
        //    }
        //}

        //private void homeView_aButtonIsClicked(Object sender, RoutedEventArgs e)
        //{
        //    // x,y of the end point of the animation
        //    int endPointX = WIDTH - (W_LINK_TILE / 2);
        //    int endPointY = -H_LINK_TILE / 2;

        //    // a temporary button, will use to point to a clicked button
        //    SurfaceButton clickedButton = null;

        //    // iterte on each tile to animate it.
        //    foreach(KeyValuePair<String, SVIWithImgBtn> pair in _dictOfAllHomeTiles)
        //    {
        //        SVIWithImgBtn sviWthImgBtn = pair.Value;

        //        ScatterViewItem svi = sviWthImgBtn._svi;
        //        SurfaceButton sviButton = sviWthImgBtn._sviBtn;
        //        Image sviImage = sviWthImgBtn._sviImg;

        //        // declare an endpoint of the animation
        //        Point endPoint = new Point(endPointX, endPointY);

        //        // the tile that is clicked must stay in the middle
        //        if (sender.Equals(sviButton)) endPoint = new Point(WIDTH / 2, HEIGHT / 2);
        //        // other tiles move to the right
        //        else endPointY += H_LINK_TILE;

        //        // call a helper method to animate the tile
        //        helperHomeViewAnimator(svi, sviButton, sviImage, endPoint);

        //        // collapsed (hide) the clicked tile
        //        // set clickedButton to point to the clicked tile
        //        if (sender.Equals(sviButton))
        //        {
        //            clickedButton = sviButton;
        //            svi.Visibility = System.Windows.Visibility.Collapsed;
        //        }
        //    }

        //    // call a helper method to change the content based on the button that is clicked
        //    changeContentBasedOnClickedButton(clickedButton);
        //}

        //// a helper method for homeView_aButtonIsClicked
        //// this method animates the given ScatterViewItem
        //private void helperHomeViewAnimator(ScatterViewItem svi, SurfaceButton sviButton, Image sviImage, Point endPoint)
        //{

        //    Storyboard stb = new Storyboard();
        //    PointAnimation moveCenter = new PointAnimation();
        //    // the starting point of the animation
        //    moveCenter.From = svi.ActualCenter;

        //    // set the scatterViewItem to be visible
        //    svi.Visibility = System.Windows.Visibility.Visible;
        //    // change its size
        //    svi.Width = W_LINK_TILE;
        //    svi.Height = H_LINK_TILE;
        //    svi.Opacity = 100;

        //    // showing the button
        //    sviButton.Opacity = 100;

        //    // turnoff the image that embbeded in the scatter view.
        //    sviImage.Opacity = 0;

        //    // set the color our extension area in the title bar (the grid row=0, column=1 and 2)
        //    _titleExtension1.Opacity = 0;
        //    _titleExtension2.Opacity = 0;

        //    // end point of the animation
        //    moveCenter.To = endPoint;
        //    // set animation duration
        //    moveCenter.Duration = new Duration(TimeSpan.FromSeconds(1.0));
        //    // set the animation and points into the storyboard
        //    stb.Children.Add(moveCenter);
        //    Storyboard.SetTarget(moveCenter, svi);
        //    Storyboard.SetTargetProperty(moveCenter, new PropertyPath(ScatterViewItem.CenterProperty));
        //    // start animation
        //    stb.Begin(this);
        //}








        //private void changeContentToAboutSection()
        //{
        //    // create 5 ScatterViewItem(s)
        //    // each ScatterViewItem must be initialized inside the _mainGrid
        //    // in each ScaterViewItem:
        //    // store an image
        //    // store a button that link to its correspond section
        //    // when a button is clicked, apear a new section correspond to the button clicked
        //    // removed all these ScatterViewItem(s)
        //}

        //private void changeContentToNewsSection()
        //{
        //}

        //private void changeContentToEventsSection()
        //{
        //}

        //private void changeContentToContactUsSection()
        //{
        //}

        //private void changeContentToHowCanIHelpSection()
        //{
        //    // create 9 ScatterViewItem(s)
        //    // each ScatterViewItem must be initialized inside the _mainGrid
        //    // in each ScaterViewItem:
        //    // store an image
        //    // store a button that link to its correspond section
        //    // when a button is clicked, apear a new section correspond to the button clicked
        //    // removed all these ScatterViewItem(s)
        //}

        //private void changeContentToFamilySupportSection()
        //{
        //    // create 6 ScatterViewItem(s)
        //    // each ScatterViewItem must be initialized inside the _mainGrid
        //    // in each ScaterViewItem:
        //    // store an image
        //    // store a button that link to its correspond section
        //    // when a button is clicked, apear a new section correspond to the button clicked
        //    // removed all these ScatterViewItem(s)
        //}

        //private void changeContentToPlayBeadsSection()
        //{

        //}
    }
}