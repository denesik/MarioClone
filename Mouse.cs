using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace OGLGame
{
    static class Mouse
    {
        private static bool leftClick = false;
        private static int x = 0;
        private static int y = 0;

        public static void SetClick(MouseButtons button, int _x, int _y)
        {
            if (button == MouseButtons.Left)
            {
                leftClick = true;
                x = _x;
                y = _y;
            }
        }

        public static bool isLeftClick()
        {
            if (leftClick)
            {
                leftClick = false;
                return true;
            }
            else
                return false;
        }

        public static Point GetPos()
        {
            return new Point(x, y);
        }

    }
}
