using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Surface.Presentation.Controls;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace P02Project
{
    class Util
    {

        public static readonly Dictionary<string, Brush> _pageColDict = new Dictionary<string, Brush>()
        {
            { "About",              new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00aedbff"))},
            { "Family Support",     new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ec008bff"))},
            { "How Can I Help?",    new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f68e1eff"))},
            { "News",               new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a13e97ff"))},
            { "Events",             new SolidColorBrush((Color)ColorConverter.ConvertFromString("#bcd530ff"))},
            { "Contact Us",         new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffe411ff"))},
            { "Play Beads",         new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ee3123ff"))}
        };
            
    }
}
