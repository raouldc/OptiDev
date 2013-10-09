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
using System.Windows.Media.Effects;

namespace P02Project
{
    /// <summary>
    /// Interaction logic for ContactUs.xaml
    /// </summary>
    public partial class ContactUs : UserControl
    {
        // constant color for selected and unselected button
        private static readonly Brush SELECTED_COLOR = new SolidColorBrush(Util._pageColDict["cuSelected"]);
        private static readonly Brush UNSELECTED_COLOR = new SolidColorBrush(Util._pageColDict["cuUnSelected"]);
        //private Map baseMap;

        // lists storing the contents of each option
        private List<RichTextBox> _fmlPlcList;
        private List<RichTextBox> _mnOffList;
        private List<RichTextBox> _fndrsOffList;
        private List<RichTextBox> _fmlSptList;

        public ContactUs()
        {
            this.InitializeComponent();

            _fmlPlcs.Background = SELECTED_COLOR;
            _mainOff.Background = UNSELECTED_COLOR;
            _fndrsOff.Background = UNSELECTED_COLOR;
            _fmlSptBrns.Background = UNSELECTED_COLOR;

            //DataContext = new MapAddressViewModel();
            //baseMap = houseMap;
            _fmlPlcList = new List<RichTextBox>();
            _fmlPlcList.Add(_fmlPlc0);
            _fmlPlcList.Add(_fmlPlc1);
            _fmlPlcList.Add(_fmlPlc2);
            _fmlPlcList.Add(_fmlPlc3);
            _fmlPlcList.Add(_fmlPlc4);
            _fmlPlcList.Add(_fmlPlc5);

            _mnOffList = new List<RichTextBox>();
            _mnOffList.Add(_mnOff0);
            _mnOffList.Add(_mnOff1);
            _mnOffList.Add(_mnOff2);

            _fndrsOffList = new List<RichTextBox>();
            _fndrsOffList.Add(_fndrsOff0);
            _fndrsOffList.Add(_fndrsOff1);
            _fndrsOffList.Add(_fndrsOff2);
            _fndrsOffList.Add(_fndrsOff3);
            _fndrsOffList.Add(_fndrsOff4);
            _fndrsOffList.Add(_fndrsOff5);

            _fmlSptList = new List<RichTextBox>();
            _fmlSptList.Add(_fmlSpt0);
            _fmlSptList.Add(_fmlSpt1);
            _fmlSptList.Add(_fmlSpt2);
            _fmlSptList.Add(_fmlSpt3);
            _fmlSptList.Add(_fmlSpt4);
            _fmlSptList.Add(_fmlSpt5);


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

            foreach (RichTextBox rtb in _fmlPlcList)
            {
                rtb.Opacity = 100;
            }

            foreach (RichTextBox rtb in _mnOffList)
            {
                rtb.Opacity = 0;
            }

            foreach (RichTextBox rtb in _fndrsOffList)
            {
                rtb.Opacity = 0;
            }

            foreach (RichTextBox rtb in _fmlSptList)
            {
                rtb.Opacity = 0;
            }

            

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

        private void Pushpin_TouchEnter(object sender, TouchEventArgs touchEventArgs)
        {
            var pin = sender as FrameworkElement;
            //MapLayer.SetPosition(ContentPopup, MapLayer.GetPosition(pin));
            //MapLayer.SetPositionOffset(ContentPopup, new Point(0, -50));

            var location = (MapAddress)pin.Tag;

            //ContentPopupTitle.Text = location.Title;
            //ContentPopupAddress.Text = location.Address;
            //ContentPopup.Visibility = Visibility.Visible;
        }

        private void Pushpin_TouchLeave(object sender, RoutedEventArgs routedEventArgs)
        {
            //ContentPopup.Visibility = Visibility.Collapsed;
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


            foreach (RichTextBox rtb in _fmlPlcList)
            {
                rtb.Opacity = 0;
            }

            foreach (RichTextBox rtb in _mnOffList)
            {
                rtb.Opacity = 100;
            }

            foreach (RichTextBox rtb in _fndrsOffList)
            {
                rtb.Opacity = 0;
            }

            foreach (RichTextBox rtb in _fmlSptList)
            {
                rtb.Opacity = 0;
            }

            // change the map content here
        }


        /// <summary>
        /// this method called when the "Findraising Office" option button has been clicked
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

            foreach (RichTextBox rtb in _fmlPlcList)
            {
                rtb.Opacity = 0;
            }

            foreach (RichTextBox rtb in _mnOffList)
            {
                rtb.Opacity = 0;
            }

            foreach (RichTextBox rtb in _fndrsOffList)
            {
                rtb.Opacity = 100;
            }

            foreach (RichTextBox rtb in _fmlSptList)
            {
                rtb.Opacity = 0;
            }

            // change the map content here
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

            foreach (RichTextBox rtb in _fmlPlcList)
            {
                rtb.Opacity = 0;
            }

            foreach (RichTextBox rtb in _mnOffList)
            {
                rtb.Opacity = 0;
            }

            foreach (RichTextBox rtb in _fndrsOffList)
            {
                rtb.Opacity = 0;
            }

            foreach (RichTextBox rtb in _fmlSptList)
            {
                rtb.Opacity = 100;
            }

            // change the map content here
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) { }

        private void text_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

        }
    }
}