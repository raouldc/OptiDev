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

            
            { "Extra",         (Color)ColorConverter.ConvertFromString("#ff146290")},
            { "extraSelected",         (Color)ColorConverter.ConvertFromString("#FF073f60")},
            { "extraUnSelected",       (Color)ColorConverter.ConvertFromString("#FF4899c8")}
        };
            
    }
}
