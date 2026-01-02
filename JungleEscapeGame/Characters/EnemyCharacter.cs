using GameFrameWork.Entities;
using GameFrameWork.Movements;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JungleEscapeGame.Characters
{ 
    public class EnemyCharacter : Enemy
    {
        public EnemyCharacter(Image img, PointF pos) : base(img, pos, 2)
        {
            AddMovement(new HorizantalMovement(2, 100 , 2));
            Size = new SizeF(50, 50);
        }
    }
}
