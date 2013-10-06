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

        // list stores all the ScatterViewItems represent the 7 main tiles
        // _aboutSVI, _newsSVI, _eventSVI, ContactUs, HowCanIHelp, FamilySupport, PlayBeads
        private List<ScatterViewItem> _mainTiles;
        // list stores all images and buttons that are embbeded in the ScatterViewItem
        private List<Image> _mainTilesImages;
        private List<SurfaceButton> _mainTilesButtons;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();

            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();
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


        // this method called when the surface app has just been created.
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // add the ScatterViewItem (s) that represent each section of the app into the list
            _mainTiles = new List<ScatterViewItem>();
            _mainTiles.Add(_aboutSVI);
            _mainTiles.Add(_familySupportSVI);
            _mainTiles.Add(_howCanIHelpSVI);
            _mainTiles.Add(_newsSVI);
            _mainTiles.Add(_eventSVI);
            _mainTiles.Add(_playBeadsSVI);
            _mainTiles.Add(_contactUsSVI);

            // add the Image (s) that embbeded in the scatterviewitem that represends a section of the app into the list
            _mainTilesImages = new List<Image>();
            _mainTilesImages.Add(_aboutSVIImage);
            _mainTilesImages.Add(_familySupportSVIImage);
            _mainTilesImages.Add(_howCanIHelpSVIImage);
            _mainTilesImages.Add(_newsSVIImage);
            _mainTilesImages.Add(_eventSVIImage);
            _mainTilesImages.Add(_playBeadsSVIImage);
            _mainTilesImages.Add(_contactUsSVIImage);

            // add the SurfaceButton (s) that embbeded in the scatterviewitem that represends a section of the app into the list
            _mainTilesButtons = new List<SurfaceButton>();
            _mainTilesButtons.Add(_aboutSVIButton);
            _mainTilesButtons.Add(_familySupportSVIButton);
            _mainTilesButtons.Add(_howCanIHelpSVIButton);
            _mainTilesButtons.Add(_newsSVIButton);
            _mainTilesButtons.Add(_eventSVIButton);
            _mainTilesButtons.Add(_playBeadsSVIButton);
            _mainTilesButtons.Add(_contactUsSVIButton);
        }


        // It checks what button is clicked, then call to the corresponding function to handle the changing of the coentent
        // and change the color of the title bar accordingly
        private void changeContentBasedOnClickedButton(SurfaceButton sviButton)
        {
            if (sviButton.Equals(_aboutSVIButton))
            {
                _title.Background = new System.Windows.Media.SolidColorBrush(Color.FromRgb(89, 126, 170));
                changeContentToAboutSection();
            }
            else if (sviButton.Equals(_familySupportSVIButton))
            {
                _title.Background = new System.Windows.Media.SolidColorBrush(Color.FromRgb(166, 77, 121));
                changeContentToFamilySupportSection();
            }
            else if (sviButton.Equals(_howCanIHelpSVIButton))
            {
                _title.Background = new System.Windows.Media.SolidColorBrush(Color.FromRgb(230, 145, 56));
                changeContentToHowCanIHelpSection();
            }
            else if (sviButton.Equals(_newsSVIButton))
            {
                _title.Background = new System.Windows.Media.SolidColorBrush(Color.FromRgb(103, 78, 167));
                changeContentToNewsSection();
            }
            else if (sviButton.Equals(_eventSVIButton))
            {
                _title.Background = new System.Windows.Media.SolidColorBrush(Color.FromRgb(106, 168, 79));
                changeContentToEventsSection();
            }
            else if (sviButton.Equals(_playBeadsSVIButton))
            {
                _title.Background = new System.Windows.Media.SolidColorBrush(Color.FromRgb(204, 0, 0));
                changeContentToPlayBeadsSection();
            }
            else if (sviButton.Equals(_contactUsSVIButton))
            {
                _title.Background = new System.Windows.Media.SolidColorBrush(Color.FromRgb(241, 194, 50));
                changeContentToContactUsSection();
            }
        }

        private void homeView_aButtonIsClicked(Object sender, RoutedEventArgs e)
        {
            // x,y of the end point of the animation
            int endPointX = WIDTH - (W_LINK_TILE / 2);
            int endPointY = -H_LINK_TILE / 2;

            // a temporary button, will use to point to a clicked button
            SurfaceButton clickedButton = null;

            // iterte on each tile to animate it.
            for (int i = 0; i < _mainTiles.Count; i++)
            {
                ScatterViewItem svi = _mainTiles[i];
                SurfaceButton sviButton = _mainTilesButtons[i];
                Image sviImage = _mainTilesImages[i];

                // declare an endpoint of the animation
                Point endPoint = new Point(endPointX, endPointY);

                // the tile that is clicked must stay in the middle
                if (sender.Equals(sviButton)) endPoint = new Point(WIDTH / 2, HEIGHT / 2);
                // other tiles move to the right
                else endPointY += H_LINK_TILE;

                // call a helper method to animate the tile
                helperHomeViewAnimator(svi, sviButton, sviImage, endPoint);

                // collapsed (hide) the clicked tile
                // set clickedButton to point to the clicked tile
                if (sender.Equals(sviButton))
                {
                    clickedButton = sviButton;
                    svi.Visibility = System.Windows.Visibility.Collapsed;
                }
            }

            // call a helper method to change the content based on the button that is clicked
            changeContentBasedOnClickedButton(clickedButton);
        }

        // a helper method for homeView_aButtonIsClicked
        // this method animates the given ScatterViewItem
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








        private void changeContentToAboutSection()
        {
            // create 5 ScatterViewItem(s)
            // each ScatterViewItem must be initialized inside the _mainGrid
            // in each ScaterViewItem:
            // store an image
            // store a button that link to its correspond section
            // when a button is clicked, apear a new section correspond to the button clicked
            // removed all these ScatterViewItem(s)
        }

        private void changeContentToNewsSection()
        {
        }

        private void changeContentToEventsSection()
        {
        }

        private void changeContentToContactUsSection()
        {
        }

        private void changeContentToHowCanIHelpSection()
        {
            // create 9 ScatterViewItem(s)
            // each ScatterViewItem must be initialized inside the _mainGrid
            // in each ScaterViewItem:
            // store an image
            // store a button that link to its correspond section
            // when a button is clicked, apear a new section correspond to the button clicked
            // removed all these ScatterViewItem(s)
        }

        private void changeContentToFamilySupportSection()
        {
            // create 6 ScatterViewItem(s)
            // each ScatterViewItem must be initialized inside the _mainGrid
            // in each ScaterViewItem:
            // store an image
            // store a button that link to its correspond section
            // when a button is clicked, apear a new section correspond to the button clicked
            // removed all these ScatterViewItem(s)
        }

        private void changeContentToPlayBeadsSection()
        {

        }
    }
}