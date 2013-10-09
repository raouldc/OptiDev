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
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;
using System.Windows.Media.Effects;

namespace P02Project
{
    /// <summary>
    /// Interaction logic for ContactUs.xaml
    /// </summary>
    public partial class ContactUs : UserControl
    {
        // constant color for selected and unselected button
        private static readonly Brush SELECTED_COLOR = new SolidColorBrush(Util._pageColDict["contactUsSelected"]);
        private static readonly Brush UNSELECTED_COLOR = new SolidColorBrush(Util._pageColDict["contactUUnSelected"]);

        // list storing the ScatterViewItems
        //        private List<ScatterViewItem> _sviList;

        public ContactUs()
        {
            this.InitializeComponent();
            DataContext = new MapAddressViewModel(AddressType.FamilyPlace);
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
            _fmlPlcs.Background = SELECTED_COLOR;
            _mainOff.Background = UNSELECTED_COLOR;
            _fndrsOff.Background = UNSELECTED_COLOR;
            _fmlSptBrns.Background = UNSELECTED_COLOR;

            //remove drop shadow from other buttons
            _mainOff.Effect = null;
            _fndrsOff.Effect = null;
            _fmlSptBrns.Effect = null;


            //add drop shadow
            _fmlPlcs.Effect = new DropShadowEffect();

            // change the map content here

            houseMap.Center = new Location(-41, 173);
            houseMap.ZoomLevel = 5.9;
            DataContext = new MapAddressViewModel(AddressType.FamilySupport);

            houseMap.Visibility = Visibility.Visible;
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

        private void Pushpin_TouchEnter(object sender, TouchEventArgs touchEventArgs)
        {
            var pin = sender as FrameworkElement;
//            MapLayer.SetPosition(ContentPopup, MapLayer.GetPosition(pin));
//            MapLayer.SetPositionOffset(ContentPopup, new Point(0, -50));

            var location = (MapAddress)pin.Tag;

//            ContentPopupTitle.Text = location.Title;
//            ContentPopupAddress.Text = location.Address;
//            ContentPopup.Visibility = Visibility.Visible;
        }

        private void Pushpin_TouchLeave(object sender, RoutedEventArgs routedEventArgs) {
//            ContentPopup.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// this method called when the "Main Office" option button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainOffClicked(Object sender, RoutedEventArgs e)
        {
            _fmlPlcs.Background = UNSELECTED_COLOR;
            _mainOff.Background = SELECTED_COLOR;
            _fndrsOff.Background = UNSELECTED_COLOR;
            _fmlSptBrns.Background = UNSELECTED_COLOR;

            //remove drop shadow from other buttons
            _fmlPlcs.Effect = null;
            _fndrsOff.Effect = null;
            _fmlSptBrns.Effect = null;


            //add drop shadow
            _mainOff.Effect = new DropShadowEffect();

            // change the map content here
	        houseMap.Visibility = Visibility.Collapsed;
        }


        /// <summary>
        /// this method called when the "Fundraising Office" option button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fndrsClicked(Object sender, RoutedEventArgs e)
        {
            _fmlPlcs.Background = UNSELECTED_COLOR;
            _mainOff.Background = UNSELECTED_COLOR;
            _fndrsOff.Background = SELECTED_COLOR;
            _fmlSptBrns.Background = UNSELECTED_COLOR;

            //remove drop shadow from other buttons
            _fmlPlcs.Effect = null;
            _mainOff.Effect = null;
            _fmlSptBrns.Effect = null;


            //add drop shadow
            _fndrsOff.Effect = new DropShadowEffect();

            
            // change the map content here
            houseMap.Visibility = Visibility.Collapsed;

        }

        /// <summary>
        /// this method called when the "Family Support Branches" option button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fmlSptBrsClicked(Object sender, RoutedEventArgs e)
        {
            _fmlPlcs.Background = UNSELECTED_COLOR;
            _mainOff.Background = UNSELECTED_COLOR;
            _fndrsOff.Background = UNSELECTED_COLOR;
            _fmlSptBrns.Background = SELECTED_COLOR;

            //remove drop shadow from other buttons
            _fmlPlcs.Effect = null;
            _mainOff.Effect = null;
            _fndrsOff.Effect = null;


            //add drop shadow
            _fmlSptBrns.Effect = new DropShadowEffect();


            // change the map content here
            houseMap.Center = new Location(-41, 173);
            houseMap.ZoomLevel = 5.9;
            DataContext = new MapAddressViewModel(AddressType.FamilySupport);
            houseMap.Visibility = Visibility.Visible;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) { }
    }
}