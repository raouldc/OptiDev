using System;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Controls;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Surface.Presentation.Controls;
using System.Windows.Documents;

namespace P02Project
{
    public static class Util
    {
        // the dictionary of the color of each section
        public static readonly Dictionary<string, Color> _pageColDict = new Dictionary<string, Color>{
            //red
            { "About",              (Color)ColorConverter.ConvertFromString("#FFff353a")},
            { "abtSelected",        (Color)ColorConverter.ConvertFromString("#FFff353a")},
            { "abtUnSelected",      (Color)ColorConverter.ConvertFromString("#FFff9093")},

            //blue
            { "Family Support",     (Color)ColorConverter.ConvertFromString("#FF4679f0")}, //(Color)ColorConverter.ConvertFromString("#ff381f9c")},
            { "fsSelected",         (Color)ColorConverter.ConvertFromString("#FF4679f0")}, //(Color)ColorConverter.ConvertFromString("#FF1d0b68")},
            { "fsUnSelected",       (Color)ColorConverter.ConvertFromString("#FF9ebbff")}, //(Color)ColorConverter.ConvertFromString("#FF6b53ce")},

            //yellow
            { "How Can I Help?",    (Color)ColorConverter.ConvertFromString("#FFffdf35")},
            { "hcihSelected",       (Color)ColorConverter.ConvertFromString("#FFffdf35")},
            { "hcihUnSelected",     (Color)ColorConverter.ConvertFromString("#FFffed90")},
            //pink
            { "News",               (Color)ColorConverter.ConvertFromString("#fff83487")},
            { "nwsSelected",        (Color)ColorConverter.ConvertFromString("#FFf83487")},
            { "nwsUnSelected",      (Color)ColorConverter.ConvertFromString("#FFfc8ebc")},
            //green
            { "Events",             (Color)ColorConverter.ConvertFromString("#ff33f455")},
            { "evtSelected",        (Color)ColorConverter.ConvertFromString("#FF33f455")},
            { "evtUnSelected",      (Color)ColorConverter.ConvertFromString("#FF8dfaa0")},
            //orange
            { "Contact Us",         (Color)ColorConverter.ConvertFromString("#FFff8d35")},
            { "cuSelected",         (Color)ColorConverter.ConvertFromString("#FFff8d35")},
            { "cuUnSelected",       (Color)ColorConverter.ConvertFromString("#FFffc090")},
            //purple
            { "Beads of Courage",         (Color)ColorConverter.ConvertFromString("#ff9841f0")},
            { "pbSelected",         (Color)ColorConverter.ConvertFromString("#ff9841f0")},
            { "pbUnSelected",       (Color)ColorConverter.ConvertFromString("#ffc594f8")},

            //twitter
            { "Twitter",              (Color)ColorConverter.ConvertFromString("#ff3ea5ee")},
            { "twtSelected",      (Color)ColorConverter.ConvertFromString("#FF3ea5ee")},
            { "twtUnSelected",    (Color)ColorConverter.ConvertFromString("#FF92cdf6")},

            { "Extra",              (Color)ColorConverter.ConvertFromString("#ff146290")},
            { "extraSelected",      (Color)ColorConverter.ConvertFromString("#FF073f60")},
            { "extraUnSelected",    (Color)ColorConverter.ConvertFromString("#FF4899c8")}
        };

        ///////////////////
        //Text attributes

        //Content
        public static readonly FontFamily contentTextFont = new FontFamily("Segoe UI");
        public static readonly Color contentTextColor = (Color)ColorConverter.ConvertFromString("#FF000000");
        public static readonly Color contentBgColor = (Color)ColorConverter.ConvertFromString("#7Fffffff");
        public static readonly Thickness contentMargin = new Thickness(30);
        public static readonly double contentTextSize = 24;
        public static readonly double headingTextSize = 30;
        
        //left Buttons
        public static readonly FontFamily buttonTextFont = new FontFamily("Segoe UI");
        public static readonly Color buttonTextColor = (Color)ColorConverter.ConvertFromString("#FF000000");
        public static readonly double buttonTextSize = 40;

        //Creates content text blocks
        public static TextBlock TextBlockFactory()
        {
            TextBlock textB = new TextBlock();
            textB.TextWrapping = TextWrapping.Wrap;
            textB.TextAlignment = TextAlignment.Left;
            textB.FontSize = contentTextSize;
            textB.FontFamily = contentTextFont;
            textB.Margin = contentMargin;
            textB.Foreground = new SolidColorBrush(contentTextColor);
            return textB;
        }

        //////////////
        //Map 
        public static readonly ApplicationIdCredentialsProvider MapProvider = new ApplicationIdCredentialsProvider("AtabbySpgE9zdS1c5C4Pp1FHWjbxM_nHqIBmfZ--pFwtM0Vddbw7-bfUMBW-FBao");

        /// <summary>
        /// return the list of the links of the buttons
        /// </summary>
        /// <param name="exclude"></param>
        /// <returns></returns>
        public static String[] getLinks(String exclude)
        {
            var links = new List<string>(new[] { "About", "Family Support", "How Can I Help?", "News", "Events", "Beads of Courage", "Contact Us", "Twitter" });

            links.Remove(exclude);
            return links.ToArray();
        }

        public static readonly int animationMilisecs = 200;
        public static readonly int animationDelay = 50;

        public static void StackAnimation(Storyboard sbIn, UIElementCollection buttons, Thickness from, Thickness to)
        {
            int count = 0;

            foreach (Button b in buttons)
            {
                ThicknessAnimation stackIn;
                stackIn = new ThicknessAnimation();
                stackIn.From = from;
                stackIn.To = to;
                stackIn.Duration = new Duration(TimeSpan.FromMilliseconds(animationMilisecs + animationDelay * (count++)));

                sbIn.Children.Add(stackIn);
                //add animations to the storyboard
                Storyboard.SetTarget(stackIn, b);
                Storyboard.SetTargetProperty(stackIn, new PropertyPath(StackPanel.MarginProperty));
            }
        }

        public static void StackAnimationDefault(Storyboard sbIn, UIElementCollection buttons)
        {
            StackAnimation(sbIn, buttons, new Thickness(-1000, 20, 20, 20), new Thickness(20, 20, 20, 20));
        }

        public static void FadeIn(Storyboard sb, UIElement element)
        {
            DoubleAnimation opa = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromMilliseconds(animationMilisecs)));
            sb.Children.Add(opa);

            Storyboard.SetTarget(opa, element);
            Storyboard.SetTargetProperty(opa, new PropertyPath(UIElement.OpacityProperty));
        }

        public static void WriteXml(this XDocument xml, string path)
        {
            using (var writer = XmlWriter.Create(path, new XmlWriterSettings {Indent = true}))
                xml.WriteTo(writer);
        }

        public static void SetupQR(SurfaceScrollViewer QRText, String text)
        {
            QRText.Background = new SolidColorBrush(contentBgColor);
            //QRText.Margin = contentMargin;
            TextBlock tb = Util.TextBlockFactory();
            tb.TextAlignment = TextAlignment.Center;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Inlines.Add(new Run(text));
            StackPanel sp = new StackPanel();
            sp.Children.Add(tb);
            QRText.Content = sp;
        }
    }
}
