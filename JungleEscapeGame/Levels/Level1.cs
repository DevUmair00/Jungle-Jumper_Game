//using GameFrameWork.Core;
//using GameFrameWork.Entities;
//using GameFrameWork.Movements;
//using System.Collections.Generic;
//using System.Drawing;

//namespace JungleEscapeGame.Levels
//{
//    public class Level1
//    {


//Position = new PointF(0, 0);
//Position = new PointF(500, 300);
//Position = new PointF(1200, 600);




//        private List<GameObject> objects;

//        public Level1()
//        {
//            objects = new List<GameObject>();

//            CreatePlayer();
//            CreateWall();
//            CreateExit();
//        }


//        // ---------------- PLAYER ----------------
//        private void CreatePlayer()
//        {
//            Player player = new Player(

//                Properties.Resources.player,
//                new PointF(50, 50),
//                2
//            );

//            player.Size = new SizeF(32, 32);
//            player.AddMovement(new KeyboardMovement(3));

//            objects.Add(player);
//        }



//        // ---------------- WALL ----------------
//        private void CreateWall()
//        {
//            GameObject wall = new GameObject(
//                Properties.Resources.largeBox,
//                new PointF(150, 50)
//            );

//            wall.Size = new SizeF(32, 32);
//            objects.Add(wall);
//        }




//        // ---------------- EXIT ----------------
//        private void CreateExit()
//        {
//            GameObject exitDoor = new GameObject(
//                Properties.Resources.exit,
//                new PointF(300, 50)
//            );

//            exitDoor.Size = new SizeF(32, 32);
//            objects.Add(exitDoor);
//        }




//        // ---------------- UPDATE ----------------

//        public void Update(GameTime gameTime)
//        {
//            foreach (GameObject obj in objects)
//            {
//                obj.Update(gameTime);
//            }
//        }




//        // ---------------- DRAW ----------------
//        public void Draw(Graphics g)
//        {
//            foreach (GameObject obj in objects)
//            {
//                obj.Draw(g);
//            }
//        }
//    }
//}
