using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Threading;
using TweetSharp;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Effects;
using System.Windows.Media;
using System.Windows.Input;

namespace P02Project
{
    /// <summary>
    /// Interaction logic for TwitterBlock.xaml
    /// </summary>
    public partial class TwitterBlock : UserControl
    {
        DispatcherTimer dt;
        Twitter service = new Twitter();
        Random r = new Random();
        List<TwitterStatus> tweets = new List<TwitterStatus>();
        private HomePage _parentHome;


        /// <summary>
        /// create a new twitter block
        /// </summary>
        public TwitterBlock(HomePage parent)
        {
            this.InitializeComponent();

            _parentHome = parent;

            this.AddHandler(UIElement.TouchUpEvent, new EventHandler<TouchEventArgs>(twitterBoxClicked), true);
            this.AddHandler(UIElement.MouseUpEvent, new MouseButtonEventHandler(twitterBoxClicked), true);

            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            this.Effect = dShdow;

            //create a new dispatcher
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(7);
            dt.Tick += new EventHandler(dt_Tick);

            if (tweets.Count == 0)
            {
                IEnumerable<TwitterStatus> result = service.getTweets();
                if (result != null)
                {

                    foreach (TwitterStatus t in result)
                    {

                        tweets.Add(t);
                    }
                }
              
            }

            dt.Start();
        }

        void dt_Tick(object sender, EventArgs e)
        {
            int index = r.Next() % tweets.Count;
            msg.Text = tweets[index].TextDecoded;

            // put the default twitter image, for the case that the url is not working.
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri("pack://application:,,/Resources/images/logoCCF.png");
            img.EndInit();

            //Ask Twitter to get url
            List<String> urls = service.getImageUrlsForTweet(tweets[index]);
            if (urls.Count > 0)
            {
                String imgUrl = urls[0];
                img = service.getBitmapImageForUrl(imgUrl);

            }

            //set image
            tweetImg.Source = img;

        }


        /// <summary>
        /// This method get called when the twitter button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void twitterBoxClicked(Object sender, RoutedEventArgs e)
        {
            _parentHome.twitterBoxClickedHelper();
        }
    }
}