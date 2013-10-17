using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace P02Project.Screens
{
    class CustomListView:ListView
    {
        private TouchPoint TouchStart;
        private Point PointStart;
        private bool AlreadySwiped;
        private ScrollViewer _scrollViewer;
        public CustomListView():base()
        {
            this.TouchDown += new EventHandler<TouchEventArgs>(CustomListView_TouchDown);
            this.TouchMove += new EventHandler<TouchEventArgs>(CustomListView_TouchMove);
            this.TouchUp += new EventHandler<TouchEventArgs>(CustomListView_TouchUp);
            this.PreviewMouseDown += new MouseButtonEventHandler(CustomListView_TouchDown);
            this.MouseMove += new MouseEventHandler(CustomListView_TouchMove);
            this.PreviewMouseUp += new MouseButtonEventHandler(CustomListView_TouchUp);
            AlreadySwiped = false;
            
        }

        public ScrollViewer ScrollViewer
        {
            get
            {
                Border border = (Border)VisualTreeHelper.GetChild(this, 0);

                return (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
            }
        }

        void CustomListView_TouchDown(object sender, MouseButtonEventArgs e)
        {
            _scrollViewer = RecursiveVisualChildFinder<ScrollViewer>(this) as ScrollViewer;
            PointStart = e.GetPosition(this);
        }

        void CustomListView_TouchUp(object sender, MouseButtonEventArgs e)
        {
            AlreadySwiped = false;
        }
        void CustomListView_TouchMove(object sender, MouseEventArgs e)
        {
           // _scrollViewer = RecursiveVisualChildFinder<ScrollViewer>(this) as ScrollViewer;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (!AlreadySwiped)
                {

                    var Touch = e.GetPosition(this);

                    //right now a swipe is 200 pixels 



                    //Swipe Left

                    if (PointStart != null && Touch.X > (PointStart.X + 50))
                    {

                        double horiz = _scrollViewer.HorizontalOffset;
                        _scrollViewer.ScrollToHorizontalOffset(horiz - 1);
                        AlreadySwiped = true;

                    }



                    //Swipe Right

                    if (PointStart != null && Touch.X < (PointStart.X - 50))
                    {

                        //TODO do stuff here
                        double horiz = _scrollViewer.HorizontalOffset;
                        _scrollViewer.ScrollToHorizontalOffset(horiz+1);
                        AlreadySwiped = true;

                    }

                }

                
            }
            e.Handled = true;

        }
        void CustomListView_TouchDown(object sender, TouchEventArgs e)
        {
            _scrollViewer = RecursiveVisualChildFinder<ScrollViewer>(this) as ScrollViewer;
            TouchStart = e.GetTouchPoint(this);
        }

        void CustomListView_TouchUp(object sender, TouchEventArgs e){
            AlreadySwiped = false;
        }
        void CustomListView_TouchMove(object sender, TouchEventArgs e)
        {
            //_scrollViewer = RecursiveVisualChildFinder<ScrollViewer>(this) as ScrollViewer;

            if (!AlreadySwiped)
            {

                var Touch = e.GetTouchPoint(this);

                //right now a swipe is 200 pixels 



                //Swipe Left

                if (TouchStart != null && Touch.Position.X > (TouchStart.Position.X + 200))
                {

                    //DO STUFF
                    _scrollViewer.ScrollToHorizontalOffset(10);
                    AlreadySwiped = true;
                  
                }



                //Swipe Right

                if (TouchStart != null && Touch.Position.X < (TouchStart.Position.X - 200))
                {

                    //TODO do stuff here
                    _scrollViewer.ScrollToHorizontalOffset(-10);
                    AlreadySwiped = true;

                }

            }

            e.Handled = true;

        }
        private static DependencyObject RecursiveVisualChildFinder<T>(DependencyObject rootObject)  
        {       
            var child = VisualTreeHelper.GetChild(rootObject, 0);  
            if (child == null) return null;  
  
            return child.GetType() == typeof (T) ? child : RecursiveVisualChildFinder<T>(child);  
        }  
    }

}
