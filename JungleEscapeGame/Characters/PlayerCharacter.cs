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
    public class PlayerCharacter : Player
    {
        public PlayerCharacter(Image img, PointF pos): base(img, pos, 2)
        {
            AddMovement(new KeyboardMovement(3));
            Size = new SizeF(50, 50);
        }
    }
}
