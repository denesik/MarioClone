using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OGLGame.GUI
{
    class Container
    {
        private List<GUIElement> elements = new List<GUIElement>();

        public void Add(GUIElement el)
        {
            elements.Add(el);
        }

        public void Resize(int width, int height)
        {
            foreach (GUIElement el in elements)
            {
                el.Resize(width, height);
            }
        }

        public void Draw()
        {
            foreach (GUIElement el in elements)
            {
                el.Draw();
            }
        }

        public void Update()
        {
            Point mousePos = Mouse.GetPos();
            if (Mouse.isLeftClick())
            {
                foreach (GUIElement el in elements)
                {
                    if (el.GetRectDin().Contains(mousePos))
                    {
                        el.EventClick(mousePos.X, mousePos.Y);
                        return;
                    }
                }
            }
        }

    }
}
