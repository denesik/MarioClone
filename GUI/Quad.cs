using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tao.OpenGl;

namespace OGLGame.GUI
{
    class Quad
    {
        int windowWidth = 800;
        int windowHeight = 600;

        // фиксированный размер
        private Rectangle rect_g;

        // динамический размер
        private Rectangle rect;

        private int borderWidth;

        public Quad(Rectangle r, int w = 1)
        {
            rect_g = r;
            rect = r;
            borderWidth = w;
        }

        public void SetPos(Point pos)
        {
            rect.Location = pos;
            Resize(windowWidth, windowHeight);
        }

        public void SetSize(Size size)
        {
            rect.Size = size;
            Resize(windowWidth, windowHeight);
        }

        public Rectangle GetRect()
        {
            return rect_g;
        }

        public Rectangle GetRectDin()
        {
            return rect;
        }

        // Устанавливает толщину линий
        public void SetBorderWidth(int w)
        {
            borderWidth = w;
        }

        public void Draw()
        {
            if (borderWidth == 0)
            {
                return;
            }

            Gl.glColor4f(0, 0, 1, 1);

            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glLineWidth(borderWidth);
            Gl.glBegin(Gl.GL_LINE_STRIP);
                Gl.glVertex3f(rect.X, rect.Y, 0.0f);
                Gl.glVertex3f(rect.X, rect.Y + rect.Height, 0.0f);
                Gl.glVertex3f(rect.X + rect.Width, rect.Y + rect.Height, 0.0f);
                Gl.glVertex3f(rect.X + rect.Width, rect.Y, 0.0f);
                Gl.glVertex3f(rect.X, rect.Y, 0.0f);
            Gl.glEnd();
            Gl.glEnable(Gl.GL_TEXTURE_2D);
        }

        public void Resize(int w, int h)
        {
            windowWidth = w;
            windowHeight = h;

            rect.X = (windowWidth * rect_g.X) / 800;
            rect.Y = (windowHeight * rect_g.Y) / 600;

            rect.Width = (windowWidth * rect_g.Width) / 800;
            rect.Height = (windowHeight * rect_g.Height) / 600;
        }

    }
}
