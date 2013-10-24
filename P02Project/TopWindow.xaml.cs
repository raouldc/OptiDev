using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Surface;
using Microsoft.Surface.Presentation.Controls;
using P02Project.Screens;
using P02Project.Utils;
using System.Windows.Threading;


namespace P02Project
{
    /// <summary>
    /// Interaction logic for TopWindow.xaml
    /// </summary>
    public partial class TopWindow : SurfaceWindow
    {
        //Timer for inactivity
        private DispatcherTimer inavtiveTimer;
        
        private Stack<Screen> stackOfScreens;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TopWindow()
        {
            InitializeComponent();

            inavtiveTimer = new DispatcherTimer();
            inavtiveTimer.Interval = TimeSpan.FromSeconds(120);
            inavtiveTimer.Tick += new EventHandler(inavtiveTimer_Tick);

            stackOfScreens = new Stack<Screen>();
            //Setting starting Screen here, maybe should be in one of the other OnXXX methods of this class
            pushScreen(new HomePage(this));

            this.WindowStyle = System.Windows.WindowStyle.None;
            this.WindowState = System.Windows.WindowState.Maximized;
        }

        void inavtiveTimer_Tick(object sender, EventArgs e)
        {
            popAll();
            pushScreen(new HomePage(this));
        }

        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

        public void popScreen()
        {
        
            if (stackOfScreens.Count > 1)
            {
                stackOfScreens.Pop();
                this.Content = stackOfScreens.Peek();

                (this.Content as Animatiable).AnimateIn();
            }

            ResetTimer();
        }
        public void pushScreen(Screen screen)
        {
            stackOfScreens.Push(screen);
            this.Content = stackOfScreens.Peek();
            ResetTimer();
        }

        public void popAll()
        {
           
            while (stackOfScreens.Count > 1)
            {
                stackOfScreens.Pop();
            }
            this.Content = stackOfScreens.Peek();
            ResetTimer();
        }

        public void pushScreenOnStack(TopLevelPage nextScreen, String[] buttons, Color colour, UserControl content, String Subtitle)
        {
            nextScreen.setButtons(buttons);
            nextScreen.setTitleColour(colour);
            nextScreen.setContent(content);
            nextScreen.setSubtitle(Subtitle);
            popAll();
            pushScreen(nextScreen);

            try
            {
                (content as Animatiable).AnimateIn();
            }
            catch (NullReferenceException)
            {
                //Do nothing with this
            }
        }

        public void ResetTimer()
        {
            inavtiveTimer.Stop();
            inavtiveTimer.Start();
        }

        public void StopTimer()
        {
            inavtiveTimer.Stop();
        }

        public void StartTimer()
        {
            inavtiveTimer.Start();
        }
    
    }
}