using DocumentFormat.OpenXml.Drawing.Charts;
using GameFrameWork.Component;
using GameFrameWork.Core;
using GameFrameWork.Entities;
using GameFrameWork.Extentions;
using GameFrameWork.Interfaces;
using GameFrameWork.Movements;
using GameFrameWork.System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GameFrameWork.Entities
{

    public class Enemy : GameObject
    {
        // Optional movement behavior: demonstrates composition and allows testable movement logic.
        public IMovement? Movement { get; set; }


        public bool IsMoving { get; set; } = false;


        // Default enemy velocity is set in constructor to give basic movement out-of-the-box.
        public Enemy()
        {
            Velocity = new PointF(-2, 0);
        }

        public Enemy(Image sprite, PointF startPos, float speed)
        {
            this.Sprite = sprite;
            this.Position = startPos;
            this.Movement = new HorizantalMovement(600,300, speed);
            this.Size = new Size(sprite.Width, sprite.Height);
        }


        private bool facingRight = true;


        /// Update will call movement behavior (if any) and then apply base update to move by velocity.
        public override void Update(GameTime gameTime)
        {
            Movement?.Move(this, gameTime); // movement must be called
            base.Update(gameTime);
        }

        /// Custom draw: demonstrates polymorphism (override base draw to provide enemy visuals).
        public override void Draw(Graphics g)
        {
            if (Sprite != null)
            {
                base.Draw(g);
            }
            else
            {
                g.FillRectangle(Brushes.Red, Bounds);
            }
        }


        /// On collision, enemy deactivates when hit by bullets (encapsulation of reaction logic inside the entity).
        public override void OnCollision(GameObject other)
        {
            if (other is Bullet)
            { 
                IsActive = false;
            }

            if (other is Player)
                other. IsActive = false;

            if (other.IsRigidBody)
            {
                Bitmap bmp = new Bitmap(this.Sprite);
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipX); // Flips horizontally
                this.Sprite = bmp;
            }

            // Ignore coins and keys completely
            if (other.Name == "Coin" || other.Name == "Key")
                return;
        }

        private void FlipSprite()
        {
            facingRight = !facingRight;

            Bitmap bmp = new Bitmap(Sprite);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Sprite = bmp;
        }

    }
}