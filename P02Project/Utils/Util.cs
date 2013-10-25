#region

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Surface.Presentation.Controls;

#endregion

namespace P02Project
{
    /// <summary>
    ///     A Utility Class that contains constants that are used throughout the application
    /// </summary>
    public static class Util
    {
        // A dictionary of the colors used in each section
        public static readonly Dictionary<string, Color> _pageColDict = new Dictionary<string, Color>
        {
            //red
            {"About", (Color) ColorConverter.ConvertFromString("#FFff353a")},
            {"abtSelected", (Color) ColorConverter.ConvertFromString("#FFff353a")},
            {"abtUnSelected", (Color) ColorConverter.ConvertFromString("#FFff9093")},

            //blue
            {"Family Support", (Color) ColorConverter.ConvertFromString("#FF4679f0")},
            {"fsSelected", (Color) ColorConverter.ConvertFromString("#FF4679f0")},
            {"fsUnSelected", (Color) ColorConverter.ConvertFromString("#FF9ebbff")}, 

            //yellow
            {"How Can I Help?", (Color) ColorConverter.ConvertFromString("#FFffdf35")},
            {"hcihSelected", (Color) ColorConverter.ConvertFromString("#FFffdf35")},
            {"hcihUnSelected", (Color) ColorConverter.ConvertFromString("#FFffed90")},

            //pink
            {"News", (Color) ColorConverter.ConvertFromString("#fff83487")},
            {"nwsSelected", (Color) ColorConverter.ConvertFromString("#FFf83487")},
            {"nwsUnSelected", (Color) ColorConverter.ConvertFromString("#FFfc8ebc")},

            //green
            {"Events", (Color) ColorConverter.ConvertFromString("#ff33f455")},
            {"evtSelected", (Color) ColorConverter.ConvertFromString("#FF33f455")},
            {"evtUnSelected", (Color) ColorConverter.ConvertFromString("#FF8dfaa0")},

            //orange
            {"Contact Us", (Color) ColorConverter.ConvertFromString("#FFff8d35")},
            {"cuSelected", (Color) ColorConverter.ConvertFromString("#FFff8d35")},
            {"cuUnSelected", (Color) ColorConverter.ConvertFromString("#FFffc090")},

            //purple
            {"Beads of Courage", (Color) ColorConverter.ConvertFromString("#ff9841f0")},
            {"pbSelected", (Color) ColorConverter.ConvertFromString("#ff9841f0")},
            {"pbUnSelected", (Color) ColorConverter.ConvertFromString("#ffc594f8")},

            //twitter
            {"Twitter", (Color) ColorConverter.ConvertFromString("#ff3ea5ee")},
            {"twtSelected", (Color) ColorConverter.ConvertFromString("#FF3ea5ee")},
            {"twtUnSelected", (Color) ColorConverter.ConvertFromString("#FF92cdf6")},
            {"Extra", (Color) ColorConverter.ConvertFromString("#ff146290")},
            {"extraSelected", (Color) ColorConverter.ConvertFromString("#FF073f60")},
            {"extraUnSelected", (Color) ColorConverter.ConvertFromString("#FF4899c8")}
        };

        #region TextContent

        //Content styles
        public static readonly FontFamily contentTextFont = new FontFamily("Segoe UI");
        public static readonly Color contentTextColor = (Color) ColorConverter.ConvertFromString("#FF000000");
        public static readonly Color contentBgColor = (Color) ColorConverter.ConvertFromString("#7Fffffff");
        public static readonly Thickness contentMargin = new Thickness(30);
        public static readonly double contentTextSize = 24;
        public static readonly double headingTextSize = 30;

        //left Button styles
        public static readonly FontFamily buttonTextFont = new FontFamily("Segoe UI");
        public static readonly Color buttonTextColor = (Color) ColorConverter.ConvertFromString("#FF000000");
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

        #endregion

        #region Map

