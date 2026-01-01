using EZInput;
using GameFrameWork;
using GameFrameWork.Core;
using GameFrameWork.Entities;
using GameFrameWork.Movements;
using GameFrameWork.System;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JungleJumper
{
    public partial class GameForm : Form
    {
        Game game = new Game();
        float deltaTime = 0.016f;
        PhysicsSystem physics = new PhysicsSystem();
        CollisionSystem collisions = new CollisionSystem();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public GameForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Prevents flickering
            gameTimer.Interval = 16;    // ~60 Frames Per Second
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Start();
            Setting();
        }

        private void SetupPlayer()
        {
            Player hero = new Player
            {
                Position = new PointF(100, 300),
                Size = new Size(50, 50),
                Sprite = Properties.Resources.player_idle,
                HasPhysics = true  // This allows gravity to pull him down
            };

            hero.AddMovement(new KeyboardMovement(5)); // Speed of 5
            hero.AddMovement(new JumpingMovement(10)); // Jump strength of 10

            game.AddObject(hero);
        }


        private void CreateLevel1()
        {
            // Create a ground platform
            for (int i = 0; i < 10; i++)
            {
                game.AddObject(new GameObject
                {
                    Position = new PointF(i * 50, 400),
                    Size = new Size(50, 50),
                    IsRigidBody = true, // Player won't fall through this
                    Sprite = Properties.Resources.grass_tile
                });
            }
        }


        private void AddEnemy()
        {
            Enemy monster = new Enemy
            {
                Position = new PointF(400, 350),
                Size = new Size(40, 40),
                Sprite = Properties.Resources.enemy_walk
            };

            // Walk between X=300 and X=600
            monster.AddMovement(new HorizontalPatrolMovement(300, 600, 2));

            game.AddObject(monster);
        }


        private void Setting()
        {

            player = new Player(Properties.Resources.spacePlayer, new PointF(300, 300), 2);
            player.Size = new SizeF(100, 100);

            KeyboardMovement keyboardMovement = new KeyboardMovement(2);
            player.Movement = keyboardMovement;
            player.AddMovement(keyboardMovement);
            gameObjects.Add(player);

            game.AddObject(new Player
            {
                //Sprite = Resources.playersprite,
                Position = new PointF(100, 200),
                Size = new Size(100, 100),
                Movement = new KeyboardMovement()
            });

            game.AddObject(new Player
            {
                Position = new PointF(250, 100),
                Size = new Size(100, 100),
                HasPhysics = true,
                // Movement = new PatrolMovement(left: 100, right: 500)
            });

            // A physics enabled rigid player — will stop on collision and gravity will be disabled
            game.AddObject(new Player
            {
                Position = new PointF(250, 350),
                Size = new Size(40, 40),
                IsRigidBody = true
            });

            game.AddObject(new Enemy
            {
                Position = new PointF(300, 100),
                Size = new Size(50, 50),
                HasPhysics = false // Enable physics with default gravity
            });
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // 1. Move everything (Player, Enemies)
            game.Update(new GameTime(deltaTime));

            // 2. Apply Gravity/Physics
            physics.Apply(game.Objects.ToList());

            // 3. Resolve Collisions (Stop player from falling through floor)
            collisions.Check(game.Objects.ToList());

            // 4. Delete "dead" objects
            game.Cleanup();

            // 5. Refresh the screen
            Invalidate();
        }
    }
}