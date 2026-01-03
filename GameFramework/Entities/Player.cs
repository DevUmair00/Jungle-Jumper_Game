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

namespace GameFrameWork.Entities
{
    public class Player : GameObject
    {
        // Movement strategy: demonstrates composition over inheritance.
        // Different movement behaviors can be injected (KeyboardMovement, PatrolMovement, etc.).
        public IMovement? Movement { get; set; }

        public bool IsMoving { get; set; } = false;

        // Domain state
        public int Health { get; set; } = 100;
        public int Score { get; set; } = 0;


        private float fireCooldown = 0.3f;   // seconds
        private float fireTimer = 0f;


        public Player() { }

        public Player(Image sprite , PointF startPos , float speed) 
        {
           this.Sprite = sprite;
           this.Position = startPos;
           this.Movement = new KeyboardMovement(speed);
           this.Size = new Size(sprite.Width, sprite.Height);
        }


        /// Update the player: delegate movement to the Movement strategy (if provided) and then apply base update.
        /// Shows the Strategy pattern (movement behavior varies independently from Player class).
        /// 
        public override void Update(GameTime gameTime)
        {
            fireTimer -= gameTime.DeltaTime;

            // Prefer the Movements collection (allows multiple movement behaviours).
            if (Movements != null && Movements.Count > 0)
            {
                ApplyMovements(gameTime);
            }
            else
            {
                // Fallback to single Movement property for backwards compatibility
                Movement?.Move(this, gameTime);
            }

            base.Update(gameTime);
        }

        public Bullet Fire()
        {
            if (fireTimer > 0)
                return null;

            fireTimer = fireCooldown;

            Bullet bullet = new Bullet
            {
                Position = new PointF(
                    Position.X + Size.Width,
                    Position.Y + Size.Height / 2 - 5
                ),
                Size = new SizeF(10, 5)
            };

            return bullet;
        }



        /// Draw uses base implementation; override if player needs custom visuals.

        public override void Draw(Graphics g)
        {
            base.Draw(g);
        }

        public override void OnCollision(GameObject other)
        {
            if (other.IsRigidBody)
            {
                RectangleF p = Bounds;
                RectangleF o = other.Bounds;

                // Landing from top
                if (p.Bottom >= o.Top && p.Top < o.Top)
                {
                    Position = new PointF(Position.X, o.Top - Size.Height);
                    Velocity = new PointF(Velocity.X, 0);
                    HasPhysics = false;

                    // reset jump
                    foreach (var m in Movements)
                        if (m is JumpingMovement j)
                            j.ResetJump();
                }
            }
        }



    }

}