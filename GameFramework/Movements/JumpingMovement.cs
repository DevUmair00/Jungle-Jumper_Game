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
using EZInput;


namespace GameFrameWork.Movements
{
    public class JumpingMovement : IMovement
    {

        public float jumpForce;
        public float gravity;
        public float groundY;
        public float verticalVelocity = 0;
        public bool isJumping = false;

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


