using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace Game.Actors
{
    public class Player : AbstractCharacter
    {
        private double speed; // initial speed, for current speed use SpeedStrategy

        private ICharacterState state;

        public Player(int x, int y, double speed)
        {
            this.SetPosition(x, y);

            animation_run = new Animation("resources/sprites/Player/player-run.png", 32, 38);
            animation_stay = new Animation("resources/sprites/Player/player-idle.png", 32,38);
            animation_jump = new Animation("resources/sprites/Player/player-jump.png", 32, 38);
            animation_fight = new Animation("resources/sprites/Player/player-shoot.png", 32, 38);
            animation_fight_run = new Animation("resources/sprites/Player/player-run-shoot.png", 32, 38);
            this.SetAnimation(animation_stay);
            this.GetAnimation().Start();

            this.speed = speed;
            this.SetSpeedStrategy(new NormalSpeedStrategy());
            this.GetSpeed(this.speed);

            this.state = new LivingState(this, this.speed);
        }

        public override int GetDamage() => 30;

        public override void Update()
        {
            this.state.Update();
            //Console.WriteLine(this.GetHealth());
        }
    }
}
