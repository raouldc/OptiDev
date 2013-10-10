using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace P02Project
{
    public class Screen : UserControl
    {
        // pointer to the main screen
        private SurfaceWindow1 topLevelWindow;



        /// <summary>
        /// return the main screen (topLevelWindow is the main screen)
        /// </summary>
        public SurfaceWindow1 ParentWindow
        {
            get
            {
                return topLevelWindow;
            }
        }



        /// <summary>
        /// constructor
        /// </summary>
        protected Screen() {}



        /// <summary>
        /// Constructor of a screen
        /// </summary>
        /// <param name="parentWindow"></param>
        public Screen(SurfaceWindow1 parentWindow)
        {
            this.topLevelWindow = parentWindow;
        }
    }
}

