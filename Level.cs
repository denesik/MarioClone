using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using OGLGame.GameObjects;
using OGLGame.physics;
using System.Windows.Forms;

namespace OGLGame
{

    class Level
    {
        public PhysicsWorld physWorld { get; private set; }

        private List<GameObject> ObjList = new List<GameObject>();

        private Player player = null;

        // Загружаем уровень
        public void Load(int number, string filename)
        {
            physWorld = new PhysicsWorld();
            ObjList.Clear();

            StreamReader sr = new StreamReader(filename);
            int n = Convert.ToInt32(sr.ReadLine());
            int m = Convert.ToInt32(sr.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string s = sr.ReadLine();

                for (int j = 0; j < m; j++)
                {
                    GameObjectID obj = (GameObjectID)(Convert.ToInt32(s[j]) - 48);

                    switch (obj)
                    {
                        case GameObjectID.Brick:
                            ObjList.Add(new Brick(this, new System.Drawing.PointF(j * 32, (n - i + 1) * 32)));
                            break;
                        case GameObjectID.Cactus:

                            break;
                        case GameObjectID.Sand:

                            break;
                        case GameObjectID.Steel:

                            break;
                        case GameObjectID.Coin:

                            break;
                        case GameObjectID.Star:

                            break;
                        case GameObjectID.Bird:

                            break;
                        case GameObjectID.Ping:

                            break;
                        case GameObjectID.Player:
                            player = new Player(this, new System.Drawing.PointF(j * 32, (n - i + 1) * 32));
                            ObjList.Add(player);
                            break;

                    }

                }
            }

        }


        public void Draw(int dt)
        {
            foreach (GameObject obj in ObjList)
            {
                obj.Draw(dt);
            }
        }

        public void Resize(int width, int height)
        {
            foreach (GameObject obj in ObjList)
            {
                obj.Resize(width, height);
            }
               
        }

        public void Update(int dt)
        {
            if(Keyboard.isKeyPress(Keys.Space))
            {
                player.Jump();
            }

            if (Keyboard.isKeyDown(Keys.D))
            {
                player.MoveRight();
            }

            if (Keyboard.isKeyDown(Keys.A))
            {
                player.MoveLeft();
            }

            foreach (GameObject obj in ObjList)
            {
                //obj.
            }

            physWorld.Update(dt);
        }

    }
}
