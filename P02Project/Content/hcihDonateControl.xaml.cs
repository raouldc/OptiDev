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

namespace P02Project
{
	/// <summary>
	/// Interaction logic for hcihDonateControl.xaml
	/// </summary>
	public partial class hcihDonateControl : UserControl
	{
		public hcihDonateControl()
		{
			this.InitializeComponent();
            donate.setImage("donate.png");

            //Set button cols
            SolidColorBrush unsel = new SolidColorBrush(Util._pageColDict["hcihUnSelected"]);

            oneOff.Background = new SolidColorBrush(Util._pageColDict["hcihSelected"]);
            onGoing.Background = unsel;
            lastingLegacy.Background = unsel;
            workplaceGiving.Background = unsel;
            moreInfo.Background = unsel;
            //set content
            text.Content = oneOffContent();
		}

        private void oneOff_Click(object sender, RoutedEventArgs e)
        {
            //Set the background colours of the buttons
            SolidColorBrush unsel = new SolidColorBrush(Util._pageColDict["hcihUnSelected"]);

            oneOff.Background = new SolidColorBrush(Util._pageColDict["hcihSelected"]);
            onGoing.Background = unsel;
            lastingLegacy.Background = unsel;
            workplaceGiving.Background = unsel;
            moreInfo.Background = unsel;

            //remove drop shadow from other buttons
            oneOff.Effect = null;
            onGoing.Effect = null;
            lastingLegacy.Effect = null;
            workplaceGiving.Effect = null;
            moreInfo.Effect = null;

            //add drop shadow
            oneOff.Effect = new DropShadowEffect(); 

            text.Content = oneOffContent();
        }

        private void onGoing_Click(object sender, RoutedEventArgs e)
        {
            //Set the background colours of the buttons
            SolidColorBrush unsel = new SolidColorBrush(Util._pageColDict["hcihUnSelected"]);

            oneOff.Background = unsel;
            onGoing.Background = new SolidColorBrush(Util._pageColDict["hcihSelected"]);
            lastingLegacy.Background = unsel;
            workplaceGiving.Background = unsel;
            moreInfo.Background = unsel;

            //remove drop shadow from other buttons
            oneOff.Effect = null;
            onGoing.Effect = null;
            lastingLegacy.Effect = null;
            workplaceGiving.Effect = null;
            moreInfo.Effect = null;

            //add drop shadow
            onGoing.Effect = new DropShadowEffect(); 

            text.Content = onGoingContent();
        }

        private void lastingLegacy_Click(object sender, RoutedEventArgs e)
        {
            //Set the background colours of the buttons
            SolidColorBrush unsel = new SolidColorBrush(Util._pageColDict["hcihUnSelected"]);

            oneOff.Background = unsel;
            onGoing.Background = unsel;
            lastingLegacy.Background = new SolidColorBrush(Util._pageColDict["hcihSelected"]);
            workplaceGiving.Background = unsel;
            moreInfo.Background = unsel;

            //remove drop shadow from other buttons
            oneOff.Effect = null;
            onGoing.Effect = null;
            lastingLegacy.Effect = null;
            workplaceGiving.Effect = null;
            moreInfo.Effect = null;

            //add drop shadow
            lastingLegacy.Effect = new DropShadowEffect(); 

            text.Content = lastingLegacyContent();
        }

        private void workplaceGiving_Click(object sender, RoutedEventArgs e)
        {
            //Set the background colours of the buttons
            SolidColorBrush unsel = new SolidColorBrush(Util._pageColDict["hcihUnSelected"]);

            oneOff.Background = unsel;
            onGoing.Background = unsel;
            lastingLegacy.Background = unsel;
            workplaceGiving.Background = new SolidColorBrush(Util._pageColDict["hcihSelected"]); 
            moreInfo.Background = unsel;
            
            //remove drop shadow from other buttons
            oneOff.Effect = null;
            onGoing.Effect = null;
            lastingLegacy.Effect = null;
            workplaceGiving.Effect = null;
            moreInfo.Effect = null;

            //add drop shadow
            workplaceGiving.Effect = new DropShadowEffect(); 

            text.Content = workplaceGivingContent();
        }

        private void moreInfo_Click(object sender, RoutedEventArgs e)
        {
            //Set the background colours of the buttons
            SolidColorBrush unsel = new SolidColorBrush(Util._pageColDict["hcihUnSelected"]);

            oneOff.Background = unsel;
            onGoing.Background = unsel;
            lastingLegacy.Background = unsel;
            workplaceGiving.Background = unsel;
            moreInfo.Background = new SolidColorBrush(Util._pageColDict["hcihSelected"]);
            
            //remove drop shadow from other buttons
            oneOff.Effect = null;
            onGoing.Effect = null;
            lastingLegacy.Effect = null;
            workplaceGiving.Effect = null;
            moreInfo.Effect = null;

            //add drop shadow
            moreInfo.Effect = new DropShadowEffect();

            

            text.Content = moreInfoContent();
        }

