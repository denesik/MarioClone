using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OGLGame.GameObjects
{
    class Brick : GameObject
    {
        public Brick(Level level, PointF _pos)
            : base(level, GameObjectID.Brick)
        {
            sprite = new Sprite("brick.png", size);
            pos = _pos;
            physObj = level.physWorld.CreateStatic(this, size, pos);
        }

    }
}
