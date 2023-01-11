using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System.ComponentModel;

namespace Game.Actors.Button_and_door
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

        public Door(int x, int y)
        {
            close_animation = new Animation("resources/sprites/door/door.png", 32, 96);
            open_animation = new Animation("resources/sprites/door/door_left.png", 56, 96);
            SetAnimation(close_animation);
            SetPosition(x, y);
            this.x = x;//изменить при интеграции на карту
            this.y = y;//изменить при интеграции на карту
            this.x1 = this.x + 10;
            this.y1 = this.y + 10;
            //Console.Write(x+" "+y);
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
            for (int i = x; i <= x1; i++)
            {
                for (int j = y; j <= y1; j++)
                {
                    GetWorld().SetWall(i / 16, j / 16, true);
                }
            }
        }

        public override void Update()
        {
            if (IntersectsWithActor(GetWorld().GetActors().Find(x => x.GetName() == "Player-1"), "1") != null)
                CloseDoor();
        }
    }
}