        private StackPanel oneOffContent() {
            //Set content to one off donation
            StackPanel contentStackPanel = new StackPanel();
            Image qrCode = new Image();
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("pack://application:,,/Resources/qrcode_Donate.png");
            src.EndInit();

            qrCode.Source = src;
            qrCode.Height = 200;
            qrCode.Width = 200;
            qrCode.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            qrCode.Margin = new Thickness(10);

            TextBlock oneOffText1 = new TextBlock();
            oneOffText1.TextAlignment = TextAlignment.Left;
            oneOffText1.FontSize = 24;
            oneOffText1.Margin = new Thickness(10);
            oneOffText1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffffff"));
            oneOffText1.Inlines.Add(new Bold(new Run("Donate Online \n")));
            oneOffText1.Inlines.Add(new Run("You can make an online one-off donation through your credit card, it is simple, secure and super rewarding!\n"));
            oneOffText1.Inlines.Add(new Run("To donate online, go to https://support.childcancer.org.nz or scan the QR code below\n"));

            TextBlock oneOffText2 = new TextBlock();
            oneOffText2.TextAlignment = TextAlignment.Left;
            oneOffText2.Margin = new Thickness(10);
            oneOffText2.FontSize = 24;
            oneOffText2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffffff"));
            oneOffText2.Inlines.Add(new Bold(new Run("\nPlease note: ")));
            oneOffText2.Inlines.Add(new Run("Enter a whole dollar amount only containing no decimal points."));
            oneOffText2.Inlines.Add(new Bold(new Run("\n\nDonate By Text \n")));
            oneOffText2.Inlines.Add(new Run("Please text 'bead' to 206 to make a $3 donation"));

            contentStackPanel.Children.Add(oneOffText1);
            contentStackPanel.Children.Add(qrCode);
            contentStackPanel.Children.Add(oneOffText2);
            return contentStackPanel;
        }

        private StackPanel onGoingContent()
        {
            //Set content to on going donation
            StackPanel contentStackPanel = new StackPanel();
            
            TextBlock onGoingText1 = new TextBlock();
            onGoingText1.TextAlignment = TextAlignment.Left;
            onGoingText1.FontSize = 24;
            onGoingText1.Margin = new Thickness(10);
            onGoingText1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffffff"));
            onGoingText1.Inlines.Add(new Bold(new Run("Making An On-going Donation \n")));
            onGoingText1.Inlines.Add(new Run("Become a regular supporter of Child Cancer Foundation by setting up a regular donation from your credit card or bank account. This is just as simple and secure as making a one-off donation and can all be done online.  You can pledge any donation amount big or small on a weekly, monthly or quarterly basis, whatever suits you.  You will receive regular tax receipts to help with your annual tax rebate.\n\n"));
            onGoingText1.Inlines.Add(new Run("At anytime you can change your pledge of donation amount and frequency. \n\n"));
            onGoingText1.Inlines.Add(new Run("Every regular donation, no matter how big or small, helps us continue to support our children and families affected by this traumatic disease. \n\n"));
            onGoingText1.Inlines.Add(new Run("To become a regular supporter please contact:  \n\n"));
            onGoingText1.Inlines.Add(new Bold(new Run("Sophie Armitage PHN ")));
            onGoingText1.Inlines.Add(new Run("09 303 9972 | "));
            onGoingText1.Inlines.Add(new Bold(new Run("EML ")));
            onGoingText1.Inlines.Add(new Run("sarmitage@childcancer.org.nz\n"));

    
            contentStackPanel.Children.Add(onGoingText1);
            return contentStackPanel;
        }

