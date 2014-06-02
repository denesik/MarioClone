using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;
using System.Drawing;

namespace OGLGame
{
    public static class GameFont
    {
        // текстурные координаты
        private class TextureCoord
        {
            public float u1;
            public float v1;
            public float u2;
            public float v2;
        };

        // список символов
        private static List<TextureCoord> glyphs;

        private static Texture texture;
        
        
        public static bool Load(string fileName)
        {
            texture = new Texture(fileName);
            if (texture.id == 0)
            {
                return false;
            }

            float w = texture.size.Width;
            float h = texture.size.Height;
            glyphs = new List<TextureCoord>(256);

            for (int i = 15; i >= 0; i--)
            {
                for (int j = 0; j < 16; j++)
                {
                    TextureCoord tc = new TextureCoord();
                    tc.u1 = ((w / 16) * j) / w;
                    tc.v1 = ((h / 16) * i + h / 16) / h;
                    tc.u2 = ((w / 16) * j + w / 16) / w;
                    tc.v2 = ((h / 16) * i) / h;

                    glyphs.Add(tc);
                }
            }

            return true;
        }

        public static void Print(int x, int y, int z, int size, string text)
        {

            float posX = x;
            float posY = y;
            float posZ = z;

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture.id);
            Gl.glBegin(Gl.GL_TRIANGLES);
            //Gl.glColor4f(1, 1, 0, 0);


            for (int i = 0; i < text.Length; i++)
            {

                Gl.glTexCoord2f(glyphs[text[i]].u1, glyphs[text[i]].v1); Gl.glVertex3f(posX, posY, posZ); // низ лево
                Gl.glTexCoord2f(glyphs[text[i]].u2, glyphs[text[i]].v1); Gl.glVertex3f(posX + size, posY, posZ); // низ право
                Gl.glTexCoord2f(glyphs[text[i]].u2, glyphs[text[i]].v2); Gl.glVertex3f(posX + size, posY + size, posZ); // верх право

                Gl.glTexCoord2f(glyphs[text[i]].u2, glyphs[text[i]].v2); Gl.glVertex3f(posX + size, posY + size, posZ); // верх право
                Gl.glTexCoord2f(glyphs[text[i]].u1, glyphs[text[i]].v2); Gl.glVertex3f(posX, posY + size, posZ); // верх лево
                Gl.glTexCoord2f(glyphs[text[i]].u1, glyphs[text[i]].v1); Gl.glVertex3f(posX, posY, posZ); // низ лево

                posX += size;
            }
            Gl.glEnd();
        }

        public static Size GetRect(int size, string text)
        {
            Size bsize = new Size();

            bsize.Height = size;
            bsize.Width = text.Length * size;

            return bsize;
        }
    }
}
