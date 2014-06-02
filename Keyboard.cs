using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace OGLGame
{
    static class Keyboard
    {
        public enum KeyState
        {
            KeyUp = 0,
            KeyDown = 1,
            KeyPress = 2
        }

        private static KeyState[] keys = new KeyState[256];

        public static void Init()
        {
            for (int i = 0; i < 256; i++)
            {
                keys[i] = KeyState.KeyUp;
            }
        }

        public static void SetKey(Keys key, KeyState state)
        {
            keys[(int)key] = state;
        }

        public static bool isKeyPress(Keys key)
        {
            if (keys[(int)key] == KeyState.KeyPress)
            {
                keys[(int)key] = KeyState.KeyDown;
                return true;
            }

            return false;
        }

        public static bool isKeyUp(Keys key)
        {
            if (keys[(int)key] == KeyState.KeyUp)
                return true;

            return false;
        }

        public static bool isKeyDown(Keys key)
        {
            if (keys[(int)key] == KeyState.KeyDown || keys[(int)key] == KeyState.KeyPress)
                return true;

            return false;
        }

    }
}
