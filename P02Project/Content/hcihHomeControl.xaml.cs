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
using P02Project.Screens;

namespace P02Project
{
    /// <summary>
    /// Interaction logic for hcihHomeControl.xaml
    /// </summary>
    public partial class hcihHomeControl : UserControl
    {
        private TopLevelPage topLevelPage;

        public hcihHomeControl(TopLevelPage tlpage)
        {
            this.InitializeComponent();

            topLevelPage = tlpage;
            donate.setImage("donate.png");
            donate.setCaption("Donate");
            donate.setColour(Util._pageColDict["How Can I Help?"]);
        }

        private void donate_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
            topLevelPage.setContent(new hcihDonateControl());
            topLevelPage.setSubtitle("Donate");

        }

        //public TopLevelPage FindTopLevel(Object obj)
        //{

        //    if (obj is FrameworkElement)
        //    {
        //        //If null return null
        //        if (((FrameworkElement)obj).Parent != null)
        //        {
        //            //if parent is top level page return it
        //            if (((FrameworkElement)obj).Parent is TopLevelPage)
        //            {
        //                return (TopLevelPage)((FrameworkElement)obj).Parent;
        //            }
        //            else
        //            {
        //                //Continue searching recursively for toplevel page
        //                FindTopLevel(((FrameworkElement)obj).Parent);
                        
                        
        //            }
        //        }
        //        else 
        //        { 
        //            return null;
        //        }
                

        //    }
        //    //shouldn't get here
        //    return null;

        //}
    }
}