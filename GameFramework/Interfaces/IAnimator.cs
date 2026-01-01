using GameFrameWork;
using GameFrameWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWork.Interfaces
{
  public interface IAnimator
    {
        GameObject Owner { get; set; }

 

        void Update(float deltaTime);

        void Destroy();
    }
}
