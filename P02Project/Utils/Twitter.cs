using System;
using System.Collections.Generic;
using System.IO;
using TweetSharp;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using System.Net;
using System.ComponentModel;
using System.Net.Cache;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Windows.Threading;

namespace P02Project
{

    /// <summary>
    /// create a new twitter dispatcher
    /// </summary>
    public class Twitter
    {
        private BackgroundWorker worker = new BackgroundWorker();
        private static DependencyObject timer;

        string OAuthToken = "404561432-KpTBd89tPp8JrSViRbyBEA061AIuxoyYqRxddKjY";
        string OAuthTokenSecret = "rxhVokt4zFyG1dpbyxTGBZSW8WjpG14uNurnhWGieQ";

        string OAuthConsumerKey = "lUx4ZcXUMHpatJKO9rJAg";
        string OAuthConsumerSecret = "JtZUtWdzpKPTAGxh7CjnwfgR0CD9jkQ8z9ralXWIlS8";
        
        List<BitmapImage> images = new List<BitmapImage>();
        /// <summary>
        /// https://dev.twitter.com/docs/auth/creating-signature
        /// </summary>
        /// <param name="queryParameters">e.g., count=5&trim_user=true</param>
        /// <returns></returns>
        private Webcam webcamControl;

        public Twitter(Webcam us)
        {
            webcamControl = us;
            initializeWorkers();
            
        }
        public Twitter()
        {
            initializeWorkers();
        }

        private void initializeWorkers()
        {
            if (worker == null)
            {
                worker = new BackgroundWorker();
            }

            //worker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler
                    (m_oWorker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                    (m_oWorker_RunWorkerCompleted);
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

        }


        //get all tweets
        public List<String> getImageUrlsForTweet(TwitterStatus tweet)
        {

            List<String> urls = new List<String>();
            var media = tweet.Entities.Media;
            foreach (var m in media)
            {
                if (m.MediaType == TwitterMediaType.Photo)
                {
                    urls.Add(m.MediaUrl);
                }
            }

            return urls;

        }

        public BitmapImage getBitmapImageForUrl(String url)
        {
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(url);

            src.EndInit();

            return src;
        }


       

        public IEnumerable<TwitterStatus> getTweets()
        {


            

            List<String> urlOfImages = new List<String>();
            var service = new TwitterService(OAuthConsumerKey, OAuthConsumerSecret);
            service.AuthenticateWith(OAuthToken, OAuthTokenSecret);
            ListTweetsOnHomeTimelineOptions options = new ListTweetsOnHomeTimelineOptions();

            IEnumerable<TwitterStatus> tweets = service.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions { ScreenName = "ChildCancerNZ" });

            return tweets;

        }


        /*
        private void updateImage(Uri uri)
        {
            
            WebClient client = new WebClient();
            
            client.OpenReadCompleted += new OpenReadCompletedEventHandler(delegate(object sender, OpenReadCompletedEventArgs e)
            {
                BitmapImage imageToLoad = new BitmapImage();
                imageToLoad.StreamSource = (e.Result as Stream);
                this.images.Add(imageToLoad);
                
            });

            client.OpenReadAsync(uri, uri.AbsoluteUri);
          



        }
         */


       

        public void testTweetPostWithImage()
        {



            //twiter service
            var service = new TwitterService(OAuthConsumerKey, OAuthConsumerSecret);
            service.AuthenticateWith(OAuthToken, OAuthTokenSecret);
            SendTweetWithMediaOptions options = new SendTweetWithMediaOptions();


            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("pack://application:,,/Resources/images/icon.png");
            src.EndInit();

            


            byte[] data;
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(src));


            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();


            }

            Stream stream = new MemoryStream(data);

            options.Status = "Testing with picture";
            var dic = new Dictionary<string, Stream>();
            dic.Add("some Image", stream);
            options.Images = dic;
            //t = service.SendTweetWithMedia(options);



        }




        //post all tweets
        public void postTweet(String message, BitmapSource bitsource, DependencyObject depO)
        {
            

            try
            {
                (Window.GetWindow(depO) as TopWindow).StopTimer();
                //twitter service
                bitsource.Freeze();
                var frame = BitmapFrame.Create(bitsource);
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(frame);
                byte[] data;

                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    data = ms.ToArray();


                }

                Stream stream = new MemoryStream(data); 
                List<Object> args = new List<Object>();
                args.Add(message);
               
                args.Add(bitsource);
                args.Add(stream);
                timer = depO;
                
                worker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
                worker.RunWorkerAsync(args);


            }
            catch(Exception e)
            {
                (Window.GetWindow(depO) as TopWindow).StartTimer();
            }
        }
        //get a bitmap of images to write out
        private System.Drawing.Bitmap BitmapFromSource(BitmapSource bitmapsource)
        {
            Bitmap bitmap;
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapsource));
                enc.Save(outStream);
                bitmap = new System.Drawing.Bitmap(outStream);
            }
            return bitmap;
        }

        //Multi threading

        void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // The background process is complete. We need to inspect
            // our response to see if an error occurred, a cancel was
            // requested or if we completed successfully.  
            if (e.Cancelled)
            {
                Console.WriteLine( "Task Cancelled.");
            }

            // Check to see if an error occurred in the background process.

            else if (e.Error != null)
            {
                Console.WriteLine(  "Error while performing background operation.");
            }
            else
            {  
                // Everything completed normally.
               Console.WriteLine( "Task Completed...");

            }

            try
            {
                webcamControl._tweetBtn.Content = "Tweet";
                var window= (Window.GetWindow(timer) as TopWindow);
                if(window!=null){
                window.ResetTimer();
                }
            }
            catch(NullReferenceException except)
            {

            }
            //Change the status of the buttons on the UI accordingly
           // btnStartAsyncOperation.Enabled = true;
            //btnCancel.Enabled = false;
        }
        /// <summary>
        /// Notification is performed here to the progress bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            // This function fires on the UI thread so it's safe to edit

            // the UI control directly, no funny business with Control.Invoke :)

            // Update the progressBar with the integer supplied to us from the

            // ReportProgress() function.  
           
            Console.WriteLine("Processing......" + e.ProgressPercentage+ "%");
        }



        /// <summary>
        /// Time consuming operations go here </br>
        /// i.e. Database operations,Reporting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            List<Object> args = (List<Object>)e.Argument;

            //Get the elements
            String message = (String)args[0];
            BitmapSource bitsource = (BitmapSource)args[1];
           
            Console.WriteLine("uploading image now");
            var service = new TwitterService(OAuthConsumerKey, OAuthConsumerSecret);
            service.AuthenticateWith(OAuthToken, OAuthTokenSecret);
            SendTweetWithMediaOptions options = new SendTweetWithMediaOptions();

            options.Status = message;

            //Create a byte array of the contents of the bitsource. 
            /*byte[] data;
            PngBitmapEncoder encoder = new PngBitmapEncoder();


       
            var frame=BitmapFrame.Create(bitsource);
            
            encoder.Frames.Add(frame);


            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();


            }

            Stream stream = new MemoryStream(data);
            */
            Stream stream = args[2] as MemoryStream;
            options.Status = message;
            var dic = new Dictionary<string, Stream>();
            dic.Add("...", stream);
            options.Images = dic;

                //Below can be used to provide cancel feature
                 /*          
                worker.ReportProgress(i);
             
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    worker.ReportProgress(0);
                    return;
                }*/


            service.SendTweetWithMedia(options);
            //Report 100% completion on operation completed
            worker.ReportProgress(100);
        }
    }



  



}
