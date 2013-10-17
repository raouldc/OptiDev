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
using System.Windows.Threading;
using P02Project.Utils;
using TweetSharp;

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
        public TwitterBlock()
        {


            this.InitializeComponent();

            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(2);
            dt.Tick += new EventHandler(dt_Tick);

            if (tweets.Count == 0)
            {
                IEnumerable<TwitterStatus> result = service.getTweets();
                foreach (TwitterStatus t in result)
                {

                    tweets.Add(t);
                }

              

                //msg.Text = "CCF are at the Massey High @Hurricane_Kids gig today. They are rocking out & supporting kids with cancer! pic.twitter.com/1e2HvbKTIw";
            }

            dt.Start();
        }

        void dt_Tick(object sender, EventArgs e)
        {
            int index = r.Next() % tweets.Count;
            msg.Text = tweets[index].TextDecoded;
        }
    }
}