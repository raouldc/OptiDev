﻿#region

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using P02Project.Utils;

#endregion

namespace P02Project
{
    /// <summary>
    ///     Interaction logic for hcihBeads.xaml
    /// </summary>
    public partial class hcihFundraiseControl : UserControl, Animatiable
    {
        private readonly Storyboard sbIn;

        /// <summary>
        ///     Constructor
        /// </summary>
        public hcihFundraiseControl()
        {
            InitializeComponent();

            // set image
            donate.setImage("images\\HowCanIHelp\\fundraise.png");

            text.Background = new SolidColorBrush(Util.contentBgColor);
            text.Margin = Util.contentMargin;
            //set text
            text.Content = GenerateContent();

            donate.removeTouch();
            donate.setShadow(10, 0.3, (Color) ColorConverter.ConvertFromString("#ff7f7f7f"));

            // Fade in animation for the text area
            sbIn = new Storyboard();
            Util.FadeIn(sbIn, text);
        }

        /// <summary>
        ///     begin the animation
        /// </summary>
        void Animatiable.AnimateIn()
        {
            donate.AnimateIn();
            sbIn.Begin(this);
        }

        /// <summary>
        ///     Do nothing
        /// </summary>
        void Animatiable.AnimateOut()
        {
        }

        /// <summary>
        ///     genreate all the content needed for this view
        /// </summary>
        /// <returns>
        ///     stackpanel with required content
        /// </returns>
        private StackPanel GenerateContent()
        {
            StackPanel content = new StackPanel();

            TextBlock tb = Util.TextBlockFactory();
            //data
            //TODO - move to xml
            tb.Inlines.Add(new Run("Holding a fundraising event is making a difference!\n\n"));
            tb.Inlines.Add(new Bold(new Run("FUN")));
            tb.Inlines.Add(new Run("draising is about having fun and finding a way to raise money for "
                                   + "children with cancer and their families who are in need.  This "
                                   + "is a rewarding way to show your support and getting others invo"
                                   + "lved.\n\nYour fundraiser can be organised within your workplace"
                                   + ", community, school or could even be something you decide to do"
                                   + " as an individual or group.  Sharing your idea and getting othe"
                                   + "rs involved to raise funds for Child Cancer Foundation spreads "
                                   + "the word about your fundraising activity but also raises awaren"
                                   + "ess about the cause.\n\nHowever big or small, every fundraiser "
                                   + "counts so let your imagination run WILD!\n\nHere are just a few"
                                   + " fundraising ideas:\n- Corporate event - boxing, head shaving e"
                                   + "tc\n- Sporting event - golfing, bowls etc\n- Art Auction\n- Cha"
                                   + "rity Ball\n- High Tea or Luncheon\n- Fun run or walk\n- Sponsor"
                                   + " an individual completing a challenging activity (Marathons, fu"
                                   + "n runs etc)\n\nContact Us and share yourfund raising idea!"));

            content.Children.Add(tb);
            return content;
        }

        /// <summary>
        ///     Reset the timer when the user scrolls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void text_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException)
            {
            }
        }
    }
}