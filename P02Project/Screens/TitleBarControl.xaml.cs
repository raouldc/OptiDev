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
        private TopLevelPage topLevelPage;

		public TitleBarControl()
		{
			this.InitializeComponent();
		}

        public void setTopPage(TopLevelPage top){
            topLevelPage = top;
        }

        public void setBackground(Color col)
        {
            lRect.Fill = new SolidColorBrush(col);
            rGradStop.Color = col;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            topLevelPage.BackButton_Click(sender, e);
        }
	}
}