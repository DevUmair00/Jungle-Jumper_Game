using GameFrameWork.Core;
using GameFrameWork.Entities;
using GameFrameWork.Interfaces;
using System.Drawing;

namespace GameFrameWork.Movements
{
    public class PatrolMovement : IMovement
    {
        private float leftBound;
        private float rightBound;
        private float speed;
        private int direction = 1; // 1 = right, -1 = left

        public PatrolMovement(float left, float right, float speed = 2f)
        {
            leftBound = left;
            rightBound = right;
            this.speed = speed;
        }

        public void Move(GameObject obj, GameTime gameTime)
        {
            obj.Velocity = new PointF(speed * direction, obj.Velocity.Y);

            if (obj.Position.X <= leftBound)
            {
                obj.Position = new PointF(leftBound, obj.Position.Y);
                Reverse();
            }
            else if (obj.Position.X + obj.Size.Width >= rightBound)
            {
                obj.Position = new PointF(rightBound - obj.Size.Width, obj.Position.Y);
                Reverse();
            }
        }


        public void Reverse()
        {
            direction *= -1;
        }
    }
}
