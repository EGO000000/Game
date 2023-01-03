using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System.ComponentModel;

namespace Game.Actors
{
    public class Door : AbstractActor
    {
        // TODO: check functionality in lab 9
        private bool isOpen = false;
        private int x;
        private int y;
        private int x1;
        private int y1;
        private Animation close_animation;
        private Animation open_animation;

        public Door(int x, int y) {
            this.close_animation = new Animation("resources/sprites/door/door.png", 32, 96);
            this.open_animation = new Animation("resources/sprites/door/door_left.png", 56, 96);
            this.SetAnimation(this.close_animation);
            this.x = x;
            this.y = y;
            this.x1 = x+32;
            this.y1 = y+96;
            //Console.Write(x+" "+y);
            this.CloseDoor();
        }

        public void OpenDoor()
        {
            for (int i = x; i <= x1; i++)
            {
                for (int j = y; j <= y1; j++)
                {
                    GetWorld().SetWall(i, j, false);
                }
            }
        }

        public void CloseDoor()
        {
            for (int i = x; i <= x; i++)
            {
                for (int j = y; j <= y; j++)
                {
                    //this.GetWorld().SetWall(12, 12, true);
                }
            }
        }

        public override void Update()
        {
            
        }
    }
}
