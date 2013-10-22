﻿using System;
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

            //set content
            soc_Click(this, null);

            int count = 0;

            sbIn = new Storyboard();

            foreach (Button b in buttons.Children)
            {
                ThicknessAnimation stackIn;
                stackIn = new ThicknessAnimation();
                stackIn.From = new Thickness(-1000, 20, 20, 20);
                stackIn.To = new Thickness(20, 20, 20, 20);
                stackIn.Duration = new Duration(TimeSpan.FromMilliseconds(200 + 50 * (count++)));

                sbIn.Children.Add(stackIn);
                //storyboard animations
                Storyboard.SetTarget(stackIn, b);
                Storyboard.SetTargetProperty(stackIn, new PropertyPath(StackPanel.MarginProperty));
            }

            DoubleAnimation opa = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromMilliseconds(200)));
            sbIn.Children.Add(opa);

            Storyboard.SetTarget(opa, text);
            Storyboard.SetTargetProperty(opa, new PropertyPath(PoloroidControl.OpacityProperty));
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
        /// create a new text block
        /// </summary>
        /// <returns>
        /// new textblock with required formatting
        /// </returns>
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
        /// <summary>
        /// add content to the page
        /// </summary>
        /// <returns>
        /// stackpanel with required content
        /// </returns>
        private StackPanel socContent()
        {
            StackPanel content = new StackPanel();

            Image qrCode = new Image();
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("pack://application:,,/Resources/images/HowCanIHelp/qr_soc.png");
            src.EndInit();

            qrCode.Source = src;
            qrCode.Height = 200;
            qrCode.Width = 200;
            qrCode.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            qrCode.Margin = new Thickness(10);

            TextBlock tb = TextBlockFactory();
            //TODO - put into xml
            tb.Inlines.Add(new Run("Make a $500 donation and gift a star to directly support a child’s cancer journey."
                                    + "\n\nStars of Courage is a unique programme which will see each child diagnosed "
                                    + "with cancer offered a dedicated star.\n\nEach child will receive the name of th"
                                    + "eir star, its coordinates in the sky and information on its constellation or gr"
                                    + "ouping.  They can then visit any observatory in New Zealand and use the telesco"
                                    + "pe to locate their star.\n\nMoney raised will help fund the $6 million required"
                                    + " each year for child and family support services in New Zealand.\n\nTo make a d"
                                    + "onation, visit https://support.childcancer.org.nz/stars-of-courage or scan the "
                                    + "QR code below"));

            content.Children.Add(tb);
            content.Children.Add(qrCode);
            return content;
        }

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

            TextBlock tb = TextBlockFactory();
            tb.Inlines.Add(new Run("Make a $5 donation and gift a Bead of Courage® to a child with cancer to directly supp"
                                    + "ort a child’s cancer journey.\n\nOn average three children in New Zealand are diagn"
                                    + "osed with cancer each week.  These children undergo an astounding 100,000 treatment"
                                    + "s and procedures each year.  For every treatment and procedure a child endures they"
                                    + " receive a bead of courage.\n\nBeads of Courage® is a unique programme designed to "
                                    + "honour the challenging journey children take while receiving care for cancer.  Each"
                                    + " collection of beads symbolises the courage and honours the milestones achieved alo"
                                    + "ng the treatment path.\n\nTo make a d"
                                    + "onation, visit https://support.childcancer.org.nz/beads-of-courage or scan the "
                                    + "QR code below"));

            content.Children.Add(tb);
            content.Children.Add(qrCode);
            return content;
        }

        void Animatiable.AnimateIn()
        {
            sbIn.Begin();
            donate.AnimateIn();
        }

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
            soc.Effect = new DropShadowEffect();

            text.Content = socContent();
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
            boc.Effect = new DropShadowEffect();

            text.Content = bocContent();
        }
    }
}