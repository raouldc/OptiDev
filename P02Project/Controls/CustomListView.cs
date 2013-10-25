#region

using System.Windows;
using System.Windows.Controls;
using Microsoft.Surface.Presentation.Controls;

#endregion

namespace P02Project.Screens
{
    /*
     *This class is used to create the cover flow in News and Events
     *UI redesign required
     */

    internal class CustomListView : SurfaceScrollViewer
    {
        //stackpanel containing ui elements
        private readonly StackPanel panel;

        /// <summary>
        ///     Initailize a new instance of a custom list view
        /// </summary>
        public CustomListView()
        {
            //create a new stackpanel and add to the content of the page
            panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            Content = panel;
            ScrollChanged += CustomListView_ScrollChanged;
        }

        private void CustomListView_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            (Window.GetWindow(this) as TopWindow).ResetTimer();
        }

        /// <summary>
        ///     add new polaroids to the stackpanel
        /// </summary>
        /// <param name="pol"></param>
        public void addContent(PoloroidWithText pol)
        {
            //add the Polaroid with a margin
            pol.Margin = new Thickness(30);
            panel.Children.Add(pol);
        }
    }
}