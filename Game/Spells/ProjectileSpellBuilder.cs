using Merlin2d.Game;

namespace Game.Spells
{
    public class ProjectileSpellBuilder : ISpellBuilder
    {
        // TODO: check functionality in lab 8
        private List<string> _effects;
        private Animation _animation;
        private int _cost;
        
        public ProjectileSpellBuilder()
        {

        }
        public ISpellBuilder AddEffect(string effectName)
        {
            throw new NotImplementedException();
        }

        public ISpell CreateSpell(IWizard wizard)
        {
            throw new NotImplementedException();
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            throw new NotImplementedException();
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            throw new NotImplementedException();
        }
    }
}
