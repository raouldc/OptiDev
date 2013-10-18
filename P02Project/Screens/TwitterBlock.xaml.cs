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
        /// <summary>
        /// create a new twitter block
        /// </summary>
        public TwitterBlock()
        {


            this.InitializeComponent();
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
        }
    }
}