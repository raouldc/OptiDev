using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using Microsoft.Surface.Presentation.Controls;

namespace P02Project.Screens
{
    /*
     *This class is used to create the cover flow in News and Events
     *UI redesign required
     */
    class CustomListView : SurfaceScrollViewer
    {
        //stackpanel containing ui elements
        private StackPanel panel;

        /// <summary>
        /// Initailize a new instance of a custom list view
        /// </summary>
        public CustomListView()
            : base()
        {
            //create a new stackpanel and add to the content of the page
            panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            this.Content = panel;
            this.ScrollChanged += new ScrollChangedEventHandler(CustomListView_ScrollChanged);
        }

        void CustomListView_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            (Window.GetWindow(this) as TopWindow).ResetTimer();
        }

        /// <summary>
        /// add new polaroids to the stackpanel
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
