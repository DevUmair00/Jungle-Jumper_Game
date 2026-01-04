using GameFrameWork.Core;
using GameFrameWork.Entities;

namespace GameFrameWork.Interfaces
{
    public interface IMovement
    {
        void Move(GameObject obj, GameTime gameTime);
    }
}
