using GameFrameWork.Core;
using GameFrameWork.Entities;
using GameFrameWork.Movements;
using System.Drawing;

namespace JungleEscapeGame.Levels
{
    public class Level1
    {
        public Player Player { get; private set; }

        public void Load(Game game)
        {
            // PLAYER
            Player = new Player
            {
                Position = new PointF(100, 300),
                Size = new SizeF(40, 40),
                Sprite = Properties.Resources.player,
                HasPhysics = true
            };
            Player.AddMovement(new KeyboardMovement(4));
            Player.AddMovement(new JumpingMovement(12f));
            game.AddObject(Player);

            // FLOOR
            game.AddObject(new GameObject
            {
                Position = new PointF(-100, 360),
                Size = new SizeF(1600, 40),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });

            // WALL
            game.AddObject(new GameObject
            {
                Position = new PointF(300, 296),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.largeBox,
                IsRigidBody = true
            });

            // EXIT
            game.AddObject(new GameObject
            {
                Position = new PointF(1500, 296),
                Size = new SizeF(64, 64),
                Sprite = Properties.Resources.exit
            });
        }
    }
}
