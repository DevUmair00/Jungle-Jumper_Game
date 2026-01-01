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

namespace GameFrameWork.Interfaces
{
    public interface ICollidable
    {
        // Bounds of the object for collision detection
        RectangleF Bounds { get; }

        // Method to handle collision with another object

        // Reaction hook invoked when a collision occurs; objects decide their own responses.
        void OnCollision(GameObject other);
    }
}