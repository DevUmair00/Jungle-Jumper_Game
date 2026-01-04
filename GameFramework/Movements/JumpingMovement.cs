using EZInput;
using GameFrameWork.Core;
using GameFrameWork.Entities;
using GameFrameWork.Interfaces;

namespace GameFrameWork.Movements
{
    public class JumpingMovement : IMovement
    {
        private float jumpForce;
        private bool canJump = true;

        public JumpingMovement(float jumpForce)
        {
            this.jumpForce = jumpForce;
        }

        public void Move(GameObject obj, GameTime gameTime)
        {
            if (Keyboard.IsKeyPressed(Key.UpArrow) && canJump)
            {
                obj.Velocity = new PointF(obj.Velocity.X, -jumpForce);
                obj.HasPhysics = true;   // gravity ON
                canJump = false;         // prevent double jump
                Game.Audio.Play("jump");
            }
        }

        // Called when player lands on floor
        public void ResetJump()
        {
            canJump = true;
        }
    }
}
