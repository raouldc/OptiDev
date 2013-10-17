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

namespace P02Project
{
	/// <summary>
	/// Interaction logic for TwitterBlock.xaml
	/// </summary>
	public partial class TwitterBlock : UserControl
	{
		public TwitterBlock()
		{
			this.InitializeComponent();
            msg.Text = "CCF are at the Massey High @Hurricane_Kids gig today. They are rocking out & supporting kids with cancer! pic.twitter.com/1e2HvbKTIw";
		}
	}
}