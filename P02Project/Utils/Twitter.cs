using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using TweetSharp;

using System.Security.Cryptography;

using System.Drawing;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;

namespace P02Project
{
   

    public class Twitter
    {

        string OAuthToken = "404561432-KpTBd89tPp8JrSViRbyBEA061AIuxoyYqRxddKjY";
        string OAuthTokenSecret = "rxhVokt4zFyG1dpbyxTGBZSW8WjpG14uNurnhWGieQ";
        
        string OAuthConsumerKey = "lUx4ZcXUMHpatJKO9rJAg";
        string OAuthConsumerSecret = "JtZUtWdzpKPTAGxh7CjnwfgR0CD9jkQ8z9ralXWIlS8";
        String oAuthVerifier = "";

        /// <summary>
        /// https://dev.twitter.com/docs/auth/creating-signature
        /// </summary>
        /// <param name="queryParameters">e.g., count=5&trim_user=true</param>
        /// <returns></returns>


        public IEnumerable<TwitterStatus> getTweets()
        {
            var service = new TwitterService(OAuthConsumerKey, OAuthConsumerSecret);
            service.AuthenticateWith(OAuthToken, OAuthTokenSecret);
            ListTweetsOnHomeTimelineOptions options = new ListTweetsOnHomeTimelineOptions();
            
            var tweets = service.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions{ScreenName="ChildCancerNZ"});
            //SendTweetWithMediaOptions options = new SendTweetWithMediaOptions();

            return tweets;

        }
         public  void postTweet(String message, BitmapSource bitsource)
        {
            
           

            


            var service = new TwitterService(OAuthConsumerKey, OAuthConsumerSecret);
            service.AuthenticateWith(OAuthToken, OAuthTokenSecret);
            SendTweetWithMediaOptions options = new SendTweetWithMediaOptions();
            

               
            options.Status=message;


            Image picture = this.BitmapFromSource(bitsource);
            

            using (MemoryStream stream = new MemoryStream())
            {
                // Save image to stream.
                picture.Save(stream, ImageFormat.Bmp);
                //Set the image
                options.Images.Add("some Image", stream);
                service.SendTweetWithMedia(options);
            }

           
           

            

            


            //service.SendTweet(options);
            //var tweets = service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions());
            //foreach (var tweet in tweets)
            //{
            //    Console.WriteLine("{0} says '{1}'", tweet.User.ScreenName, tweet.Text);
            //}
            // OAuth keys generated at http://dev.twitter.com/apps. For security purposes would be better to put these in web.config.

          

        }

         private System.Drawing.Bitmap BitmapFromSource(BitmapSource bitmapsource)
         {
             System.Drawing.Bitmap bitmap;
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
