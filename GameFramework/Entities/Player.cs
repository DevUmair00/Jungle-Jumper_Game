using GameFrameWork.Core;
using GameFrameWork.Entities;
using GameFrameWork.Extentions;
using GameFrameWork.Movements;

public class Player : GameObject
{

    public int MaxHealth { get; set; } = 100;
    public int Health { get; set; } = 100;
    public int Lives { get; set; } = 3; // Start with 3 lives
    public int Score { get; set; } = 0;

    public int Keys { get; set; } = 0;

    public bool ReachedExit { get; private set; }


    private float fireCooldown = 0.3f;

    private float fireTimer = 0f;




    public override void Update(GameTime gameTime)
    {
        fireTimer -= gameTime.DeltaTime;

        ApplyMovements(gameTime);
        base.Update(gameTime);
    }


    // Inside Player.cs
    public Bullet Fire()
    {
        // Check cooldown
        if (fireTimer > 0)
            return null;


        fireTimer = fireCooldown;


        Game.Audio.Play("shoot");


        // Create bullet at player's position
        return new Bullet
        {
            Name = "Bullet",
            Position = new PointF(
                Position.X + Size.Width, // Spawn at front of player
                Position.Y + (Size.Height / 2) - 5 // Center vertically
            ),
            Size = new SizeF(10, 4),
            HasPhysics = false // Bullets usually ignore gravity
        };
    }




    public void TakeDamage(int amount)
    {

        Health -= amount;

        if (Health <= 0)
        {
            Lives--;
            if (Lives > 0)
            {
                Health = MaxHealth;
                Game.Audio.Play("hit");
                this.Position = new PointF(30f, this.Position.Y);
            }
            else
            {
                Health = 0;
                Game.Audio.Play("death");
                IsActive = false; // Game Over
                Game.Audio.StopAll();
            }
        }
    }




    public override void OnCollision(GameObject other)
    {
        if (other.IsRigidBody)
            ResolveGroundCollision(other);


        if (other.Name == "Coin")
        {
            Score += 10;
            other.IsActive = false;
            Game.Audio.Play("coin");
        }

        if (other.Name == "Key")
        {
            Keys++;
            other.IsActive = false;
            Game.Audio.Play("key");
        }

        if (other.Name == "Exit")
        {
            ReachedExit = true; // SIGNAL ONLY
            Game.Audio.StopAll();
        }
    }



    private void ResolveGroundCollision(GameObject other)
    {
        RectangleF p = Bounds;
        RectangleF o = other.Bounds;

        if (p.Bottom >= o.Top && p.Top < o.Top)
        {
            Position = new PointF(Position.X, o.Top - Size.Height);
            Velocity = new PointF(Velocity.X, 0);
            HasPhysics = false;

            foreach (var m in Movements)
                if (m is JumpingMovement j)
                    j.ResetJump();
        }
    }
}
