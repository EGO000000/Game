using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System.Runtime.InteropServices;

namespace Game.Actors.Button_and_door
{
    public class PressurePlate : AbstractActor, IUsable
    {
        // TODO: check functionality in lab 9
        private Animation animation;
        private Door door;
        private int frame = 1;
        private int PAUSE = 20;
        private int time = 0;
        private bool isUsed = false;
        public PressurePlate(int x, int y)
        {
            animation = new Animation("resources/sprites/level_and_button/Button.png", 20, 13);
            SetAnimation(animation);
            SetPosition(x, y);
        }

        public override void Update()
        {
            if (this.IntersectsWithActor(GetWorld().GetActors().Find(x => x.GetName() == "Player-1")) && time==0 && !isUsed)
            {
                this.GetAnimation().Start();
                time++;
            } else if(time < PAUSE && time > 0 && !isUsed)
            {
                Console.WriteLine("2");
                time++;                
                
            } else if (!isUsed && time == PAUSE)
            {
                this.isUsed = true;
                Console.WriteLine("1");
                this.GetAnimation().Stop();
                time = 0;
            }
        }

        public void SetDoor(Door door)
        {
            this.door = door;
            Console.WriteLine(111111111111);
        }

        public void Use(IActor user)
        {
            throw new NotImplementedException();
        }
    }
}
