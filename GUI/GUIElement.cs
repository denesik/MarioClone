using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OGLGame.GUI
{
    class GUIElement
    {
        protected Rectangle rect = new Rectangle();

        public void SetPos(Point pos)
        {
            rect.Location = pos;
        }

        public void SetSize(Size size)
        {
            rect.Size = size;
        }

        public void SetRect(Rectangle r)
        {
            rect = r;
        }

        // Размер при разрешении 800х600
        public Rectangle GetRect()
        {
            return rect;
        }

        // Размер которые изменяется при изменении разрешения
        public virtual Rectangle GetRectDin()
        {
            return new Rectangle();
        }

        public virtual void Resize(int width, int height)
        {

        }

        public virtual void Draw()
        {
            
        }

        public virtual void EventClick(int x, int y)
        {

        }

    }
}
