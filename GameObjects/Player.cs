using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows;

namespace OGLGame.GameObjects
{
    class Player : GameObject
    {
        public Player(Level level, PointF _pos)
            : base(level, GameObjectID.Player)
        {
            sprite = new Sprite("hero.png", size, 60);
            pos = _pos;
            physObj = level.physWorld.CreateDinamic(this, size, pos);
        }

        // Мы коснулись какого то объекта
        public override void Touch(GameObject obj, System.Windows.Vector dir)
        {
            
        }

        public void Jump()
        {
            if(!physObj.flying)
            {
                physObj.ApplyForce(new Vector(0.0, 480.0));
            }
        }

        public void MoveRight()
        {
            physObj.ApplyForce(new Vector(100.0, 0.0));
        }

        public void MoveLeft()
        {
            physObj.ApplyForce(new Vector(-100.0, 0.0));
        }

    }
}
