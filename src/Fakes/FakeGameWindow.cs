using System;

namespace Microsoft.Xna.Framework
{
    internal class FakeGameWindow : GameWindow
    {
        private Rectangle size = new Rectangle(0, 0, 720, 480);
        private string title = "";

        public FakeGameWindow() : base() { }

        public override bool AllowUserResizing { get { return true; } set { } }
        public override Rectangle ClientBounds { get { return size; } }
        public override DisplayOrientation CurrentOrientation { get { return DisplayOrientation.Default; } }
        public override IntPtr Handle { get { return IntPtr.Zero; } }
        public override string ScreenDeviceName { get { return ""; } }

        public override void BeginScreenDeviceChange(bool willBeFullScreen)
        {
        }

        public override void EndScreenDeviceChange(string screenDeviceName, int clientWidth, int clientHeight)
        {
        }

        protected override void SetTitle(string title)
        {
            this.title = title;
        }

        protected internal override void SetSupportedOrientations(DisplayOrientation orientations)
        {
        }
    }
}
