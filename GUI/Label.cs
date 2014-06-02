using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OGLGame.GUI
{
    class Label : GUIElement
    {
        protected string text;

        protected Quad quad;

        protected Rectangle textRect;

        public Label()
        {

        }

        public Label(Rectangle r, string mess, int borderWidth = 0)
        {
            rect = r;
            quad = new Quad(rect, borderWidth);

            SetText(mess);          
        }

        public void SetText(string mess)
        {
            text = mess;
            textRect.Size = GameFont.GetRect(14, text);

            Resize(800, 600);
        }

        public override void Draw()
        {
            quad.Draw();
            GameFont.Print(textRect.X, textRect.Y, 0, 14, text);
        }

        public override void Resize(int width, int height)
        {
            quad.Resize(width, height);

            textRect.X = (quad.GetRectDin().Width - textRect.Width) / 2 + quad.GetRectDin().X;
            textRect.Y = (quad.GetRectDin().Height - textRect.Height) / 2 + quad.GetRectDin().Y;

        }

        public override Rectangle GetRectDin()
        {
            return quad.GetRectDin();
        } 

    }
}
