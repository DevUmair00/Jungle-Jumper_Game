using GameFrameWork.Component;
using GameFrameWork.Entities;
using GameFrameWork.Interfaces;


namespace GameFrameWork.Core
{

    public class Game
    {
        private List<GameObject> objects = new List<GameObject>();

        public List<GameObject> Objects => objects;

        private GameFrameWork.System.PhysicsSystem physics = new GameFrameWork.System.PhysicsSystem();
        private GameFrameWork.System.CollisionSystem collision = new GameFrameWork.System.CollisionSystem();


        public static IAudio Audio { get; private set; }

        public Game()
        {
            Audio = new Audio();
            LoadSounds();
            Game.Audio.SetVolume("music", 0.3f);
            Game.Audio.SetVolume("shoot", 0.8f);
        }

        private void LoadSounds()
        {
            Audio.AddSound(new AudioTrack("coin", @"Audio\coinPickup.wav", false));
            Audio.AddSound(new AudioTrack("key", @"Audio\keyPickup.wav", false));
            Audio.AddSound(new AudioTrack("hit", @"Audio\hit.wav", false));
            Audio.AddSound(new AudioTrack("death", @"Audio\Boom.wav", false));
            Audio.AddSound(new AudioTrack("shoot", @"Audio\shoot.wav", false));
            Audio.AddSound(new AudioTrack("jump", @"Audio\jump.wav", false));

            Audio.AddSound(new AudioTrack("level1_music", @"Audio\Level1_music.mp3", true));
            Audio.AddSound(new AudioTrack("level2_music", @"Audio\Level2_music.mp3", true));
            Audio.AddSound(new AudioTrack("menu_music", @"Audio\menu_Music.mp3", true));
        }




        /// Add a game object to the scene.
        /// Encapsulation: Game manages the collection so external code doesn't manipulate the list directly.
        public void AddObject(GameObject obj)
        {
            objects.Add(obj);
        }


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