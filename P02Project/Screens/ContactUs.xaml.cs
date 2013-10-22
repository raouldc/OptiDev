using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace P02Project
{
    /// <summary>
    /// Interaction logic for ContactUs.xaml
    /// </summary>
    public partial class ContactUs : UserControl
    {
        // constant color for selected and unselected buttons
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
            
            // set the color for each button
            _fmlPlcs.Background = SELECTED_COLOR;
            _mainOff.Background = UNSELECTED_COLOR;
            _fndrsOff.Background = UNSELECTED_COLOR;
            _fmlSptBrns.Background = UNSELECTED_COLOR;

            // Initialize the lists of contents
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
            // set the color for all buttons
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

            // set the visibility of the contents according to the button clicked
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
        }



        /// <summary>
        /// this method called when the "Main Office" option button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainOffClicked(Object sender, RoutedEventArgs e)
        {
            // set the color for all buttons
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

            // set the visibility of the contents according to the button clicked
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
        }


        /// <summary>
        /// this method called when the "Findraising Office" option button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fndrsClicked(Object sender, RoutedEventArgs e)
        {
            // set the color for all buttons
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

            // set the visibility of the contents according to the button clicked
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
        }



        /// <summary>
        /// this method called when the "Family Support Branches" option button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fmlSptBrsClicked(Object sender, RoutedEventArgs e)
        {
            // set the color for all buttons
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

            // set the visibility of the contents according to the button clicked
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
        }

    }
}