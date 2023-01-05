using Game.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actions;

namespace Game.Spells
{
    public class ProjectileSpell : AbstractActor, IMovable, ISpell
    {
        // TODO: check functionality in lab 8
        private List<IEffect> effects;
        private double speed = 0.0;
        private ISpeedStrategy strategy;
        //private IJumpStrategy jumpStrategy;
        private int cost = 0;
        private Animation animation;

        public ProjectileSpell(double speed)
        {
            this.effects = new List<IEffect>();
            this.speed = speed;
        }

        public ISpell AddEffect(ICommand effect)
        {
            if (!(effect is IEffect)) throw new InvalidCastException("Not effect.");
            effects.Add((IEffect)effect);
            return this;
        }

        public void AddEffects(IEnumerable<ICommand> effects)
        {
            foreach(var effect in effects)
            {
                this.effects.Add((IEffect)effect);
            }
        }

        public void ApplyEffects(ICharacter target)
        {
            foreach (IEffect effect in effects)
            {
                //effect.SetTarget(target);
                ((ICommand)effect).Execute();
            }
        }

        public int GetCost()
        {
            return this.cost;
        }

        public double GetSpeed(double speed)
        {
            this.speed = speed;
            return this.strategy.GetSpeed(this.speed);
        }

        public double GetSpeed()
        {
            return this.strategy.GetSpeed(this.speed);
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SetAnimation(Animation animation)
        {
            this.animation = animation;
        }

        public void SetCost(int cost)
        {
            this.cost = cost;
        }

        public override void Update()
        {
            
        }
    }
}
