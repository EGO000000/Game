using Game.Actors;
using Merlin2d.Game.Actions;

namespace Game.Spells
{
    public class Effect: IEffect, ICommand
    {
        private ICharacter target;
        private int number_of_iterations;
        public Effect() { }

        public void Execute()
        {
            
        }

        public void SetTarget(ICharacter target)
        {
            if(target != null) this.target = target;
        }
    }
}
