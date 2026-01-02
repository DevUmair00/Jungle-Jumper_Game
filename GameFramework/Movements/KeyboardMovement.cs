using EZInput;
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
                obj.Position = new PointF(obj.Position.X - Speed, obj.Position.Y);

            if (Keyboard.IsKeyPressed(Key.RightArrow))
                obj.Position = new PointF(obj.Position.X + Speed, obj.Position.Y);

            if (Keyboard.IsKeyPressed(Key.DownArrow))
                obj.Position = new PointF(obj.Position.X, obj.Position.Y + Speed);
        }
    }
}
