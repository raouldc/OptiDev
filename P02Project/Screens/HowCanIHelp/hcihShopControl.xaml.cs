﻿#region

using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using P02Project.Utils;

#endregion

namespace P02Project
{
    /// <summary>
    ///     Interaction logic for hcihBeads.xaml
    /// </summary>
    public partial class hcihShopControl : UserControl, Animatiable
    {
        private readonly List<PoloroidControl> pols;
        private readonly Storyboard sbIn;

        /// <summary>
        ///     Constructor
        /// </summary>
        public hcihShopControl()
        {
            InitializeComponent();
            Color colour = Util._pageColDict["How Can I Help?"];

            sbIn = new Storyboard();

            Util.FadeIn(sbIn, qr);
            Util.FadeIn(sbIn, QRText);

            eb.setImage("images\\HowCanIhelp\\sb.png");
            eb.setCaption("$65 Entertainmaint Booklet");
            eb.setColour(colour);
            eb.removeTouch();
            eb.setShadow(10, 0.365, Colors.Black);

            firef.setImage("images\\HowCanIhelp\\ff.png");
            firef.setCaption("$10 Firefighter Calender");
            firef.setColour(colour);
            firef.removeTouch();
            firef.setShadow(10, 0.365, Colors.Black);

            kagi.setImage("images\\HowCanIhelp\\kagi.png");
            kagi.setCaption("$65 Kagi Friendship Bracelet");
            kagi.setColour(colour);
            kagi.removeTouch();
            kagi.setShadow(10, 0.365, Colors.Black);

            bb.setImage("images\\HowCanIhelp\\bb.png");
            bb.setCaption("$5 Bead Bracelet");
            bb.setColour(colour);
            bb.removeTouch();
            bb.setShadow(10, 0.365, Colors.Black);

            pols = new List<PoloroidControl>();
            pols.Add(eb);
            pols.Add(firef);
            pols.Add(kagi);
            pols.Add(bb);

            Util.SetupQR(QRText, "Find out more about our online store at http://tinyurl.com/k74ek3x");
        }

        /// <summary>
        ///     Does the animation for all the poloroids
        /// </summary>
        void Animatiable.AnimateIn()
        {
            foreach (Animatiable a in pols)
            {
                a.AnimateIn();
            }
            sbIn.Begin();
        }

        /// <summary>
        ///     Does nothing
        /// </summary>
        void Animatiable.AnimateOut()
        {
        }
    }
}