#region

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using TweetSharp;

#endregion

namespace P02Project
{
    /// <summary>
    ///     Interaction logic for TwitterBlock.xaml
    /// </summary>
    public partial class TwitterBlock : UserControl
    {
        private readonly HomePage _parentHome;
        private readonly Random r = new Random();
        private readonly Twitter service = new Twitter();
        private readonly List<TwitterStatus> tweets = new List<TwitterStatus>();
        private DispatcherTimer dt;


        /// <summary>
        ///     create a new twitter block
        /// </summary>
        public TwitterBlock(HomePage parent)
        {
            InitializeComponent();

            _parentHome = parent;

            //Handlers for timers
            AddHandler(TouchUpEvent, new EventHandler<TouchEventArgs>(twitterBoxClicked), true);
            AddHandler(MouseUpEvent, new MouseButtonEventHandler(twitterBoxClicked), true);

            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            Effect = dShdow;

            //create a new dispatcher
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(7);
            dt.Tick += dt_Tick;

            if (tweets.Count == 0)
            {
                IEnumerable<TwitterStatus> result = service.getTweets();
                if (result != null)
                {
                    foreach (TwitterStatus t in result)
                    {
                        //Cache
                        tweets.Add(t);
                    }
                }
            }
            dt.Start();
        }

        private void dt_Tick(object sender, EventArgs e)
        {
            //Set default image
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri("pack://application:,,/Resources/images/CCF_logo.png");
            img.EndInit();

            if (tweets.Count != 0)
            {
                int index = r.Next()%tweets.Count;
                msg.Text = tweets[index].TextDecoded;

                //Ask Twitter to get url
                List<String> urls = service.getImageUrlsForTweet(tweets[index]);
                if (urls.Count > 0)
                {
                    String imgUrl = urls[0];
                    img = service.getBitmapImageForUrl(imgUrl);
                }
            }
            else
            {
                //No tweets

                msg.Text = "Unable to retrieve tweets from Twitter";
            }


            //set image
            tweetImg.Source = img;
        }


        /// <summary>
        ///     This method get called when the twitter button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void twitterBoxClicked(Object sender, RoutedEventArgs e)
        {
            _parentHome.twitterBoxClickedHelper();
        }
    }
}