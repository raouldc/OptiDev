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

namespace P02Project
{

    /// <summary>
    /// create a new twitter dispatcher
    /// </summary>
    public class Twitter
    {

        string OAuthToken = "404561432-KpTBd89tPp8JrSViRbyBEA061AIuxoyYqRxddKjY";
        string OAuthTokenSecret = "rxhVokt4zFyG1dpbyxTGBZSW8WjpG14uNurnhWGieQ";

        string OAuthConsumerKey = "lUx4ZcXUMHpatJKO9rJAg";
        string OAuthConsumerSecret = "JtZUtWdzpKPTAGxh7CjnwfgR0CD9jkQ8z9ralXWIlS8";
        String oAuthVerifier = "";
        List<BitmapImage> images = new List<BitmapImage>();
        /// <summary>
        /// https://dev.twitter.com/docs/auth/creating-signature
        /// </summary>
        /// <param name="queryParameters">e.g., count=5&trim_user=true</param>
        /// <returns></returns>

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
        public void postTweet(String message, BitmapSource bitsource)
        {


            //twitter service
            var service = new TwitterService(OAuthConsumerKey, OAuthConsumerSecret);
            service.AuthenticateWith(OAuthToken, OAuthTokenSecret);
            SendTweetWithMediaOptions options = new SendTweetWithMediaOptions();



            options.Status = message;


            Image picture = this.BitmapFromSource(bitsource);

            //Create a byte array of the contents of the bitsource. 
            byte[] data;
            BitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitsource));


            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();


            }


            try
            {
                Stream stream = new MemoryStream(data);
                picture.Save(stream, ImageFormat.Bmp);
                //Set the image
                options.Images.Add(message, stream);

                //Set the status
                options.Status = message;
                service.SendTweetWithMedia(options);
            }
            catch (Exception)
            {
                throw;
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

    }



}
