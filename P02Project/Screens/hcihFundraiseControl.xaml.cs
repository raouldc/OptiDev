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
using System.Windows.Media.Effects;
using P02Project.Utils;
using System.Windows.Media.Animation;

namespace P02Project
{
	/// <summary>
	/// Interaction logic for hcihBeads.xaml
	/// </summary>
    public partial class hcihFundraiseControl : UserControl, Animatiable
	{
        private Storyboard sbIn;
        /// <summary>
        /// Constructor
        /// </summary>
        public hcihFundraiseControl()
		{
			this.InitializeComponent();
            
            // set image
            donate.setImage("images\\HowCanIHelp\\fundraise.png");

            //set text
            text.Content = GenerateContent();

            sbIn = new Storyboard();

            DoubleAnimation da = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromMilliseconds(200)));

            sbIn.Children.Add(da);

            Storyboard.SetTarget(da, text);
            Storyboard.SetTargetProperty(da, new PropertyPath(FrameworkElement.OpacityProperty));
		}

        private TextBlock TextBlockFactory()
        {
            TextBlock tb = new TextBlock();
            tb.TextAlignment = TextAlignment.Left;
            tb.FontSize = 24;
            tb.Margin = new Thickness(10);
            tb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffffff"));
            tb.TextWrapping = TextWrapping.Wrap;

            return tb;
        }

        private StackPanel GenerateContent()
        {
            StackPanel content = new StackPanel();

            TextBlock tb = TextBlockFactory();

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

        void Animatiable.AnimateIn()
        {
            donate.AnimateIn();
            sbIn.Begin(this);
        }

        void Animatiable.AnimateOut()
        {
        }
    }
}