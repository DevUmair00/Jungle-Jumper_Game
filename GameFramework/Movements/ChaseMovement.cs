using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameFrameWork.Entities;
using GameFrameWork.Component;
using GameFrameWork.Core;
using GameFrameWork.Extentions;
using GameFrameWork.Interfaces;
using GameFrameWork.Movements;
using GameFrameWork.System;

namespace GameFrameWork.Movements
{
    internal class ChaseMovement : IMovement
    {

        //target is player
        private GameObject target;
        private float speed;

        public ChaseMovement(GameObject target, float speed)
        {
            this.target = target;
            this.speed = speed;
        }

        public void Move(GameObject obj, GameTime gameTime)
        {

            if (obj.Position.X < target.Position.X)
                obj.Position = new PointF(obj.Position.X + speed, obj.Position.Y);
            else if (obj.Position.X > target.Position.X)
                obj.Position = new PointF(obj.Position.X - speed, obj.Position.Y);


            if (obj.Position.Y < target.Position.Y)
                obj.Position = new PointF(obj.Position.X, obj.Position.Y + speed);
            else if (obj.Position.Y > target.Position.Y)
                obj.Position = new PointF(obj.Position.X, obj.Position.Y - speed);
        }
    }
}


