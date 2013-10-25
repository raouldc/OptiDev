#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using TweetSharp;

#endregion

namespace P02Project
{
    /// <summary>
    ///     Provides interaction with the Twitter.
    ///     Offers methods to retrive and post methods.
    ///     Posts are made to @nzokdat and tweets are retrived from @ChildCancerNZ
    /// </summary>
    public class Twitter
    {
        private static DependencyObject timer;

        /// <summary>
        ///     https://dev.twitter.com/docs/auth/creating-signature
        /// </summary>
        /// <param name="queryParameters">e.g., count=5&trim_user=true</param>
        /// <returns></returns>
        private readonly Webcam webcamControl;

        private string OAuthConsumerKey = "lUx4ZcXUMHpatJKO9rJAg";
        private string OAuthConsumerSecret = "JtZUtWdzpKPTAGxh7CjnwfgR0CD9jkQ8z9ralXWIlS8";
        private string OAuthToken = "404561432-KpTBd89tPp8JrSViRbyBEA061AIuxoyYqRxddKjY";
        private string OAuthTokenSecret = "rxhVokt4zFyG1dpbyxTGBZSW8WjpG14uNurnhWGieQ";

        private List<BitmapImage> images = new List<BitmapImage>();
        private BackgroundWorker worker = new BackgroundWorker();

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
            worker.ProgressChanged += m_oWorker_ProgressChanged;
            worker.RunWorkerCompleted += m_oWorker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
        }


        /// <summary>
        ///     Utility method that gets the image urls for a tweet.
        /// </summary>
        /// <param name="tweet"></param>
        /// <returns> A list of strings containing media urlss</returns>
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

        /// <summary>
        ///     Utility method that returns the bitmap with the contents of the url
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Reuturns bitmap image for a urls</returns>
        public BitmapImage getBitmapImageForUrl(String url)
        {
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(url);

            src.EndInit();

            return src;
        }


        /// <summary>
        ///     Returns the tweets for ChildCancerNZ
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TwitterStatus> getTweets()
        {
            List<String> urlOfImages = new List<String>();
            var service = new TwitterService(OAuthConsumerKey, OAuthConsumerSecret);
            service.AuthenticateWith(OAuthToken, OAuthTokenSecret);
            ListTweetsOnHomeTimelineOptions options = new ListTweetsOnHomeTimelineOptions();

            IEnumerable<TwitterStatus> tweets =
                service.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions {ScreenName = "ChildCancerNZ"});

            return tweets;
        }


        /// <summary>
        ///     Post a message and image (from the webcam), Posts are made to @nzokdat
        /// </summary>
        /// <param name="message"></param>
        /// <param name="bitsource"></param>
        /// <param name="depO"></param>
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

                worker.DoWork += m_oWorker_DoWork;
                worker.RunWorkerAsync(args);
            }
            catch (Exception)
            {
                (Window.GetWindow(depO) as TopWindow).StartTimer();
            }
        }

        //get a bitmap of images to write out
        private Bitmap BitmapFromSource(BitmapSource bitmapsource)
        {
            Bitmap bitmap;
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapsource));
                enc.Save(outStream);
                bitmap = new Bitmap(outStream);
            }
            return bitmap;
        }

        //-----------Multi threading

        private void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // The background process is complete. We need to inspect
            // our response to see if an error occurred, a cancel was
            // requested or if we completed successfully.  
            if (e.Cancelled)
            {
                Console.WriteLine("Task Cancelled.");
            }

                // Check to see if an error occurred in the background process.

            else if (e.Error != null)
            {
                Console.WriteLine("Error while performing background operation.");
            }
            else
            {
                // Everything completed normally.
                Console.WriteLine("Task Completed...");
            }

            try
            {
                webcamControl._tweetBtn.Content = "Tweet";
                var window = (Window.GetWindow(timer) as TopWindow);
                if (window != null)
                {
                    window.ResetTimer();
                }
            }
            catch (NullReferenceException)
            {
            }
        }


        /// <summary>
        ///     Any notification of progress can be done here.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // This function fires on the UI thread so it's safe to edit

            // the UI control directly, no funny business with Control.Invoke :)

            // ReportProgress() function.  

            Console.WriteLine("Processing......" + e.ProgressPercentage + "%");
        }


        /// <summary>
        ///     Uploading image, done on a different thread. </br>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> Contains the </param>
        private void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Object> args = (List<Object>) e.Argument;

            //Get the elements
            String message = (String) args[0];
            BitmapSource bitsource = (BitmapSource) args[1];
            Stream stream = args[2] as MemoryStream;

            Console.WriteLine("Uploading image now");

            var service = new TwitterService(OAuthConsumerKey, OAuthConsumerSecret);
            service.AuthenticateWith(OAuthToken, OAuthTokenSecret);

            SendTweetWithMediaOptions options = new SendTweetWithMediaOptions();

            options.Status = message;
            var dic = new Dictionary<string, Stream>();
            dic.Add(message, stream);
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