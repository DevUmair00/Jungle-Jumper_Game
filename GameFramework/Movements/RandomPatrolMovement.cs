using GameFrameWork.Core;
using GameFrameWork.Entities;
using GameFrameWork.Interfaces;
using System.Drawing;
using System;

namespace GameFrameWork.Movements
{
    public class RandomPatrolMovement : IMovement
    {
        private float speedX;
        private float speedY;
        private float baseSpeed;

        private float minX, maxX, minY, maxY;

        private Random rand = new Random();
        private float changeTime = 0;
        private float changeInterval = 60; // Changes direction roughly every 60 frames

        public RandomPatrolMovement(float minX, float maxX, float minY, float maxY, float speed)
        {
            this.minX = minX;
            this.maxX = maxX;   
            this.minY = minY;
            this.maxY = maxY;
            this.baseSpeed = speed;

            // Initialize with the starting speed
            speedX = speed;
            speedY = speed;
        }

        public void Move(GameObject obj, GameTime gameTime)
        {
            // 1. Move the object using DeltaTime (makes movement consistent across different PCs)
            // Multiply by 60 to keep your 'speed' value feeling natural
            obj.Position = new PointF(
                obj.Position.X + (speedX * 60 * gameTime.DeltaTime),
                obj.Position.Y + (speedY * 60 * gameTime.DeltaTime)
            );

            // 2. Handle Direction Changing
            changeTime++;
            if (changeTime >= changeInterval)
            {
                // Logic to pick a random direction (-1 or 1) and multiply by baseSpeed
                // This ensures the enemy NEVER stops (speed is never 0)
                speedX = (rand.Next(0, 2) == 0 ? -1 : 1) * baseSpeed;
                speedY = (rand.Next(0, 2) == 0 ? -1 : 1) * baseSpeed;

                changeTime = 0;
            }

            // 3. Robust Boundary Checking
            // Horizontal Boundaries
            if (obj.Position.X < minX)
            {
                obj.Position = new PointF(minX, obj.Position.Y);
                speedX = Math.Abs(speedX); // Force direction to the Right
            }
            else if (obj.Position.X > maxX)
            {
                obj.Position = new PointF(maxX, obj.Position.Y);
                speedX = -Math.Abs(speedX); // Force direction to the Left
            }

            // Vertical Boundaries
            if (obj.Position.Y < minY)
            {
                obj.Position = new PointF(obj.Position.X, minY);
                speedY = Math.Abs(speedY); // Force direction Down
            }
            else if (obj.Position.Y > maxY)
            {
                obj.Position = new PointF(obj.Position.X, maxY);
                speedY = -Math.Abs(speedY); // Force direction Up
            }
        }
    }
}