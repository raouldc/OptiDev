﻿using System;
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
	/// Interaction logic for TitleBarControl.xaml
	/// </summary>
	public partial class TitleBarControl : UserControl
	{
		public TitleBarControl()
		{
			this.InitializeComponent();
		}

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SurfaceWindow1 parentWindow = (SurfaceWindow1)Window.GetWindow(this);
            parentWindow.popScreen();
        }
	}
}