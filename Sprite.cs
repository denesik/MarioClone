using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tao.OpenGl;


namespace OGLGame
{
    class Sprite
    {
        private int windowWidth = 800;
        private int windowHeight = 600;

        // Фиксированные размеры
        private PointF pos_g;
        private Size size_g;

        // Динамические размеры. Изменяются при ресайзе окна автоматически
        private PointF pos;
        private Size size;

        // слой
        int layer = 0;

        // текстурные координаты
        private class TextureCoord
        {
            public float u1;
            public float v1;
            public float u2;
            public float v2;
        };

        private Texture texture;

        // Массив текстурных координат
        // Для каждого кадра анимации
        // Если спрайт не анимированный, будет 1 кадр
        private List<TextureCoord> textureCoord;

        // текущий кадр анимации
        int frame = 0;
        int framedt = 0;
        int animatedTime = 0;

        // Отражена ли текстура зеркально по оси y
        bool flip = false;

        // 0 0 - правый верхний угол экрана
        // Имя файла с текстурами, время смены кадра в мс
        public Sprite(string fileName, Size _size, int _animatedTime = 0)
        {
            animatedTime = _animatedTime;

            pos_g.X = 0.0f;
            pos_g.Y = 0.0f;
            pos.X = 0.0f;
            pos.Y = 0.0f;

            size_g.Width = 0;
            size_g.Height = 0;
            size.Width = 0;
            size.Height = 0;

            texture = new Texture(fileName);
            if (texture.size.IsEmpty)
                return;

            int frameCount = texture.size.Width / texture.size.Height;

            textureCoord = new List<TextureCoord>(frameCount);

            float w = (float)texture.size.Width;
            float h = (float)texture.size.Height;

            for (int i = 0; i < frameCount; i++)
            {
                TextureCoord tex = new TextureCoord();

                tex.u1 = (h * i) / w;
                tex.v1 = 1;
                tex.u2 = (h * i + h) / w;
                tex.v2 = 0;

                textureCoord.Add(tex);
            }

            size = size_g = _size;
        }

        public void Draw(int dt, bool animated)
        {
            if (texture.id == 0)
                return;

            if (!animated)
                frame = 0;
            else
            {
                framedt += dt;
                if (framedt >= animatedTime)
                {
                    framedt = 0;
                    frame++;
                    if (frame >= textureCoord.Count)
                        frame = 0;
                }
            }

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture.id);

            Gl.glBegin(Gl.GL_TRIANGLES);

                Gl.glTexCoord2f(textureCoord[frame].u1, textureCoord[frame].v1); Gl.glVertex3f(pos.X, pos.Y, layer); // низ лево
                Gl.glTexCoord2f(textureCoord[frame].u2, textureCoord[frame].v1); Gl.glVertex3f(pos.X + size.Width, pos.Y, layer); // низ право
                Gl.glTexCoord2f(textureCoord[frame].u2, textureCoord[frame].v2); Gl.glVertex3f(pos.X + size.Width, pos.Y + size.Height, layer); // верх право

                Gl.glTexCoord2f(textureCoord[frame].u2, textureCoord[frame].v2); Gl.glVertex3f(pos.X + size.Width, pos.Y + size.Height, layer); // верх право
                Gl.glTexCoord2f(textureCoord[frame].u1, textureCoord[frame].v2); Gl.glVertex3f(pos.X, pos.Y + size.Height, layer); // верх лево
                Gl.glTexCoord2f(textureCoord[frame].u1, textureCoord[frame].v1); Gl.glVertex3f(pos.X, pos.Y, layer); // низ лево

            Gl.glEnd();

        }

        public void Resize(int width, int height)
        {
            windowWidth = width;
            windowHeight = height;

            pos.X = (windowWidth * pos_g.X) / 800;
            pos.Y = (windowHeight * pos_g.Y) / 600;

            size.Width = (windowWidth * size_g.Width) / 800;
            size.Height = (windowHeight * size_g.Height) / 600;
        }

        public void SetPos(PointF _pos)
        {
            pos_g = _pos;
            Resize(windowWidth, windowHeight);
        }

        public void SetPos(float x, float y)
        {
            pos_g.X = x;
            pos_g.Y = y;
            Resize(windowWidth, windowHeight);
        }

        public void Flip(bool b)
        {
            if (flip != b)
            {
                flip = b;

                for (int i = 0; i < textureCoord.Count; i++)
                {
                    float tmpu = textureCoord[i].u1;
                    textureCoord[i].u1 = textureCoord[i].u2;
                    textureCoord[i].u2 = tmpu;
                }

            }
        }
    }
}
