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
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;
using System.Windows.Media.Animation;

namespace P02Project
{
	/// <summary>
	/// Interaction logic for ContactUs.xaml
	/// </summary>
	public partial class ContactUs : UserControl
	{
        private List<ScatterViewItem> _sviList;
        private static readonly Brush SELECTED_COLOR = new SolidColorBrush(Color.FromRgb(113, 11, 126));
        private static readonly Brush UNSELECTED_COLOR = new SolidColorBrush(Color.FromRgb(228, 17 , 255));

		public ContactUs()
		{
			this.InitializeComponent();
		}


        
        protected override void OnInitialized(EventArgs e)
        {
            
            _sviList = new List<ScatterViewItem>();
            _sviList.Add(_fmlPlSVI);
            _sviList.Add(_fmlSptBrsSVI);
            _sviList.Add(_mainOffSVI);
            _sviList.Add(_fndRsSVI);
            
        }
        


        private void fmlPlClicked(Object sender, RoutedEventArgs e)
        {
            
            
        }

        private void mainOffClicked(Object sender, RoutedEventArgs e)
        {
        }

        private void fndRsClicked(Object sender, RoutedEventArgs e)
        {
        }

        private void fmlSptBrsClicked(Object sender, RoutedEventArgs e)
        {
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }


	}
}