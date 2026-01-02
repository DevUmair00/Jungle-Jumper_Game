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


namespace GameFrameWork.Core
{

    public class Game
    {
        private List<GameObject> objects = new List<GameObject>();

        public List<GameObject> Objects => objects;

        private GameFrameWork.System.PhysicsSystem physics = new GameFrameWork.System.PhysicsSystem();
        private GameFrameWork.System.CollisionSystem collision = new GameFrameWork.System.CollisionSystem();

        /// Add a game object to the scene.
        /// Encapsulation: Game manages the collection so external code doesn't manipulate the list directly.
        public void AddObject(GameObject obj)
        {
            objects.Add(obj);
        }

        /// Update all active objects. The Game is responsible for iterating objects and orchestrating the update sequence.
        /// This separation of concerns keeps the game loop logic central and simple.



        //public void Update(GameTime gameTime)
        //{
        //    foreach (var obj in objects.Where(o => o.IsActive))
        //    {
        //        obj.Update(gameTime);
        //    }
        //}

        public void Update(GameTime gameTime)
        {
            // prepare movements / velocities
            foreach (var obj in objects.Where(o => o.IsActive))
            {
                if (obj.HasPhysics)
                {
                    // update movement inputs so Velocity is set; physics will move position
                    obj.ApplyMovements(gameTime);
                }
                else
                {
                    // non-physics objects: Update advances position by Velocity
                    obj.Update(gameTime);
                }
            }

            // move physics-driven objects (gravity, velocity)
            physics.Apply(objects);

            // detect & resolve overlaps and notify objects
            collision.Check(objects);

            // remove inactive objects
            Cleanup();
        }


        /// Draw all active objects by delegating to each object's Draw implementation (polymorphism).
        public void Draw(Graphics g)
        {
            foreach (var obj in objects.Where(o => o.IsActive))
            {
                obj.Draw(g);
            }
        }

        /// Remove objects that are no longer active; keeps the object list clean.
        public void Cleanup()
        {
            objects.RemoveAll(o => !o.IsActive);
        }
    }
}                           