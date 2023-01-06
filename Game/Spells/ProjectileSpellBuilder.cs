using Merlin2d.Game;
using Merlin2d.Game.Actions;

namespace Game.Spells
{
    public class ProjectileSpellBuilder : ISpellBuilder
    {
        // TODO: check functionality in lab 8
        private ProjectileSpell projectileSpell;

        public ProjectileSpellBuilder(double speed)
        {
            projectileSpell = new ProjectileSpell(speed);
        }
        public ISpellBuilder AddEffect(string effectName)
        {
            SpellEffectFactory spellEffectFactory = new SpellEffectFactory();
            IEffect effect = spellEffectFactory.Create(effectName);
            projectileSpell.AddEffect((ICommand)effect);
            return this;
        }

        public ISpell CreateSpell(IWizard wizard)
        {
            return projectileSpell;
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            projectileSpell.SetAnimation(animation);
            return this;
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            projectileSpell.SetCost(cost);
            return this;
        }
    }
}
