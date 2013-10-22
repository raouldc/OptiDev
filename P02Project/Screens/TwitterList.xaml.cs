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



namespace P02Project
{
	/// <summary>
	/// Interaction logic for TwitterList.xaml
	/// </summary>
	public partial class TwitterList : UserControl, Animatiable
	{



        private TopLevelPage _topLevelPage;
        private Storyboard _sbIn;
        private Twitter service = new Twitter();
        private DispatcherTimer _dt;
        
        public TwitterList(TopLevelPage top)
		{


			this.InitializeComponent();
            _topLevelPage = top;

            IEnumerable<TwitterStatus> tweets = service.getTweets();


            // iterate over the twitter list
            if (tweets != null)
            {

                int i = 0;
                foreach (TwitterStatus tweet in tweets)
                {

                    TweetListElement twElm = new TweetListElement();

                    BrushConverter bc = new BrushConverter();
                    Brush br = i % 2 == 0 ? (Brush)bc.ConvertFrom("#FF073f60") : (Brush)bc.ConvertFrom("#FF4899c8");
                    twElm.setBackground(br);
                    twElm.setMargin(0, 5, 0, 0);

                    // put the twitter text in this variable
                    String twitterText = tweet.TextDecoded;
                    twElm.setTweetText(twitterText);

                    // put the twitter image in img variable
                    BitmapImage img = new BitmapImage();
                    img.BeginInit();
                    img.UriSource = new Uri("pack://application:,,/Resources/images/logoCCF.png");
                    img.EndInit();
                    twElm.setTweetImg(img);


                    _tweetsList.Children.Add(twElm);
                    i++;

                }

            }


            _sbIn = new Storyboard();
            
            Util.FadeIn(_sbIn, _tweetsListScrollViewer);
            _dt = new DispatcherTimer();
            Util.StackAnimationDefault(_sbIn, _buttons.Children);
            Util.FadeIn(_sbIn, _ccfTwitterHome);
            Util.FadeIn(_sbIn, _ccfTwitterQR);

		} 




        //??????????????????????????????????????????????????????????????????????????????
        //??????????????????????????????????????????????????????????????????????????????
        //??????????????????????????????????????????????????????????????????????????????
        //??????????????????????????????????????????????????????????????????????????????
        //??????????????????????????????????????????????????????????????????????????????
        /// <summary>
        /// This method get called when the Camera button has been clicked
        /// this is just a temporary button. need to replace with a proper one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openWebcam(Object sender, RoutedEventArgs e)
        {
            // create a new subscreen and push it into the stack of subscreens
            AnimateOut();

            _dt.Tick += new EventHandler(pusbWebcam);
            _dt.Start();
        }



        private void pusbWebcam(object sender, EventArgs e)
        {
            Webcam webcam = new Webcam();
            _topLevelPage.setContent(webcam);
            _topLevelPage.setSubtitle("Support Us On Twitter");
            _topLevelPage.AnimateIn();

            _dt.Stop();
        }






        public void AnimateIn()
        {
            _sbIn.Begin(this);
        }

        public void AnimateOut()
        {
            
        }


	}



}