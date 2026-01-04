using EZInput;
using GameFrameWork.Core;
using GameFrameWork.Entities;
using GameFrameWork.Interfaces;

namespace GameFrameWork.Movements
{
    public class KeyboardMovement : IMovement
    {
        // Speed is in pixels per second
        public float Speed = 5f;

        public KeyboardMovement(float Speed)
        {
            this.Speed = Speed;
        }

        public KeyboardMovement() { }

        public void Move(GameObject obj, GameTime gameTime)
        {

            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                obj.HasPhysics = true;
                obj.Position = new PointF(obj.Position.X - Speed, obj.Position.Y);
            }

            //if (Keyboard.IsKeyPressed(Key.UpArrow))
            //{
            //    obj.Position = new PointF(obj.Position.X, obj.Position.Y - Speed);
            //}

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                obj.HasPhysics = true;
                obj.Position = new PointF(obj.Position.X + Speed, obj.Position.Y);
            }

            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                obj.HasPhysics = true;
                obj.Position = new PointF(obj.Position.X, obj.Position.Y + Speed);
            }
        }
    }
}
