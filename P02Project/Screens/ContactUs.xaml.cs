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
        private Dictionary<String, SVIWithImgBtn> _dictOptionBtns;
        //private static readonly Brush = new SolidColorBrush(Color  )

		public ContactUs()
		{
			this.InitializeComponent();
		}

        protected override void OnInitialized(EventArgs e)
        {
            _dictOptionBtns = new Dictionary<String, SVIWithImgBtn>();
           _dictOptionBtns.Add(_fmlPlSVIBtn.ToString(), new SVIWithImgBtn(_fmlPlSVI, null, _fmlPlSVIBtn));
           _dictOptionBtns.Add(_mainOffSVI.ToString(), new SVIWithImgBtn(_mainOffSVI, null, _mainOffSVIBtn));
           _dictOptionBtns.Add(_fndRsSVI.ToString(), new SVIWithImgBtn(_fndRsSVI, null, _fndRsSVIBtn));
           _dictOptionBtns.Add(_fmlSptBrsSVI.ToString(), new SVIWithImgBtn(_fmlSptBrsSVI, null, _fmlSptBrsSVIBtn));

        }



        private void fmlPlClicked(Object sender, RoutedEventArgs e)
        {
            ScatterViewItem svi = _dictOptionBtns[sender.ToString()]._svi;
            
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


	}
}