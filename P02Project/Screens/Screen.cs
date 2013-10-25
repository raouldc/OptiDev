#region

using System.Windows.Controls;

#endregion

namespace P02Project
{
    public class Screen : UserControl
    {
        // pointer to the main screen
        private readonly TopWindow topLevelWindow;


        /// <summary>
        ///     constructor
        /// </summary>
        protected Screen()
        {
        }


        /// <summary>
        ///     Constructor of a screen
        /// </summary>
        /// <param name="parentWindow"></param>
        public Screen(TopWindow parentWindow)
        {
            topLevelWindow = parentWindow;
        }

        /// <summary>
        ///     return the main screen (topLevelWindow is the main screen)
        /// </summary>
        public TopWindow ParentWindow
        {
            get { return topLevelWindow; }
        }
    }
}