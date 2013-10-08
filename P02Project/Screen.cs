using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace P02Project
{
    public class Screen : UserControl
    {
        private SurfaceWindow1 topLevelWindow;

        public SurfaceWindow1 ParentWindow
        {
            get
            {
                return topLevelWindow;
            }
        }

        protected Screen() {}

        public Screen(SurfaceWindow1 parentWindow)
        {
            this.topLevelWindow = parentWindow;
        }
    }
}

