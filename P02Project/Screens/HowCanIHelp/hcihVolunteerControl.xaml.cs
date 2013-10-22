using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using P02Project.Utils;

namespace P02Project
{
	/// <summary>
	/// Interaction logic for hcihBeads.xaml
	/// </summary>
	public partial class hcihVolunteerControl : UserControl, Animatiable
	{
        private Storyboard sbIn;
        /// <summary>
        /// Constructor
        /// </summary>
        public hcihVolunteerControl()
		{
			this.InitializeComponent();
            
            // set image
            donate.setImage("images/Home/howCanIHelp.png");

            text.Background = new SolidColorBrush(Util.contentBgColor);
            text.Margin = Util.contentMargin;
            //set text
            text.Content = GenerateContent();

            //animate
            sbIn = new Storyboard();
            Util.FadeIn(sbIn, text);
            Util.FadeIn(sbIn, QRCode);
            Util.FadeIn(sbIn, QRText);
		}

        //private TextBlock TextBlockFactory()
        //{
        //    TextBlock tb = new TextBlock();
        //    tb.TextAlignment = TextAlignment.Left;
        //    tb.FontSize = 24;
        //    tb.Margin = new Thickness(10);
        //    tb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffffff"));
        //    tb.TextWrapping = TextWrapping.Wrap;

        //    return tb;
        //}

        private StackPanel GenerateContent()
        {
            StackPanel content = new StackPanel();

            TextBlock tb = Util.TextBlockFactory();

            tb.Inlines.Add(new Bold(new Run("What is volunteering?")));
            tb.Inlines.Add(new Run("\nVolunteering provides a wonderful opportunity for people to meet, contribute and support a common " +
                                   "cause.\n\nVolunteers are vital to us at Child Cancer Foundation. They help us to achieve our purpose" +
                                   " by offering their time, skills and valuable advice."));

            tb.Inlines.Add(new Bold(new Run("\n\nWhat sort of people volunteer for CCF?")));
            tb.Inlines.Add(new Run("\nCCF volunteers are ordinary people who come from a wide range of backgrounds and age groups. Some " +
                                   "are parents, relatives or friends of families who have experienced the childhood cancer journey; som" +
                                   "e are from businesses and the public. Volunteers are interested in supporting our objectives, have a" +
                                   " desire to support children with cancer and their families and help raise funds."));

            tb.Inlines.Add(new Bold(new Run("\n\nWhat do CCF volunteers do?")));
            tb.Inlines.Add(new Run("\nOur volunteers provide a range of services and support including participating in CCF Branch activit" +
                                   "ies, helping out at the Family Places, working alongside our staff and helping our fundraising team " +
                                   "during events such as the national Annual Street Appeal and Funrazor events."));

            tb.Inlines.Add(new Bold(new Run("\n\nHow much time is required?")));
            tb.Inlines.Add(new Run("\nThis depends on how much time you are able to give, and whether you would like to volunteer on a reg" +
                                   "ular basis or purely for one-off events. Your local Volunteer coordinator/manager can provide you with" +
                                   " more information."));

            content.Children.Add(tb);
            return content;
        }

        public void AnimateIn()
        {
            sbIn.Begin(this);
            donate.AnimateIn();
        }

        public void AnimateOut()
        {
        }
	}
}