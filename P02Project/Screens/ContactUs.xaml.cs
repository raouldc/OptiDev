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
//using Microsoft.Maps.MapControl;
//using Microsoft.Maps.MapControl.WPF;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;

namespace P02Project
{
	/// <summary>
	/// Interaction logic for ContactUs.xaml
	/// </summary>
	public partial class ContactUs : UserControl
	{
        // constant color for selected and unselected button
        private static readonly Brush SELECTED_COLOR = new SolidColorBrush(Color.FromRgb(113, 11, 126));
        private static readonly Brush UNSELECTED_COLOR = new SolidColorBrush(Color.FromRgb(228, 17, 255));
        //private Map baseMap;

        // list storing the ScatterViewItems
        private List<ScatterViewItem> _sviList;

		public ContactUs()
		{
            this.InitializeComponent();
            DataContext = new MapAddressViewModel();
            //baseMap = houseMap;
            //_sviList = new List<ScatterViewItem>();
            //_sviList.Add(_fmlPlSVI);
            //_sviList.Add(_fmlSptBrsSVI);
            //_sviList.Add(_mainOffSVI);
            //_sviList.Add(_fndRsSVI);
		}


        /// <summary>
        /// this method called when the "Family Places" option button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fmlPlClicked(Object sender, RoutedEventArgs e)
        {
            // change the color of each option buton
            //_fmlPlSVI.Background = SELECTED_COLOR;
            //_fmlSptBrsSVI.Background = UNSELECTED_COLOR;
            //_fndRsSVI.Background = UNSELECTED_COLOR;
            //_mainOffSVI.Background = UNSELECTED_COLOR;
            
            // change the map content here
            
//            baseMap.Center = new Location(-41, 173);
//            baseMap.ZoomLevel = 5.9;
//            baseMap.AnimationLevel = AnimationLevel.UserInput;
//            baseMap.Children.Clear();
//            var pushPin = new Pushpin{
//                                         AllowDrop = false,
//                                         Location = new Location(-36.857769, 174.769119),
//                                         Name = "AucklandHouse"
//                                     };
//            pushPin.TouchEnter += _displayInfo;
//            baseMap.Children.Add(pushPin);
        }

	    private void _displayInfo(object sender, RoutedEventArgs e)
	    {
            //var pin = (Pushpin) sender;
            
            //switch (pin.Name)
            //{
            //    case "AucklandHouse":
                    
            //        break;
            //} 
	    }

        private void Pushpin_TouchEnter(object sender, TouchEventArgs touchEventArgs) {
            var pin = sender as FrameworkElement;
            //MapLayer.SetPosition(ContentPopup, MapLayer.GetPosition(pin));
            //MapLayer.SetPositionOffset(ContentPopup, new Point(0, -50));

            var location = (MapAddress)pin.Tag;

            //ContentPopupTitle.Text = location.Title;
            //ContentPopupAddress.Text = location.Address;
            //ContentPopup.Visibility = Visibility.Visible;
        }

        private void Pushpin_TouchLeave(object sender, RoutedEventArgs routedEventArgs) {
            //ContentPopup.Visibility = Visibility.Collapsed;
        }
	    /// <summary>
        /// this method called when the "Main Office" option button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainOffClicked(Object sender, RoutedEventArgs e)
        {
            // change the color of each option buton
            //_mainOffSVI.Background = SELECTED_COLOR;
            //_fmlPlSVI.Background = UNSELECTED_COLOR;
            //_fmlSptBrsSVI.Background = UNSELECTED_COLOR;
            //_fndRsSVI.Background = UNSELECTED_COLOR;
            
            // change the map content here
        }


        /// <summary>
        /// this method called when the "Findraising Office" option button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fndRsClicked(Object sender, RoutedEventArgs e)
        {
            // change the color of each option buton
            //_fndRsSVI.Background = SELECTED_COLOR;
            //_mainOffSVI.Background = UNSELECTED_COLOR;
            //_fmlPlSVI.Background = UNSELECTED_COLOR;
            //_fmlSptBrsSVI.Background = UNSELECTED_COLOR;

            // change the map content here
        }

        /// <summary>
        /// this method called when the "Family Support Branches" option button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fmlSptBrsClicked(Object sender, RoutedEventArgs e)
        {
            // change the color of each option buton
            //_fmlSptBrsSVI.Background = SELECTED_COLOR;
            //_mainOffSVI.Background = UNSELECTED_COLOR;
            //_fmlPlSVI.Background = UNSELECTED_COLOR;
            //_fndRsSVI.Background = UNSELECTED_COLOR;

            // change the map content here
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {}
	}
}