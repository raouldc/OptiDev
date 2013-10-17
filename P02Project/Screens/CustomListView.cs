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
        private TouchPoint TouchStart;
        private Point PointStart;
        private bool AlreadySwiped;
        private ScrollViewer _scrollViewer;
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
            panel.Children.Add(pol);
        }
    }
}