        private StackPanel lastingLegacyContent()
        {
            //Set content to on going donation
            StackPanel contentStackPanel = new StackPanel();

            TextBlock lastinLegacyText1 = new TextBlock();
            lastinLegacyText1.TextAlignment = TextAlignment.Left;
            lastinLegacyText1.FontSize = 24;
            lastinLegacyText1.Margin = new Thickness(10);
            lastinLegacyText1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffffff"));
            lastinLegacyText1.Inlines.Add(new Bold(new Run("A Lasting Legacy \n")));
            lastinLegacyText1.Inlines.Add(new Run("We are grateful that you are considering a bequest or legacy, to assist Child Cancer Foundation in continuing our work. We rely on the generosity of New Zealanders to fund our Child Cancer Services throughout New Zealand. Bequests or legacies are a very important source of funds to ensure our service continues to the highest possible level for our children and families, now and well into the future.\n\n"));
            lastinLegacyText1.Inlines.Add(new Run("Your bequest could help to: \n"));
            lastinLegacyText1.Inlines.Add(new Run("- Directly support a child’s cancer journey\n"));
            lastinLegacyText1.Inlines.Add(new Run("- Help fund the Beads of Courage® programme\n"));
            lastinLegacyText1.Inlines.Add(new Run("- Assist a child’s education back to school\n"));
            lastinLegacyText1.Inlines.Add(new Run("- Support our families\n"));
            lastinLegacyText1.Inlines.Add(new Run("- Contribute towards research\n"));
            lastinLegacyText1.Inlines.Add(new Run("- Protect the future of Child Cancer Foundation\n\n"));
            lastinLegacyText1.Inlines.Add(new Run("If you have already decided on leaving a bequest, making a will is the only way to ensure your wishes will be met in relation to the distribution of your assets or estate. A will also helps to avoid confusion over your intentions and gives you peace of mind.\n"));


            contentStackPanel.Children.Add(lastinLegacyText1);
            return contentStackPanel;
        }

        private StackPanel workplaceGivingContent()
        {
            //Set content to on going donation
            StackPanel contentStackPanel = new StackPanel();

            TextBlock workplaceGivingText1 = new TextBlock();
            workplaceGivingText1.TextAlignment = TextAlignment.Left;
            workplaceGivingText1.FontSize = 24;
            workplaceGivingText1.Margin = new Thickness(10);
            workplaceGivingText1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffffff"));
            workplaceGivingText1.Inlines.Add(new Bold(new Run("Workplace Giving \n")));
            workplaceGivingText1.Inlines.Add(new Run("Workplace giving is a wonderful opportunity for you as an employee to give a regular donation to Child Cancer Foundation from your salary.  It is a simple process organised through your company with your chosen donation amount transfered from your salary to Child Cancer Foundation each pay period eliminating any need to retain tax receipts for each donation. \n\n"));
            workplaceGivingText1.Inlines.Add(new Run("Choose Child Cancer Foundation as your charity of choice at your workplace, and encouraging your co-workers to do the same. It is an easy way for you to support children with cancer and their families. \n\n"));
            workplaceGivingText1.Inlines.Add(new Run("For more information on workplace giving please contact:  \n\n"));
            workplaceGivingText1.Inlines.Add(new Bold(new Run("Sophie Armitage PHN ")));
            workplaceGivingText1.Inlines.Add(new Run("09 303 9972 | "));
            workplaceGivingText1.Inlines.Add(new Bold(new Run("EML ")));
            workplaceGivingText1.Inlines.Add(new Run("sarmitage@childcancer.org.nz\n"));


            contentStackPanel.Children.Add(workplaceGivingText1);
            return contentStackPanel;
        }

        private StackPanel moreInfoContent()
        {
            //Set content to on going donation
            StackPanel contentStackPanel = new StackPanel();

            TextBlock onGoingText1 = new TextBlock();
            onGoingText1.TextAlignment = TextAlignment.Left;
            onGoingText1.FontSize = 24;
            onGoingText1.Margin = new Thickness(10);
            onGoingText1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffffff"));
            onGoingText1.Inlines.Add(new Bold(new Run("More Information \n")));
            onGoingText1.Inlines.Add(new Run("If you are ready to write your will, visit http://www.childcancer.org.nz/getattachment/How-you-can-help/Donate/Bequest.pdf.aspx for some official wording to assist you. \n\n"));
            onGoingText1.Inlines.Add(new Run("Thank you so much for considering leaving a gift to Child Cancer Foundation in your will. If you do decide to leave a legacy or bequest to help support our Child Cancer services, please let us know as this will allow us to thank you for your gift and offer you a closer relationship with us. It does not, however, legally bind you to support us in any way and the information will be treated in the strictest of confidence. \n\n"));
            
            onGoingText1.Inlines.Add(new Run("For more information please contact:  \n\n"));
            onGoingText1.Inlines.Add(new Bold(new Run("Darragh O'Riordan PHN ")));
            onGoingText1.Inlines.Add(new Run("09 303 9882 | "));
            onGoingText1.Inlines.Add(new Bold(new Run("EML ")));
            onGoingText1.Inlines.Add(new Run("doriordan@childcancer.org.nz\n"));


            contentStackPanel.Children.Add(onGoingText1);
            return contentStackPanel;
        }
	}
}