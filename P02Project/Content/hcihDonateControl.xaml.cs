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

            text.Content = oneOffContent();
		}

        private void oneOff_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Set the background colours of the buttons
            SolidColorBrush unsel = new SolidColorBrush(Util._pageColDict["hcihUnSelected"]);

            oneOff.Background = new SolidColorBrush(Util._pageColDict["hcihSelected"]);
            onGoing.Background = unsel;
            lastingLegacy.Background = unsel;
            workplaceGiving.Background = unsel;
            moreInfo.Background = unsel;

            text.Content = oneOffContent();
        }

        private void onGoing_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Set the background colours of the buttons
            SolidColorBrush unsel = new SolidColorBrush(Util._pageColDict["hcihUnSelected"]);

            oneOff.Background = unsel;
            onGoing.Background = new SolidColorBrush(Util._pageColDict["hcihSelected"]);
            lastingLegacy.Background = unsel;
            workplaceGiving.Background = unsel;
            moreInfo.Background = unsel;

            text.Content = onGoingContent();
        }

        private void lastingLegacy_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Set the background colours of the buttons
            SolidColorBrush unsel = new SolidColorBrush(Util._pageColDict["hcihUnSelected"]);

            oneOff.Background = unsel;
            onGoing.Background = unsel;
            lastingLegacy.Background = new SolidColorBrush(Util._pageColDict["hcihSelected"]);
            workplaceGiving.Background = unsel;
            moreInfo.Background = unsel;

            text.Content = lastingLegacyContent();
        }

        private void workplaceGiving_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Set the background colours of the buttons
            SolidColorBrush unsel = new SolidColorBrush(Util._pageColDict["hcihUnSelected"]);

            oneOff.Background = unsel;
            onGoing.Background = unsel;
            lastingLegacy.Background = unsel;
            workplaceGiving.Background = new SolidColorBrush(Util._pageColDict["hcihSelected"]); 
            moreInfo.Background = unsel;

            text.Content = workplaceGivingContent();
        }

        private void moreInfo_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Set the background colours of the buttons
            SolidColorBrush unsel = new SolidColorBrush(Util._pageColDict["hcihUnSelected"]);

            oneOff.Background = unsel;
            onGoing.Background = unsel;
            lastingLegacy.Background = unsel;
            workplaceGiving.Background = unsel;
            moreInfo.Background = new SolidColorBrush(Util._pageColDict["hcihSelected"]);

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
            oneOffText1.FontSize = 36;
            oneOffText1.Margin = new Thickness(10);
            oneOffText1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffffff"));
            oneOffText1.Inlines.Add(new Bold(new Run("Donate Online \n")));
            oneOffText1.Inlines.Add(new Run("You can make an online one-off donation through your credit card, it is simple, secure and super rewarding!\n"));
            oneOffText1.Inlines.Add(new Run("To donate online, go to https://support.childcancer.org.nz or scan the QR code below\n"));

            TextBlock oneOffText2 = new TextBlock();
            oneOffText2.TextAlignment = TextAlignment.Left;
            oneOffText2.Margin = new Thickness(10);
            oneOffText2.FontSize = 36;
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
            oneOffText1.FontSize = 36;
            oneOffText1.Margin = new Thickness(10);
            oneOffText1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffffff"));
            oneOffText1.Inlines.Add(new Bold(new Run("Donate Online \n")));
            oneOffText1.Inlines.Add(new Run("You can make an online one-off donation through your credit card, it is simple, secure and super rewarding!\n"));
            oneOffText1.Inlines.Add(new Run("To donate online, go to https://support.childcancer.org.nz or scan the QR code below\n"));

            TextBlock oneOffText2 = new TextBlock();
            oneOffText2.TextAlignment = TextAlignment.Left;
            oneOffText2.Margin = new Thickness(10);
            oneOffText2.FontSize = 36;
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

        private StackPanel lastingLegacyContent()
        {
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
            oneOffText1.FontSize = 36;
            oneOffText1.Margin = new Thickness(10);
            oneOffText1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffffff"));
            oneOffText1.Inlines.Add(new Bold(new Run("Donate Online \n")));
            oneOffText1.Inlines.Add(new Run("You can make an online one-off donation through your credit card, it is simple, secure and super rewarding!\n"));
            oneOffText1.Inlines.Add(new Run("To donate online, go to https://support.childcancer.org.nz or scan the QR code below\n"));

            TextBlock oneOffText2 = new TextBlock();
            oneOffText2.TextAlignment = TextAlignment.Left;
            oneOffText2.Margin = new Thickness(10);
            oneOffText2.FontSize = 36;
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

        private StackPanel workplaceGivingContent()
        {
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
            oneOffText1.FontSize = 36;
            oneOffText1.Margin = new Thickness(10);
            oneOffText1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffffff"));
            oneOffText1.Inlines.Add(new Bold(new Run("Donate Online \n")));
            oneOffText1.Inlines.Add(new Run("You can make an online one-off donation through your credit card, it is simple, secure and super rewarding!\n"));
            oneOffText1.Inlines.Add(new Run("To donate online, go to https://support.childcancer.org.nz or scan the QR code below\n"));

            TextBlock oneOffText2 = new TextBlock();
            oneOffText2.TextAlignment = TextAlignment.Left;
            oneOffText2.Margin = new Thickness(10);
            oneOffText2.FontSize = 36;
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

        private StackPanel moreInfoContent()
        {
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
            oneOffText1.FontSize = 36;
            oneOffText1.Margin = new Thickness(10);
            oneOffText1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffffff"));
            oneOffText1.Inlines.Add(new Bold(new Run("Donate Online \n")));
            oneOffText1.Inlines.Add(new Run("You can make an online one-off donation through your credit card, it is simple, secure and super rewarding!\n"));
            oneOffText1.Inlines.Add(new Run("To donate online, go to https://support.childcancer.org.nz or scan the QR code below\n"));

            TextBlock oneOffText2 = new TextBlock();
            oneOffText2.TextAlignment = TextAlignment.Left;
            oneOffText2.Margin = new Thickness(10);
            oneOffText2.FontSize = 36;
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
	}
}