using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OGLGame.GameObjects;
using System.Windows;

namespace OGLGame.physics
{
    class PhysicsWorld
    {
        // Список статических и динамических объектов
        private List<PhysObj> StaticObjs = new List<PhysObj>();
        private List<PhysObj> DinamicObjs = new List<PhysObj>();

        // Гравитация
        private Vector gravitation = new Vector(0.0, -9.8);

        public PhysicsWorld()
        {

        }

        public PhysObj CreateStatic(GameObject parent, System.Drawing.Size size, PointF pos)
        {
            PhysObj pho = new PhysObj(parent, size, true);
            pho.SetPos(pos);
            StaticObjs.Add(pho);

            return pho;
        }

        public PhysObj CreateDinamic(GameObject parent, System.Drawing.Size size, PointF pos)
        {
            PhysObj pho = new PhysObj(parent, size, false);
            pho.SetPos(pos);
            DinamicObjs.Add(pho);

            return pho;
        }


        public void Update(int dt)
        {

            foreach (PhysObj obj in DinamicObjs)
            {

                // Применяем силу гравитации
                obj.ApplyForce(gravitation);
                // Обновляем позицию
                Vector objPosOld = obj.pos;
                obj.UpdatePos(dt);
                Vector objPosNew = obj.pos;

                obj.flying = true;

                // Проверяем на коллизии

                // Проверяем коллизии для статических объектов
                // И обрабатываем столкновения
                foreach (PhysObj statObj in StaticObjs)
                {
                    Vector vec = Collision(obj, statObj);
                    if (vec == new Vector())
                    {
                        continue;
                    }

                    // Натолкнулись нижней стороной
                    if (vec.Y == -1)
                    {
                        obj.CleanForceY();
                        if (objPosNew.Y < objPosOld.Y)
                            objPosNew.Y = objPosOld.Y;
                        obj.pos = objPosNew;
                        obj.flying = false;
                    }

                    // Натолкнулись правой стороной
                    if (vec.X == 1)
                    {
                        if (objPosNew.X > objPosOld.X)
                            objPosNew.X = objPosOld.X;
                        obj.pos = objPosNew;
                    }
                    
                    // Натолкнулись левой стороной
                    if (vec.X == -1)
                    {
                        if (objPosNew.X < objPosOld.X)
                            objPosNew.X = objPosOld.X;
                        obj.pos = objPosNew;
                    }

                    // Натолкнулись верхней стороной
                    if (vec.Y == 1)
                    {
                        obj.CleanForceY();
                        if (objPosNew.Y > objPosOld.Y)
                            objPosNew.Y = objPosOld.Y;
                        obj.pos = objPosNew;
                    }
                }

                // Проверяем коллизии для динамических объектов
                foreach (PhysObj statObj in DinamicObjs)
                {
                    Collision(obj, statObj);
                }

            }

        }

        // Возвращает сторону который мы коснулись
        public Vector Collision(PhysObj obj, PhysObj obj2)
        {
            Vector vec = new Vector();

            RectangleF rect1 = new RectangleF((float)obj.pos.X, (float)obj.pos.Y, obj.size.Width, obj.size.Height);
            RectangleF rect2 = new RectangleF((float)obj2.pos.X, (float)obj2.pos.Y, obj2.size.Width, obj2.size.Height);

            if (!rect1.IntersectsWith(rect2))
            {
                return vec;
            }

            float x11 = (float)obj.pos.X;
            float x12 = (float)obj.pos.X + obj.size.Width;
            float y11 = (float)obj.pos.Y;
            float y12 = (float)obj.pos.Y + obj.size.Height;

            // Проверка на столкновение нижней стороной
            if (rect2.Contains(x11 + 2, y11) || rect2.Contains(x12 - 2, y11))
            {
                vec += new Vector(0, -1);
            }
            // Проверка на столкновение правой стороной
            if (rect2.Contains(x12, y11 + 2) || rect2.Contains(x12, y12 - 2))
            {
                vec += new Vector(1, 0);
            }
            // Проверка на столкновение левой стороной
            if (rect2.Contains(x11, y11 + 2) || rect2.Contains(x11, y12 - 2))
            {
                vec += new Vector(-1, 0);
            }
            // Проверка на столкновение верхней стороной
            if (rect2.Contains(x11 + 2, y12) || rect2.Contains(x12 - 2, y12))
            {
                vec += new Vector(0, 1);
            }

            obj.parent.Touch(obj2.parent, vec);

            return vec;
        }

    }
}
