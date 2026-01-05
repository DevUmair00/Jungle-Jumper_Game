using GameFrameWork.Core;
using GameFrameWork.Entities;

namespace GameFrameWork.Extentions
{

    public class Bullet : GameObject
    {
        // Bullets set a default velocity in the constructor - a simple example of behavior initialization.

        public Bullet()
        {
            HasPhysics = false; // bullets ignore gravity
            IsRigidBody = false;
        }


        public float Speed { get; set; } = 15f;

        public PointF Direction { get; set; } = new PointF(1, 0); // Default moves right


        /// Bullets use the default movement logic (base.Update) and deactivate when off-screen.
        /// Consider extending with continous collision detection (CCD) to avoid tunnelling at high speeds.


        public override void Update(GameTime gameTime)
        {
            // Move bullet
            Position = new PointF(Position.X + Direction.X * Speed, Position.Y + Direction.Y * Speed);
            base.Update(gameTime);
        }



        /// Simple visual representation for bullets (polymorphism example).

        public override void Draw(Graphics g)
        {
            if (Sprite != null)
                base.Draw(g);
            else
                g.FillRectangle(Brushes.Yellow, Bounds);
        }



        /// On collision bullets deactivate when hitting an enemy.
        /// Keep collision reaction encapsulated in the object class.

        public override void OnCollision(GameObject other)
        {
            if (other.IsRigidBody || other is Enemy || other.Name == "Box")
            {
                IsActive = false;
            }
        }





    }
}
