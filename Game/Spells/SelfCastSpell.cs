using Game.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actions;

namespace Game.Spells
{
    public class SelfCastSpell : ISpell
    {
        // TODO: check functionality in lab 8
        private List<IEffect> effects;
        private int cost = 0;
        private Animation animation;

        public SelfCastSpell()
        {
            effects = new List<IEffect>();
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
            throw new NotImplementedException();
        }

        public void SetAnimation(Animation animation)
        {
            this.animation = animation;
        }

        public void SetCost(int cost)
        {
            this.cost = cost;
        }

        public int GetCost()
        {
            return this.cost;
        }
    }
}
