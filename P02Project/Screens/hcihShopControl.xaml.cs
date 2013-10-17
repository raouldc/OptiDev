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
using System.Windows.Media.Animation;
using P02Project.Utils;

namespace P02Project
{
	/// <summary>
	/// Interaction logic for hcihBeads.xaml
	/// </summary>
    public partial class hcihShopControl : UserControl, Animatiable
	{
        Storyboard sbIn;
        private List<PoloroidControl> pols;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public hcihShopControl()
		{
			this.InitializeComponent();
            Color colour = Util._pageColDict["How Can I Help?"];

            sbIn = new Storyboard();

            DoubleAnimation da = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromMilliseconds(200)));
            DoubleAnimation da2 = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromMilliseconds(200)));

            sbIn.Children.Add(da);
            sbIn.Children.Add(da2);

            Storyboard.SetTarget(da, QRText);
            Storyboard.SetTarget(da2, qr);
            Storyboard.SetTargetProperty(da, new PropertyPath(FrameworkElement.OpacityProperty));
            Storyboard.SetTargetProperty(da2, new PropertyPath(Image.OpacityProperty));

            eb.setImage("images\\HowCanIhelp\\sb.png");
            eb.setCaption("$65 Entertainmaint Booklet");
            eb.setColour(colour);

            firef.setImage("images\\HowCanIhelp\\ff.png");
            firef.setCaption("$10 Firefighter Calender");
            firef.setColour(colour);

            kagi.setImage("images\\HowCanIhelp\\kagi.png");
            kagi.setCaption("$65 Kagi Friendship Bracelet");
            kagi.setColour(colour);

            bb.setImage("images\\HowCanIhelp\\bb.png");
            bb.setCaption("$5 Bead Bracelet");
            bb.setColour(colour);

            pols = new List<PoloroidControl>();
            pols.Add(eb);
            pols.Add(firef);
            pols.Add(kagi);
            pols.Add(bb);
		}


        void Animatiable.AnimateIn()
        {
            foreach (Animatiable a in pols)
            {
                a.AnimateIn();
            }
            sbIn.Begin();
        }

        void Animatiable.AnimateOut()
        {
        }
    }
}