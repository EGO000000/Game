using Game.Commands;
using Merlin2d.Game; 

namespace Game.Actors.Enemy
{
    public class Fly_Eye : AbstractCharacter
    {
        private Animation animation;
        private Attack attack;

        private double speed; // initial speed, for current speed use SpeedStrategy
        private Move moveRight;
        private Move moveLeft;
        Random random = new Random();
        private int timer = 60;
        private int pause = 125;
        private int damege_pause = 60;
        private int damege_timer = 0;
        private int x;
        private int y = 30;
        private int z = 0;
        private Move lastmove;

        public Fly_Eye(int x, int y, double speed)
        {
            //this.SetPosition(x, y);

            animation = new Animation("resources/sprites/enemy/fly-eye.png", 48, 48);
            SetAnimation(animation);
            GetAnimation().Start();
            attack = new(this);
            this.speed = speed;
            moveRight = new Move(this, 1, 0);
            moveLeft = new Move(this, -1, 0);
            lastmove = moveRight;
            //GetAnimation().FlipAnimation();
            SetSpeedStrategy(new NormalSpeedStrategy());
            GetSpeed(this.speed);
            SetPosition(x, y);            
        }

        public override int GetDamage()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            if (timer == 60)
            {
                x = random.Next(1, 3);
                GetAnimation().FlipAnimation();

            }
            if (IntersectsWithActor(GetWorld().GetActors().Find(x => x.GetName() == "Merlin")) && damege_timer == 0)
            {
                //Console.WriteLine(GetWorld().GetActors().Find(x => x.GetName() == "Merlin"));
                attack.Execute((AbstractCharacter)GetWorld().GetActors().Find(x => x.GetName() == "Merlin"));
                damege_timer++;
            }
            else if (damege_timer > 0 && damege_timer <= damege_pause)
            {
                damege_timer++;
            }
            else
            {
                damege_timer = 0;
            }
            timer++;
            if (timer >= 120)
            {
                if (lastmove == moveRight)
                {
                    if (timer == pause && z != x * y)
                    {
                        moveRight.Execute();
                        pause += 5;
                        z++;
                        GetAnimation().Start();
                    }
                    if (z == x * y)
                    {
                        z = 0;
                        lastmove = moveLeft;
                        timer = 60;
                        pause = 125;
                    }
                }
                else
                {
                    if (timer == pause && z != x * y)
                    {
                        moveLeft.Execute();
                        pause += 5;
                        z++;
                        GetAnimation().Start();
                    }
                    if (z == x * y)
                    {
                        z = 0;
                        lastmove = moveRight;
                        timer = 60;
                        pause = 125;
                    }
                }
            }
            else
            {
                GetAnimation().Stop();
            }
        }
    }
}
