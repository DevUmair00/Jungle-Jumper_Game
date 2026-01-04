using GameFrameWork.Entities;
using GameFrameWork.Interfaces;

namespace GameFrameWork.System
{
    public class PhysicsSystem
    {
        // Global gravity value (can be positive or negative)
        public float Gravity { get; set; } = 0.5f;

        // Apply physics to objects that have physics enabled
        public void Apply(List<GameObject> objects)
        {
            foreach (var obj in objects.OfType<IPhysicsObject>().Where(o => o.HasPhysics))
            {
                if (obj is IMovable movable)
                {
                    // Use the object custom gravity if set, otherwise use the global gravity
                    float appliedGravity = obj.CustomGravity ?? Gravity;

                    // Update the velocity of the object by applying gravity.
                    // Note: This is simple Euler integration and illustrates the physics update responsibility.
                    movable.Velocity = new PointF(
                        movable.Velocity.X, // Horizontal velocity remains unchanged
                        movable.Velocity.Y + appliedGravity // Vertical velocity changes based on gravity
                    );

                    if (obj is GameObject gameObject)
                    {
                        // Update the position of the object based on its (now-updated) velocity
                        gameObject.Position = new PointF(
                            gameObject.Position.X + movable.Velocity.X,
                            gameObject.Position.Y + movable.Velocity.Y
                        );
                    }
                }
            }

            foreach (var obj in objects)
            {
                if (!obj.HasPhysics) continue;

                float gravity = obj.CustomGravity ?? Gravity;
                obj.Velocity = new PointF(obj.Velocity.X, obj.Velocity.Y + gravity);
            }
        }
    }
}