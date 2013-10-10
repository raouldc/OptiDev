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
	/// Interaction logic for TitleBarControl.xaml
	/// </summary>
	public partial class TitleBarControl : UserControl
	{

        // topLevelPage is the main screen
        private TopLevelPage topLevelPage;



        /// <summary>
        /// constructor
        /// </summary>
		public TitleBarControl()
		{
			this.InitializeComponent();
		}



        /// <summary>
        /// setter of the topLevelPage
        /// </summary>
        /// <param name="top"></param>
        public void setTopPage(TopLevelPage top){
            topLevelPage = top;
        }



        /// <summary>
        /// set the background of the titlebar
        /// </summary>
        /// <param name="col"></param>
        public void setBackground(Color col)
        {
            lRect.Fill = new SolidColorBrush(col);
            rGradStop.Color = col;
        }



        /// <summary>
        /// this method called when the back button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            topLevelPage.BackButton_Click(sender, e);
        }
	}
}