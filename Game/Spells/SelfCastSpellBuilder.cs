using Merlin2d.Game;

namespace Game.Spells
{
    public class SelfCastSpellBuilder : ISpellBuilder
    {
        // TODO: check functionality in lab 8

        private SelfCastSpell selfCastSpell;

        public SelfCastSpellBuilder()
        {
            selfCastSpell = new SelfCastSpell();
        }

        public ISpellBuilder AddEffect(string effectName)
        {
            throw new NotImplementedException();
        }

        public ISpell CreateSpell(IWizard wizard)
        {
            return selfCastSpell;
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            selfCastSpell.SetAnimation(animation);
            return this;
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            selfCastSpell.SetCost(cost);
            return this;
        }
    }
}
