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

namespace GameFrameWork.Extentions
{

    public class PowerUp : GameObject
    {
        // PowerUps don't move, so Update is intentionally empty (single responsibility: provide pickup behavior)
        public override void Update(GameTime gameTime) { }

        /// PowerUp draws as a green ellipse — demonstrates polymorphic drawing.
        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Green, Bounds);
        }

        /// When a player collides, apply the effect and deactivate. Encapsulates pickup logic here.
        public override void OnCollision(GameObject other)
        {
            if (other is Player player)
            {
                player.Health += 20;
                IsActive = false;
            }
        }
    }
}