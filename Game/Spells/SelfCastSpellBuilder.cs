using Merlin2d.Game;
using Merlin2d.Game.Actions;

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
            SpellEffectFactory spellEffectFactory = new SpellEffectFactory();
            IEffect effect = spellEffectFactory.Create(effectName);
            selfCastSpell.AddEffect((ICommand)effect);
            return this;
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
