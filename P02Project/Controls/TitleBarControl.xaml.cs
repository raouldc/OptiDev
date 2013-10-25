#region

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using P02Project.Screens;

#endregion

namespace P02Project
{
    /// <summary>
    ///     Interaction logic for TitleBarControl.xaml
    /// </summary>
    public partial class TitleBarControl : UserControl
    {
        // topLevelPage is the main screen
        private readonly DispatcherTimer dt;
        private TopLevelPage topLevelPage;


        /// <summary>
        ///     constructor
        /// </summary>
        public TitleBarControl()
        {
            InitializeComponent();
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(300);
            dt.Tick += dt_Tick;
        }

        private void dt_Tick(object sender, EventArgs e)
        {
            dt.Stop();
            topLevelPage.BackButton_Click(sender, null);
        }

        /// <summary>
        ///     setter of the topLevelPage
        /// </summary>
        /// <param name="top"></param>
        public void setTopPage(TopLevelPage top)
        {
            topLevelPage = top;
        }

        /// <summary>
        ///     set the background of the titlebar
        /// </summary>
        /// <param name="col"></param>
        public void setColour(Color col)
        {
            //lRect.Fill = new SolidColorBrush(col);
            //rGradStop.Color = col;
            Title.Foreground = new SolidColorBrush(col);
            SubTitle.Foreground = new SolidColorBrush(col);
        }

        /// <summary>
        ///     Set the subtitle
        /// </summary>
        /// <param name="sub"></param>
        public void setSubtitle(String sub)
        {
            SubTitle.Content = sub;

            if (sub.Equals(""))
            {
                Title.FontSize = 60;
            }
            else
            {
                Title.FontSize = 40;
            }
        }

        /// <summary>
        ///     this method called when the back button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //topLevelPage.AnimateOut();
            //dt.Start();
            topLevelPage.BackButton_Click(sender, e);

            ResetTimer();
        }

        private void ResetTimer()
        {
            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException)
            {
            }
        }

        private void CCF_Button_Click(object sender, RoutedEventArgs e)
        {
            topLevelPage.HomeButton_Click();

            ResetTimer();
        }
    }
}