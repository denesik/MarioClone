namespace OGLGame
{
    partial class Window
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.OGLWindow = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // OGLWindow
            // 
            this.OGLWindow.AccumBits = ((byte)(0));
            this.OGLWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.OGLWindow.AutoCheckErrors = false;
            this.OGLWindow.AutoFinish = false;
            this.OGLWindow.AutoMakeCurrent = false;
            this.OGLWindow.AutoSwapBuffers = false;
            this.OGLWindow.BackColor = System.Drawing.Color.White;
            this.OGLWindow.ColorBits = ((byte)(32));
            this.OGLWindow.DepthBits = ((byte)(16));
            this.OGLWindow.Location = new System.Drawing.Point(0, 0);
            this.OGLWindow.Name = "OGLWindow";
            this.OGLWindow.Size = new System.Drawing.Size(800, 550);
            this.OGLWindow.StencilBits = ((byte)(0));
            this.OGLWindow.TabIndex = 0;
            this.OGLWindow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Window_KeyDown);
            this.OGLWindow.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Window_KeyUp);
            this.OGLWindow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OGLWindow_MouseClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.OGLWindow);
            this.Name = "Window";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Window_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Window_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Window_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OGLWindow_MouseClick);
            this.Resize += new System.EventHandler(this.Window_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl OGLWindow;
        private System.Windows.Forms.Timer timer1;
    }
}

