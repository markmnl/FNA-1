using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.src.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Xna.Framework
{
    internal static class FakePlatform
    {
        private static string[] gamePadGuids = new string[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
        private static byte[] fakeTexture = new byte[25];

        public static FakeGameWindow CreateWindow() { return new FakeGameWindow(); }
        public static void DisposeWindow(GameWindow window) { }
        public static void BeforeInit() { }
        public static void RunLoop(Game game)
        {
            while (game.RunApplication)
            {
                game.Tick();
            }
            game.Exit();
        }
        public static IGLDevice CreateGLDevice(PresentationParameters presentationParameters) { return new FakeGLDevice(presentationParameters); }
        public static IALDevice CreateALDevice() { return new NullDevice(); }
        public static void SetPresentationInterval(PresentInterval interval) { }
        public static GraphicsAdapter[] GetGraphicsAdapters()
        {
            return new GraphicsAdapter[1]
            {
                new GraphicsAdapter(new DisplayMode(720, 480, SurfaceFormat.Color),
                    new DisplayModeCollection(new List<DisplayMode>
                    {
                        new DisplayMode(720, 480, SurfaceFormat.Color)
                    }),
                    "")
            };
        }
        public static Keys GetKeyFromScancode(Keys scancode) { return scancode; }
        public static void StartTextInput() { }
        public static void StopTextInput() { }
        public static void GetMouseState(out int x, out int y, out ButtonState left, out ButtonState middle, out ButtonState right, out ButtonState x1, out ButtonState x2)
        {
            x = 0;
            y = 0;
            left = ButtonState.Released;
            middle = ButtonState.Released;
            right = ButtonState.Released;
            x1 = ButtonState.Released;
            x2 = ButtonState.Released;
        }
        public static void SetMousePosition(IntPtr win, int x, int y) { }
        public static void OnIsMouseVisibleChanged(bool visible) { }
        public static GamePadCapabilities GetGamePadCapabilities(int index) { return new GamePadCapabilities() { }; }
        public static GamePadState GetGamePadState(int index, GamePadDeadZone deadZone) { return new GamePadState(); }
        public static bool SetGamePadVibration(int index, float left, float right) { return true; }
        public static string GetGamePadGUID(int index) { return gamePadGuids[index]; }
        public static void SetGamePadLightBar(int index, Color color) { }
        public static string GetStorageRoot() { return ""; }
        public static bool IsStoragePathConnected(string path) { return true; }
        public static void ShowRuntimeError(string title, string msg) { }
        public static void TextureDataFromStream(Stream stream, out int width, out int height, out byte[] pixels, int reqWidth = -1, int reqHeight = -1, bool zoom = false)
        {
            width = 5;
            height = 5;
            pixels = fakeTexture;
        }
        public static void SavePNG(Stream stream, int width, int height, int imgWidth, int imgHeight, byte[] data){}
    }
}
