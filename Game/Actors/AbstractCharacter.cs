using Merlin2d.Game;
using Merlin2d.Game.Actions;

namespace Game.Actors
{
    public abstract class AbstractCharacter : AbstractActor, ICharacter
    {
        private List<ICommand> activeEffects;
        private int health = 100;
        private double speed;
        private ISpeedStrategy speedStrategy;
        

        protected ActorOrientation orientation;

        public void AddEffect(ICommand effect)
        {
            this.activeEffects.Add(effect);
        }

        public void ChangeHealth(int delta)
        {
            health += delta;
            if(health >= 100) health = 100;
            if(health <= 0) health = 0;
        }

        public void Die()
        {
            throw new NotImplementedException();
        }

        public int GetHealth()
        {
            return health;
        }

        public double GetSpeed(double speed)
        {
            // TODO: get current speed based on the character's initial speed and current strategy
            this.speed = speed;
            return this.speedStrategy.GetSpeed(this.speed);
        }

        public double GetSpeed()
        {
            // TODO: get current speed based on the character's initial speed and current strategy
            return this.speedStrategy.GetSpeed(this.speed);
        }

        public void RemoveEffect(ICommand effect)
        {
            // TODO: remove effect from active effects
            // consider what happens if it is not among them
            foreach (ICommand command in this.activeEffects)
            {
                if (effect == command)
                    this.activeEffects.Remove(effect);
            }
        }
        public abstract int GetDamage();
        public ActorOrientation GetOrientation() => this.orientation;

        public void SetOrientation(ActorOrientation orientation)
        {
            this.orientation = orientation;
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            this.speedStrategy = strategy;
        }
    }
}
