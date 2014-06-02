using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OGLGame.GUI
{
    class Button : Label
    {

        public delegate void delegateOnClick();
        public event delegateOnClick onClick;

        public Button(Rectangle r, string mess, int borderWidth = 1)
            : base(r, mess, borderWidth)
        {
            
        }

        public override void EventClick(int x, int y)
        {
            onClick();
        }
    }
}
