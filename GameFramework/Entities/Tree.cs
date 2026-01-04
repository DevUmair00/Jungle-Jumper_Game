namespace GameFrameWork.Entities
{

    public class Tree : GameObject
    {
        public Tree(PointF pos, Image treeSprite)
        {
            this.Position = pos;
            this.Sprite = treeSprite;
            this.Size = new SizeF(50, 100);
            this.IsRigidBody = true; // Prevents things from moving through it
        }

        public override void Draw(Graphics g)
        {
            // If you have a specific sprite, the base Draw is often enough.
            // Use this override only for custom environment effects.
            base.Draw(g);
        }

        //public override void OnCollision(GameObject other)
        //{
        //    // Trees usually don't deactivate like enemies.
        //    [cite_start]// You might play a "thump" sound here using your Sound System.
        //} 
    }
}