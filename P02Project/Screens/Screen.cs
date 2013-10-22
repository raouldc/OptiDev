using System.Windows.Controls;

namespace P02Project
{
    public class Screen : UserControl
    {
        // pointer to the main screen
        private TopWindow topLevelWindow;



        /// <summary>
        /// return the main screen (topLevelWindow is the main screen)
        /// </summary>
        public TopWindow ParentWindow
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
        public Screen(TopWindow parentWindow)
        {
            this.topLevelWindow = parentWindow;
        }
    }
}

