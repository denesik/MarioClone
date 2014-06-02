using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OGLGame.GameObjects;
using System.Drawing;
using System.Windows;

namespace OGLGame.physics
{
    class PhysObj
    {
        
        // Физический объект знает кому он принадлежит
        public GameObject parent { get; private set; }

        // Размер боундбокса
        public System.Drawing.Size size { get; private set; }

        // Является ли физический объект статическим
        private bool stateStatic;


        // масса
        public float mass { get; private set; }

        // Положение в пространстве.
        public Vector pos { get; set; }

        // Скорость.
        private Vector vel = new Vector();

        // Воздействующая сила.
        private Vector force = new Vector();

        public bool flying { get; set; }

        public PhysObj(GameObject _parent, System.Drawing.Size _size, bool _stateStatic = true)
        {
            parent = _parent;
            size = _size;
            stateStatic = _stateStatic;
            mass = 1;
        }

        public void SetPos(PointF _pos)
        {
            pos = new Vector(_pos.X, _pos.Y);
        }

        public PointF GetPos()
        {
            return new PointF((float)pos.X, (float)pos.Y);
        }

        // Применяем силу к телу
        public void ApplyForce(Vector f)
        {
            force += f;
        }

        public void CleanForceY()
        {
            vel = new Vector(vel.X, 0);
        }

        public void CleanForceX()
        {
            vel = new Vector(0, vel.Y);
        }

        // Узнаем куда хочет переместиться юнит
        public virtual PointF UpdatePos(int dt)
        {
            float dtf = dt / 300.0f;

            // Изменение в скорости добавляем к
            // текущей скорости. Изменение
            // пропорционально ускорению
            // (сила/масса) и изменению времени
            vel += (force / mass) * dtf;


            // Ограничим скорость
            if (vel.X > 30)     vel.X = 30;
            if (vel.X < -30)    vel.X = -30;

            int speed = 100;
            if (flying)
            {
                speed = 50;
            }

            if (vel.Y > 100) vel.Y = speed;
            if (vel.Y < -100) vel.Y = -speed;
            



            // Равномерное движение
            // movement / m




            // Изменение в положении добавляем к
            // текущему положению. Изменение в
            // положении Скорость*время
            pos += vel * dtf;

            // Симуляция трения
            int slowdown = 1;
            if (vel.X > slowdown) vel.X -= slowdown;
            if (vel.X < -slowdown) vel.X += slowdown;
            if (vel.X <= slowdown && vel.X >= -slowdown)
                vel.X = 0;


            // обнулим воздействующие силы
            force = new Vector();

            return GetPos();
        }
    }
}
