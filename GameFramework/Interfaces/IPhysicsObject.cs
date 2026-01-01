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
    public interface IPhysicsObject
    {
        // Indicates whether physics should be applied to this object
        bool HasPhysics { get; set; }

        // Custom gravity for this object (null means use global gravity)
        float? CustomGravity { get; set; }

        // If true the object is considered rigid (immovable) and should stop when colliding
        bool IsRigidBody { get; set; }
        // Note: IPhysicsObject separates the physics-related concerns from the entity's domain logic (single responsibility & interface segregation).
    }
}