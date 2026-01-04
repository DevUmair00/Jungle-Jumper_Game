using GameFrameWork.Core;
using GameFrameWork.Extentions;
using GameFrameWork.Interfaces;
using GameFrameWork.Movements;

namespace GameFrameWork.Entities
{

    public class Enemy : GameObject
    {
        // Optional movement behavior: demonstrates composition and allows testable movement logic.
        public IMovement? Movement { get; set; }


        public bool IsMoving { get; set; } = false;

        public int Health = 3;


        // Default enemy velocity is set in constructor to give basic movement out-of-the-box.
        public Enemy()
        {
            Velocity = new PointF(-2, 0);
        }

        public Enemy(Image sprite, PointF startPos, float speed)
        {
            this.Sprite = sprite;
            this.Position = startPos;
            this.Movement = new HorizantalMovement(600, 300, speed);
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



        public override void OnCollision(GameObject other)
        {
            // Bullet hits enemy
            if (other is Bullet)
            {
                other.IsActive = false;
                Game.Audio.Play("hit");
                IsActive = false;
            }


            // ========= Enemy ↔ Player =========
            if (other is Player player)
            {
                player.TakeDamage(10);
                Game.Audio.Play("hit");
                ReverseDirection();
                return;
            }

            // ========= Enemy ↔ Enemy =========
            if (other is Enemy)
            {
                ReverseDirection();
                return;
            }

            // ========= Enemy ↔ Floor =========
            if (other.Name == "Floor")
            {
                ResolveGroundCollision(other);
                return;
            }

            // ========= Enemy ↔ Wall / Box / Platform =========
            if (other.Name == "Wall")
            {
                ReverseDirection();
            }

        }




        private void ReverseDirection()
        {
            if (Movement is PatrolMovement patrol)
                patrol.Reverse();

            Velocity = new PointF(-Velocity.X, Velocity.Y);
            FlipSprite();
        }


        private void ResolveGroundCollision(GameObject other)
        {
            RectangleF e = Bounds;
            RectangleF o = other.Bounds;

            if (e.Bottom >= o.Top && e.Top < o.Top)
            {
                Position = new PointF(Position.X, o.Top - Size.Height);
                Velocity = new PointF(Velocity.X, 0);
                HasPhysics = false;
            }
        }

        private void FlipSprite()
        {
            if (Sprite == null) return;

            Bitmap bmp = new Bitmap(Sprite);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Sprite = bmp;
        }


    }
}