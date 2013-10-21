using System;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Controls;

namespace P02Project
{
    class Util
    {
        // the dictionary of the color of each section
        public static readonly Dictionary<string, Color> _pageColDict = new Dictionary<string, Color>()
        {
            { "About",              (Color)ColorConverter.ConvertFromString("#ffdc1423")},
            { "abtSelected",        (Color)ColorConverter.ConvertFromString("#FF920711")},
            { "abtUnSelected",      (Color)ColorConverter.ConvertFromString("#FFee4c58")},

            { "Family Support",     (Color)ColorConverter.ConvertFromString("#ff381f9c")},
            { "fsSelected",         (Color)ColorConverter.ConvertFromString("#FF1d0b68")},
            { "fsUnSelected",       (Color)ColorConverter.ConvertFromString("#FF6b53ce")},

            { "How Can I Help?",    (Color)ColorConverter.ConvertFromString("#ffe2bb15")},
            { "hcihSelected",       (Color)ColorConverter.ConvertFromString("#FF967b07")},
            { "hcihUnSelected",     (Color)ColorConverter.ConvertFromString("#FFf1d24d")},

            { "News",               (Color)ColorConverter.ConvertFromString("#ffbe1160")},
            { "nwsSelected",        (Color)ColorConverter.ConvertFromString("#FF7e063d")},
            { "nwsUnSelected",      (Color)ColorConverter.ConvertFromString("#FFdf488c")},

            { "Events",             (Color)ColorConverter.ConvertFromString("#ff28bb11")},
            { "evtSelected",        (Color)ColorConverter.ConvertFromString("#FF167c06")},
            { "evtUnSelected",      (Color)ColorConverter.ConvertFromString("#FF5cdd47")},

            { "Contact Us",         (Color)ColorConverter.ConvertFromString("#ffe28615")},
            { "cuSelected",         (Color)ColorConverter.ConvertFromString("#FF965607")},
            { "cuUnSelected",       (Color)ColorConverter.ConvertFromString("#FFf1a74d")},

            { "Play Beads",         (Color)ColorConverter.ConvertFromString("#ff870f94")},
            { "pbSelected",         (Color)ColorConverter.ConvertFromString("#FF590562")},
            { "pbUnSelected",       (Color)ColorConverter.ConvertFromString("#FFbd43ca")},

            
            { "Extra",              (Color)ColorConverter.ConvertFromString("#ff146290")},
            { "extraSelected",      (Color)ColorConverter.ConvertFromString("#FF073f60")},
            { "extraUnSelected",    (Color)ColorConverter.ConvertFromString("#FF4899c8")}
        };

        public static readonly FontFamily contentTextFont = new FontFamily("Century Gothic");
        public static readonly Color contentTextColor = (Color)ColorConverter.ConvertFromString("#FF000000");
        public static readonly Color contentBgColor = (Color)ColorConverter.ConvertFromString("#7Fffffff");
        public static readonly double contentTextSize = 24;
        public static readonly Thickness contentMargin = new Thickness(30);
        public static readonly FontFamily buttonTextFont = new FontFamily("Andy");
        public static readonly Color buttonTextColor = (Color)ColorConverter.ConvertFromString("#FF000000");
        public static readonly double buttonTextSize = 48;

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

        /// <summary>
        /// return the list of the links of the buttons
        /// </summary>
        /// <param name="exclude"></param>
        /// <returns></returns>
        public static String[] getLinks(String exclude)
        {
            List<String> links = new List<string>(new String[] { "About", "Family Support", "How Can I Help?", "News", "Events", "Play Beads", "Contact Us" });

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
                Storyboard.SetTargetName(stackIn, b.Name);
                Storyboard.SetTargetProperty(stackIn, new PropertyPath(StackPanel.MarginProperty));
            }
        }

        public static void FadeIn(Storyboard sb, UIElement element)
        {
            DoubleAnimation opa = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromMilliseconds(animationMilisecs)));
            sb.Children.Add(opa);

            Storyboard.SetTarget(opa, element);
            Storyboard.SetTargetProperty(opa, new PropertyPath(UIElement.OpacityProperty));
        }
            
    }
}
