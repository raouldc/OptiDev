using System;
using System.Collections.Generic;
using System.Linq;
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

namespace P02Project.Screens
{
    /// <summary>
    /// Interaction logic for TopLevelPage.xaml
    /// </summary>
    public partial class TopLevelPage : Screen
    {
        public TopLevelPage(SurfaceWindow1 parentWindow, String title) : base(parentWindow)
		{
			InitializeComponent();
            Title.Content = title;
		}

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ParentWindow.popScreen();
        }
    }
}
