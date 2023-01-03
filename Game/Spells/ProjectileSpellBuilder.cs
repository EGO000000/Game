using Merlin2d.Game;

namespace Game.Spells
{
    public class ProjectileSpellBuilder : ISpellBuilder
    {
        // TODO: check functionality in lab 8
        private ProjectileSpell nselfSpell;

        public ProjectileSpellBuilder(double speed, int cost)
        {
            nselfSpell = new ProjectileSpell(speed, cost);
        }
        public ISpellBuilder AddEffect(string effectName)
        {
            throw new NotImplementedException();
        }

        public ISpell CreateSpell(IWizard wizard)
        {
            return nselfSpell;
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            nselfSpell.SetAnimation(animation);
            return this;
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            nselfSpell.SetCost(cost);
            return this;
        }
    }
}
