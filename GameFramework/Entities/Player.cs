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

        /// Draw uses base implementation; override if player needs custom visuals.
   
        public override void Draw(Graphics g)
        {
            base.Draw(g);
        }

        /// Collision reaction for the player. Demonstrates single responsibility: domain reaction is handled here.

        public override void OnCollision(GameObject other)
        {
            if (other is Enemy)
                Health -= 10;

            if (other is PowerUp)
                Health += 20;

            if (other.IsRigidBody)
            {
                Velocity = PointF.Empty;
            }
            base.OnCollision(other);

            //if (other.Sprite == JungleEscapeGame.Properties.Resources.exit)
            //{
            //    // level complete / handle win
            //}
        }
    }

}