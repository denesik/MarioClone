using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tao.DevIl;
using Tao.OpenGl;
using System.Drawing;

namespace OGLGame
{
    // Класс для загрузки текстуры в память
    // Рисовать текстуру будем в классе Sprite
    class Texture
    {
        public Size size;

        public uint id;

        public Texture(string fileName)
        {
            size.Width = 0;
            size.Height = 0;
            id = 0;

            int imageId;
            // создаем изображение с индификатором imageId 
            Il.ilGenImages(1, out imageId);
            // делаем изображение текущим 
            Il.ilBindImage(imageId);

            if (!Il.ilLoadImage(fileName))
            {
                Log.Instance.Write("Текстура " + fileName + " не загружена.");
                return;
            }

            // если загрузка прошла успешно 
            // сохраняем размеры изображения 
            size.Width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
            size.Height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

            // определяем число бит на пиксель 
            int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);

            switch (bitspp) // в зависимости оп полученного результата 
            {

                // создаем текстуру используя режим GL_RGB или GL_RGBA 
                case 24:
                    id = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), size.Width, size.Height);
                    break;
                case 32:
                    id = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), size.Width, size.Height);
                    break;

            }

            // очищаем память 
            Il.ilDeleteImages(1, ref imageId);

            Log.Instance.Write("Текстура " + fileName + " загружена.");
        }

        
        private uint MakeGlTexture(int Format, IntPtr pixels, int w, int h)
        {
            // индетефекатор текстурного объекта 
            uint texObject;

            // генерируем текстурный объект 
            Gl.glGenTextures(1, out texObject);

            // устанавливаем режим упаковки пикселей 
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);

            // создаем привязку к только что созданной текстуре 
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texObject);

            // устанавливаем режим фильтрации и повторения текстуры 
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);

            // создаем RGB или RGBA текстуру 
            switch (Format)
            {
                case Gl.GL_RGB:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;

                case Gl.GL_RGBA:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;

            }

            return texObject;
        }

    }
}
