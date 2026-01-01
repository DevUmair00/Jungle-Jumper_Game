using EZInput;
using GameFramework.Movements;
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
        System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();
        string player_assetPath = Application.StartupPath + "\\Assets\\Player\\";

        public GameForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Prevents flickering
            gameTimer.Interval = 16;    // ~60 Frames Per Second
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Start();
            SetupPlayer();
        }

        private void SetupPlayer()
        {
            Player hero = new Player
            {
                Sprite = Image.FromFile(player_assetPath + "player_Idle.gif"),
                Position = new PointF(100, 300),
                Size = new Size(50, 50),
                HasPhysics = true  // This allows gravity to pull him down
            };

            hero.AddMovement(new KeyboardMovement(5)); // Speed of 5
            hero.AddMovement(new JumpingMovement(10f, 0.5f, 350f));
            
            game.AddObject(hero);
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

        protected override void OnPaint(PaintEventArgs e)
        {
            // This tells your engine to draw the sprites on the screen
            game.Draw(e.Graphics);
        }

    }
}