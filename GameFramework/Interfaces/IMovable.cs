using System.Drawing;

namespace GameFrameWork.Interfaces
{
    public interface IMovable
    {
        // Velocity of the object
        PointF Velocity { get; set; }
    }
}