using GameFrameWork.Entities;

namespace GameFrameWork.Interfaces
{
    public interface IAnimator
    {
        GameObject Owner { get; set; }



        void Update(float deltaTime);

        void Destroy();
    }
}
