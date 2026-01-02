using EZInput;
using GameFrameWork;
using GameFrameWork.Core;
using GameFrameWork.Entities;
using GameFrameWork.Movements;
using GameFrameWork.System;
using JungleJumper.Properties;
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

        string player_assetPath = Application.StartupPath + "\\Assets\\Player\\";

        public GameForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Prevents flickering
            timer.Interval = 16; // ~60 FPS
            timer.Tick += gameTimer_Tick;
            timer.Start();
            SetupPlayer();
        }

        private void SetupPlayer()
        {

            var hero = new Player
            {
                Position = new PointF(100, 300),
                Size = new Size(50, 50),
                Sprite = Image.FromFile(player_assetPath + "player_Idle.gif"),
                HasPhysics = true,
                IsRigidBody = true

            };

            // add as many movement behaviours as you need
            hero.AddMovement(new KeyboardMovement());        // horizontal input
            hero.AddMovement(new JumpingMovement(10f, 0.5f, 30f)); // jump logic

            game.AddObject(hero);



            game.AddObject(new Player
            {
                Position = new PointF(250, 100),
                Size = new Size(100, 100),
                HasPhysics = true,
                 Movement = new PatrolMovement(left: 100, right: 500),
                IsRigidBody = true
            });
        }


        //private void CreateLevel1()
        //{
        //    // Create a ground platform
        //    for (int i = 0; i < 10; i++)
        //    {
        //        game.AddObject(new GameObject
        //        {
        //            Position = new PointF(i * 50, 400),
        //            Size = new Size(50, 50),
        //            IsRigidBody = true, // Player won't fall through this
        //            Sprite = Properties.Resources.grass_tile
        //        });
        //    }
        //}


        //private void AddEnemy()
        //{
        //    Enemy monster = new Enemy
        //    {
        //        Position = new PointF(400, 350),
        //        Size = new Size(40, 40),
        //        Sprite = Properties.Resources.enemy_walk
        //    };

        //    // Walk between X=300 and X=600
        //    monster.AddMovement(new HorizantalMovement(300, 600, 2));

        //    game.AddObject(monster);
        //}

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                game.Update(new GameTime(deltaTime));
                physics.Apply(game.Objects.ToList());
                collisions.Check(game.Objects.ToList());

                // Restrict player movement within boundaries
                foreach (var obj in game.Objects)
                {
                    if (obj is Player player)
                    {
                        // Define boundaries
                        float minX =0;
                        float maxX = this.ClientSize.Width - player.Size.Width;
                        float minY =0;
                        float maxY = this.ClientSize.Height - player.Size.Height;

                        // Clamp player's position within boundaries
                        player.Position = new PointF(
                            Math.Clamp(player.Position.X, minX, maxX),
                            Math.Clamp(player.Position.Y, minY, maxY)
                        );
                    }
                }

                game.Cleanup();
                Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            // This tells your engine to draw the sprites on the screen
            game.Draw(e.Graphics);
        }

    }
}