using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows;
using OGLGame.physics;

namespace OGLGame.GameObjects
{
    // Типы игровых объектов
    enum GameObjectID
    {
        Empty = 0,
        Player = 1,   // герой
        Bird = 2,   // птица
        Star = 3,   // звезда
        Ping = 4,   // пингвин
        Brick = 5,  // кирпич
        Cactus = 6, // кактус
        Sand = 7,   // песок
        Steel = 8,  // сталь
        Coin = 9,   // монета
    }

    // Игровой объект
    // Содержит спрайт
    class GameObject
    {
        // Объекты знают в каком мире они существуют
        protected Level level;
        // Тип объекта
        public GameObjectID id { get;  protected set; }

        // Позиция и размеры объекта
        // Правый нижний угол мира равен координатам (0; 0)
        // Правый нижний угол объекта равен координатам (0; 0)
        public PointF pos { get; set; }
        protected System.Drawing.Size size = new System.Drawing.Size(32, 32);

        // Графическая составляющая
        protected Sprite sprite = null;

        // Физическая составляющая
        protected PhysObj physObj = null;

        // Указатель на level, id (тип) объекта, текстура, время анимации
        public GameObject(Level _level, GameObjectID _id)
        {
            id = _id;
            level = _level;
//            pos = new PointF(0, 0);
        }

        public virtual void Draw(int dt)
        {
            UpdatePos();
            // Преобразуем систему координат
            sprite.SetPos(pos.X, 600 - pos.Y + size.Height);
            sprite.Draw(dt, true);
        }

        public virtual void Resize(int width, int height)
        {
            sprite.Resize(width, height);
        }


        // События которые возникают при коллизиях
        // obj - объект которого коснулись
        // dir - направление вектора; Какой стороной мы коснулись этого объекта
        public virtual void Touch(GameObject obj, Vector dir)
        {

        }


        private void UpdatePos()
        {
            pos = physObj.GetPos();
        }
    }
}
