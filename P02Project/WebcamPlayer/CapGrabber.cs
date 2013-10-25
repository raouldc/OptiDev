#region

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

#endregion

namespace CatenaLogic.Windows.Presentation.WebcamPlayer
{
    internal class CapGrabber : ISampleGrabberCB, INotifyPropertyChanged
    {
        #region Win32 imports

        [DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory")]
        private static extern void CopyMemory(IntPtr Destination, IntPtr Source, int Length);

        #endregion

        #region Variables

        private int _height = default(int);
        private int _width = default(int);

        #endregion

        #region Constructor & destructor

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler NewFrameArrived;

        #endregion

        #region Properties

        public IntPtr Map { get; set; }

        /// <summary>
        ///     Gets or sets the width of the grabber
        /// </summary>
        public int Width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged("Width");
            }
        }

        /// <summary>
        ///     Gets or sets the height of the grabber
        /// </summary>
        public int Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged("Height");
            }
        }

        #endregion

        #region Methods

        public int SampleCB(double sampleTime, IntPtr sample)
        {
            return 0;
        }

        public int BufferCB(double sampleTime, IntPtr buffer, int bufferLen)
        {
            if (Map != IntPtr.Zero)
            {
                CopyMemory(Map, buffer, bufferLen);
                OnNewFrameArrived();
            }
            return 0;
        }

        private void OnNewFrameArrived()
        {
            if (NewFrameArrived != null)
            {
                NewFrameArrived(this, null);
            }
        }

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}