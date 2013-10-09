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

        public static readonly Dictionary<string, Color> _pageColDict = new Dictionary<string, Color>()
        {
            { "About",              (Color)ColorConverter.ConvertFromString("#ff00aedb")},
            { "Family Support",     (Color)ColorConverter.ConvertFromString("#ffec008b")},
            { "How Can I Help?",    (Color)ColorConverter.ConvertFromString("#fff68e1e")},
            { "hcihSelected",       (Color)ColorConverter.ConvertFromString("#FFD47C1E")},
            { "hcihUnSelected",     (Color)ColorConverter.ConvertFromString("#FFD4A339")},
            { "News",               (Color)ColorConverter.ConvertFromString("#ffa13e97")},
            { "Events",             (Color)ColorConverter.ConvertFromString("#ffbcd530")},
            { "Contact Us",         (Color)ColorConverter.ConvertFromString("#ffe411ff")},
            { "Play Beads",         (Color)ColorConverter.ConvertFromString("#ffee3123")}
        };
            
    }
}
