using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

using Microsoft.Surface.Presentation.Controls;

namespace P02Project.Screens
{
    class CustomListView : SurfaceScrollViewer
    {
        private StackPanel panel;
        public CustomListView()
            : base()
        {

            panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            this.Content = panel;

        }

        public void addContent(PoloroidWithText pol)
        {
            pol.Margin = new Thickness(30);
            panel.Children.Add(pol);
        }
    }
}
