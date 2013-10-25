#region

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Surface;
using Microsoft.Surface.Presentation.Controls;
using P02Project.Screens;
using P02Project.Utils;

#endregion

namespace P02Project
{
    /// <summary>
    ///     Interaction logic for TopWindow.xaml
    /// </summary>
    public partial class TopWindow : SurfaceWindow
    {
        //Timer for inactivity
        private readonly DispatcherTimer inavtiveTimer;

        private readonly Stack<Screen> stackOfScreens;

        /// <summary>
        ///     Default constructor.
        /// </summary>
        public TopWindow()
        {
            InitializeComponent();

            inavtiveTimer = new DispatcherTimer();
            inavtiveTimer.Interval = TimeSpan.FromSeconds(120);
            inavtiveTimer.Tick += inavtiveTimer_Tick;

            stackOfScreens = new Stack<Screen>();
            //Setting starting Screen here, maybe should be in one of the other OnXXX methods of this class
            pushScreen(new HomePage(this));

            WindowStyle = WindowStyle.None;
            WindowState = WindowState.Maximized;
        }

        private void inavtiveTimer_Tick(object sender, EventArgs e)
        {
            popAll();
            pushScreen(new HomePage(this));
        }

        /// <summary>
        ///     Occurs when the window is about to close.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }

        /// <summary>
        ///     Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        ///     Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        ///     This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        ///     This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        ///     This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

        /// <summary>
        /// pop a screen
        /// </summary>
        public void popScreen()
        {
            if (stackOfScreens.Count > 1)
            {
                stackOfScreens.Pop();
                Content = stackOfScreens.Peek();

                (Content as Animatiable).AnimateIn();
            }

            ResetTimer();
        }

        /// <summary>
        /// push the given screen into the stack
        /// </summary>
        /// <param name="screen"></param>
        public void pushScreen(Screen screen)
        {
            stackOfScreens.Push(screen);
            Content = stackOfScreens.Peek();
            ResetTimer();
        }

        /// <summary>
        /// pop all the screen on the stack => show the Home Screen
        /// </summary>
        public void popAll()
        {
            while (stackOfScreens.Count > 1)
            {
                stackOfScreens.Pop();
            }
            Content = stackOfScreens.Peek();
            ResetTimer();
        }

        /// <summary>
        /// push the given screen into the screen stack
        /// </summary>
        public void pushScreenOnStack(TopLevelPage nextScreen, String[] buttons, Color colour, UserControl content,
            String Subtitle)
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

        /// <summary>
        /// Helper method to reset the timer
        /// </summary>
        public void ResetTimer()
        {
            inavtiveTimer.Stop();
            inavtiveTimer.Start();
        }

        /// <summary>
        /// Helper method to stop the timer
        /// </summary>
        public void StopTimer()
        {
            inavtiveTimer.Stop();
        }

        /// <summary>
        /// Helper method to start the timer
        /// </summary>
        public void StartTimer()
        {
            inavtiveTimer.Start();
        }
    }
}