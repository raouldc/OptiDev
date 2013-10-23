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
using P02Project.Screens;
using P02Project.Utils;
using P02Project.Resources.xml;
using System.Windows.Threading;
using TweetSharp;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;


namespace P02Project
{
	/// <summary>
	/// Interaction logic for TwitterList.xaml
	/// </summary>
	public partial class TwitterList : UserControl, Animatiable
    {

        # region Variables
        private TopLevelPage _topLevelPage;
        private Storyboard _sbIn;
        private Twitter service = new Twitter();
        private DispatcherTimer _dt;
        # endregion



        # region Constructor
        public TwitterList(TopLevelPage top)
		{
			this.InitializeComponent();

            _topLevelPage = top;

            listTweetsInTheScrollViewer();

            setupScreenAnimation();
		}
    
        # endregion


        # region Methods

        /// <summary>
        /// Helper method to list all the tweets in the scrollviewer
        /// </summary>
        private void listTweetsInTheScrollViewer()
        {
            IEnumerable<TwitterStatus> tweets = service.getTweets();

            listTitle.FontFamily = Util.buttonTextFont;
            listTitle.Foreground = new SolidColorBrush(Util.buttonTextColor);

            // set up the "Tweet Us" button properties
            _tweetUsBtn.FontFamily = Util.buttonTextFont;
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            _tweetUsBtn.Effect = dShdow;

            // iterate over the twitter list
            if (tweets != null)
            {

                int i = 0;
                foreach (TwitterStatus tweet in tweets)
                {
                    // a tweet element (tweet image + tweet message)
                    TweetListElement twElm = new TweetListElement();

                    BrushConverter bc = new BrushConverter();
                    // change the background colour of each element
                    Brush br = i % 2 == 0 ? (Brush)bc.ConvertFrom("#FF073f60") : (Brush)bc.ConvertFrom("#FF4899c8");
                    twElm.setBackground(br);
                    twElm.setMargin(0, 5, 0, 0);

                    // put the twitter text in this variable
                    String twitterText = tweet.TextDecoded;
                    twElm.setTweetText(twitterText);

                    // put the default twitter image, for the case that the url is not working.
                    BitmapImage img = new BitmapImage();
                    img.BeginInit();
                    img.UriSource = new Uri("pack://application:,,/Resources/images/logoCCF.png");
                    img.EndInit();


                    //Ask Twitter to get url
                    List<String> urls = service.getImageUrlsForTweet(tweet);
                    if (urls.Count > 0)
                    {
                        String imgUrl = urls[0];
                        img = service.getBitmapImageForUrl(imgUrl);

                    }

                    twElm.setTweetImg(img);

                    _tweetsList.Children.Add(twElm);
                    i++;
                }
            }
        }



        /// <summary>
        /// Helper method to do animation at the start of the screen
        /// </summary>
        private void setupScreenAnimation()
        {
           // animated storyboard
            _sbIn = new Storyboard();
            
            // set up the animation
            Util.FadeIn(_sbIn, _tweetsListScrollViewer);
            _dt = new DispatcherTimer();
            Util.StackAnimationDefault(_sbIn, _buttons.Children);
            Util.FadeIn(_sbIn, _ccfTwitterHome);
            Util.FadeIn(_sbIn, _ccfTwitterQR);
        }



        /// <summary>
        /// implementation of the supercalss method
        /// </summary>
        public void AnimateIn()
        {
            _sbIn.Begin(this);
        }



        /// <summary>
        /// implementation of the supercalss method
        /// </summary>
        public void AnimateOut()
        {
            
        }



        /// <summary>
        /// Timer to go back to the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _tweetsListScrollViewer_ScrollChanged(object sender, System.Windows.Controls.ScrollChangedEventArgs e)
        {
            (Window.GetWindow(this) as TopWindow).ResetTimer();
        }

        # endregion

        # region Event Handlers

        /// <summary>
        /// This method get called when the Camera button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openWebcam(Object sender, RoutedEventArgs e)
        {
            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException exp)
            {
            }

            Webcam webcam = new Webcam();
            _topLevelPage.setContent(webcam);
            _topLevelPage.setSubtitle("Support Us On Twitter");


        }

        #endregion


    }



}