        //The authentication key used to access the map api
        public static readonly ApplicationIdCredentialsProvider MapProvider =
            new ApplicationIdCredentialsProvider("AtabbySpgE9zdS1c5C4Pp1FHWjbxM_nHqIBmfZ--pFwtM0Vddbw7-bfUMBW-FBao");

        #endregion

        #region Right Button Links

        /// <summary>
        ///     return the list of the links of the buttons
        /// </summary>
        /// <param name="exclude"></param>
        /// <returns></returns>
        public static String[] getLinks(String exclude)
        {
            var links =
                new List<string>(new[]
                {
                    "About", "Family Support", "How Can I Help?", "News", "Events", "Beads of Courage", "Contact Us",
                    "Twitter"
                });

            links.Remove(exclude);
            return links.ToArray();
        }

        #endregion

        #region Animation

        /// <summary>
        ///     The duration, in ms, for the animations
        /// </summary>
        public static readonly int animationMilisecs = 200;

        /// <summary>
        ///     The duration, in ms for animations that need to happed one after the other.
        ///     Add in this number to the length of the previos animation
        /// </summary>
        public static readonly int animationDelay = 50;

        /// <summary>
        ///     Animates a stack of buttons with a slide in from the right. Each button comes in, one after another
        /// </summary>
        /// <param name="sbIn">A Storyboard Object to save the timelines on</param>
        /// <param name="buttons">A collection of the buttons in the order that they need otbe animated in</param>
        /// <param name="from">A from location (usually off screen)</param>
        /// <param name="to">A destination location</param>
        public static void StackAnimation(Storyboard sbIn, UIElementCollection buttons, Thickness from, Thickness to)
        {
            int count = 0;

            foreach (Button b in buttons)
            {
                ThicknessAnimation stackIn;
                stackIn = new ThicknessAnimation();
                stackIn.From = from;
                stackIn.To = to;
                stackIn.Duration = new Duration(TimeSpan.FromMilliseconds(animationMilisecs + animationDelay*(count++)));

                sbIn.Children.Add(stackIn);
                //add animations to the storyboard
                Storyboard.SetTarget(stackIn, b);
                Storyboard.SetTargetProperty(stackIn, new PropertyPath(FrameworkElement.MarginProperty));
            }
        }

        /// <summary>
        ///     This does the StackAnimation with the default locations on the screen
        /// </summary>
        /// <param name="sbIn">A Storyboard object that the timelines need to be saved on</param>
        /// <param name="buttons">A collection of buttons that need to be animated</param>
        public static void StackAnimationDefault(Storyboard sbIn, UIElementCollection buttons)
        {
            StackAnimation(sbIn, buttons, new Thickness(-1000, 20, 20, 20), new Thickness(20, 20, 20, 20));
        }

        /// <summary>
        ///     Fades in an element from nothing to full opacity
        /// </summary>
        /// <param name="sb">Storyboard object to save the timeline on</param>
        /// <param name="element">An element to animate</param>
        public static void FadeIn(Storyboard sb, UIElement element)
        {
            DoubleAnimation opa = new DoubleAnimation(0.0, 1.0,
                new Duration(TimeSpan.FromMilliseconds(animationMilisecs)));
            sb.Children.Add(opa);

            Storyboard.SetTarget(opa, element);
            Storyboard.SetTargetProperty(opa, new PropertyPath(UIElement.OpacityProperty));
        }

        #endregion

        #region XML

        public static void WriteXml(this XDocument xml, string path)
        {
            using (var writer = XmlWriter.Create(path, new XmlWriterSettings {Indent = true}))
                xml.WriteTo(writer);
        }

        #endregion

        #region QR codes

        public static void SetupQR(SurfaceScrollViewer QRText, String text)
        {
            QRText.Background = new SolidColorBrush(contentBgColor);
            //QRText.Margin = contentMargin;
            TextBlock tb = TextBlockFactory();
            tb.TextAlignment = TextAlignment.Center;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Inlines.Add(new Run(text));
            StackPanel sp = new StackPanel();
            sp.Children.Add(tb);
            QRText.Content = sp;
        }

        #endregion
    }
}