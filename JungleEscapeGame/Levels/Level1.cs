using GameFrameWork.Core;
using GameFrameWork.Entities;
using JungleEscapeGame.Characters;
using System.Collections.Generic;
using System.Drawing;

namespace JungleEscapeGame.Levels
{
    public class Level1
    {
        List<GameObject> objects = new List<GameObject>();

        public Level1()
        {
            PlayerCharacter player = new PlayerCharacter(
                Properties.Resources.player,
                new PointF(200, 200)
            );

            EnemyCharacter enemy = new EnemyCharacter(
                Properties.Resources.enemy1,
                new PointF(400, 200)
            );

            objects.Add(player);
            objects.Add(enemy);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var obj in objects)
                obj.Update(gameTime);
        }

        public void Draw(Graphics g)
        {
            foreach (var obj in objects)
                obj.Draw(g);
        }
    }
}
