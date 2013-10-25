using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Effects;
using System.Windows.Media.Animation;
using P02Project.Utils;

namespace P02Project
{
	/// <summary>
	/// Interaction logic for hcihBeads.xaml
	/// </summary>
	public partial class hcihGiftControl : UserControl, Animatiable
	{
        private SolidColorBrush unsel;
        private SolidColorBrush sel;

        private Storyboard sbIn;

        /// <summary>
        /// Constructor
        /// </summary>
        public hcihGiftControl()
		{
			this.InitializeComponent();
            
            // set image
            donate.setImage("images\\HowCanIHelp\\gift.png");

            //Set button cols
            unsel = new SolidColorBrush(Util._pageColDict["hcihUnSelected"]);
            sel = new SolidColorBrush(Util._pageColDict["hcihSelected"]);

            text.Background = new SolidColorBrush(Util.contentBgColor);
            text.Margin = Util.contentMargin;

            soc.FontFamily = Util.buttonTextFont;
            boc.FontFamily = Util.buttonTextFont;

            soc.FontSize = Util.buttonTextSize;
            boc.FontSize = Util.buttonTextSize;

            soc.Foreground = new SolidColorBrush(Util.buttonTextColor);
            boc.Foreground = new SolidColorBrush(Util.buttonTextColor);

            // Making the poloroid on this screen not clickable
            donate.removeTouch();
            donate.setShadow(10, 0.3, (Color)ColorConverter.ConvertFromString("#ff7f7f7f"));

            //set content
            soc_Click(this, null);

            // Setting up the animations of some of the components
            sbIn = new Storyboard();
            Util.StackAnimationDefault(sbIn, buttons.Children);
            Util.FadeIn(sbIn, text);
		}

        /// <summary>
        /// unselect all giftControl items
        /// </summary>
        private void SetAllUnsel()
        {
            soc.Background = unsel;
            boc.Background = unsel;

            soc.Effect = null;
            boc.Effect = null;
        }

        /// <summary>
        /// Puts the Star of courage content on the screen
        /// </summary>
        /// <returns>A Dynamically created StackPanel object that contains the runs of strings and images</returns>
        private StackPanel socContent()
        {
            StackPanel content = new StackPanel();

            Image qrCode = new Image();
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("pack://application:,,/Resources/images/HowCanIHelp/qr_soc.png");
            src.EndInit();

            //QR code that points to the link
            qrCode.Source = src;
            qrCode.Height = 200;
            qrCode.Width = 200;
            qrCode.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            qrCode.Margin = new Thickness(10);

            TextBlock tb = Util.TextBlockFactory();
            
            //Text Content
            tb.Inlines.Add(new Run("Make a $500 donation and gift a star to directly support a child’s cancer journey."
                                    + "\n\nStars of Courage is a unique programme which will see each child diagnosed "
                                    + "with cancer offered a dedicated star.\n\nEach child will receive the name of th"
                                    + "eir star, its coordinates in the sky and information on its constellation or gr"
                                    + "ouping.  They can then visit any observatory in New Zealand and use the telesco"
                                    + "pe to locate their star.\n\nMoney raised will help fund the $6 million required"
                                    + " each year for child and family support services in New Zealand.\n\nTo make a d"
                                    + "onation, visit http://tinyurl.com/n7bhk5h or scan the "
                                    + "QR code below"));

            //Add the text first and then the iamge below it
            content.Children.Add(tb);
            content.Children.Add(qrCode);
            return content;
        }

        /// <summary>
        /// Dynamically generates the Beads of Courage content
        /// </summary>
        /// <returns>StackPanel Object that contents the text and images</returns>
        private StackPanel bocContent()
        {
            StackPanel content = new StackPanel();

            Image qrCode = new Image();
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("pack://application:,,/Resources/images/HowCanIHelp/qr_boc.png");
            src.EndInit();

            qrCode.Source = src;
            qrCode.Height = 200;
            qrCode.Width = 200;
            qrCode.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            qrCode.Margin = new Thickness(10);

            TextBlock tb = Util.TextBlockFactory();
            tb.Inlines.Add(new Run("Make a $5 donation and gift a Bead of Courage® to a child with cancer to directly supp"
                                    + "ort a child’s cancer journey.\n\nOn average three children in New Zealand are diagn"
                                    + "osed with cancer each week.  These children undergo an astounding 100,000 treatment"
                                    + "s and procedures each year.  For every treatment and procedure a child endures they"
                                    + " receive a bead of courage.\n\nBeads of Courage® is a unique programme designed to "
                                    + "honour the challenging journey children take while receiving care for cancer.  Each"
                                    + " collection of beads symbolises the courage and honours the milestones achieved alo"
                                    + "ng the treatment path.\n\nTo make a d"
                                    + "onation, visit http://tinyurl.com/m5axzgt or scan the "
                                    + "QR code below"));

            content.Children.Add(tb);
            content.Children.Add(qrCode);
            return content;
        }

        /// <summary>
        /// Need to animate the poloroid and the other components
        /// </summary>
        void Animatiable.AnimateIn()
        {
            sbIn.Begin();
            donate.AnimateIn();
        }

        /// <summary>
        /// Do nothing
        /// </summary>
        void Animatiable.AnimateOut()
        {
        }

        /// <summary>
        /// handler for soc control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soc_Click(object sender, RoutedEventArgs e)
        {
            SetAllUnsel();
            soc.Background = sel;
            //add drop shadow
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            soc.Effect = dShdow;

            text.Content = socContent();

            ResetTimer();
        }

        /// <summary>
        /// This function resets the timeout
        /// </summary>
        private void ResetTimer()
        {
            //To reset the timer
            try
            {
                (Window.GetWindow(this) as TopWindow).ResetTimer();
            }
            catch (NullReferenceException)
            {
            }
        }

        /// <summary>
        /// handler for boc control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boc_Click(object sender, RoutedEventArgs e)
        {
            SetAllUnsel();
            boc.Background = sel;
            //add drop shadow
            DropShadowEffect dShdow = new DropShadowEffect();
            dShdow.BlurRadius = 10;
            dShdow.Opacity = 0.365;
            boc.Effect = dShdow;

            text.Content = bocContent();

            ResetTimer();
        }
    }
}