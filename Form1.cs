using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tao.Platform.Windows;
using Tao.OpenGl;
using Tao.DevIl;
using OGLGame.GUI;

namespace OGLGame
{
    public partial class Window : Form
    {
        int dtTmp = System.Environment.TickCount;

        Game game = new Game();

        public Window()
        {
            InitializeComponent();
            OGLWindow.InitializeContexts();

            // инициализация библиотеки openIL 
            Il.ilInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);

            Keyboard.Init();

        }

        // Обработчик событий загрузки формы
        private void Window_Load(object sender, EventArgs e)
        {
            OGLWindowInit();
            OGLWindowResize();

            LoadContent();
        }

        private void Window_Resize(object sender, EventArgs e)
        {
            OGLWindowResize();
            game.Resize(this.Width, this.Height);
        }


        private void OGLWindowInit()
        {
            // настройка параметров OpenGL для визуализации 

            Gl.glShadeModel(Gl.GL_SMOOTH);          // Разрешить плавное цветовое сглаживание 

            Gl.glClearColor(1.0f, 1.0f, 1.0f, 1.0f);   


            Gl.glClearDepth(1.0f);          // Разрешить очистку буфера глубины
            Gl.glEnable(Gl.GL_DEPTH_TEST);  // Разрешить тест глубины
            Gl.glDepthFunc(Gl.GL_LEQUAL);   // Тип теста глубины

            // Включаем прозрачность
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

            Gl.glEnable(Gl.GL_TEXTURE_2D);
        }

        private void OGLWindowResize()
        {
            OGLWindow.Width = this.Width - 16;
            OGLWindow.Height = this.Height - 38;
            // очитка окна 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            // установка порта вывода в соотвествии с размерами элемента anT 
            Gl.glViewport(0, 0, OGLWindow.Width, OGLWindow.Height);

            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(0, Width, Height, 0, 0, 100);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Обрабатываем логику
            // Обрабатываем физику
            // Рисуем графику
             
            // Время в миллисекундах
            int dt = System.Environment.TickCount - dtTmp;
            dtTmp = System.Environment.TickCount;
            

            Gl.glLoadIdentity();
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(0.0f, 1.0f, 0.0f, 0.0f);

            if (!game.Run(dt))
            {
                this.Close();
            }

            this.OGLWindow.SwapBuffers();

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            if(Keyboard.isKeyUp(e.KeyCode))
            {
                Keyboard.SetKey(e.KeyCode, Keyboard.KeyState.KeyPress);
                return;
            }
            Keyboard.SetKey(e.KeyCode, Keyboard.KeyState.KeyDown);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            Keyboard.SetKey(e.KeyCode, Keyboard.KeyState.KeyUp);
        }

        // загружаем ресурсы
        private void LoadContent()
        {
            GameFont.Load(@"font.png");
            //level.LoadContent();
            game.LoadContent();
        }

        private void OGLWindow_MouseClick(object sender, MouseEventArgs e)
        {
            Mouse.SetClick(e.Button, e.X, e.Y);
        }


    }
}
