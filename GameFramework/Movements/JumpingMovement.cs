using GameFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GameFrameWork.Interfaces;
using GameFrameWork.Entities;
using EZInput;


namespace GameFramework.Movements
{
    internal class JumpingMovement : IMovement
    {

        private float jumpForce;
        private float gravity;
        private float groundY;
        private float verticalVelocity = 0;
        private bool isJumping = false;

        public JumpingMovement(float jumpForce, float gravity, float groundY)
        {
            this.jumpForce = jumpForce;
            this.gravity = gravity;
            this.groundY = groundY;
        }

        public void Move(GameObject obj, GameTime gameTime)
        {
            // 1. Listen for Input: If Space is pressed and we aren't already jumping
            if (Keyboard.IsKeyPressed(Key.UpArrow) && !isJumping)
            {
                verticalVelocity = -jumpForce; 
                isJumping = true;
            }

            // 2. Physics Logic: If we are in the air, apply gravity
            if (isJumping)
            {
                // Increase velocity by gravity over time
                verticalVelocity += gravity;

                // Update the object's position
                obj.Position = new PointF(
                    obj.Position.X,
                    obj.Position.Y + verticalVelocity
                );

                // 3. Collision Detection (Simple Ground Check)
                if (obj.Position.Y >= groundY)
                {
                    obj.Position = new PointF(obj.Position.X, groundY); // Snap to floor
                    verticalVelocity = 0;
                    isJumping = false; // We landed!
                }
            }
        }
    }
}


