using Game.Spells;
using Merlin2d.Game;

namespace Lab912.Spells
{
    public class SpellDirector : ISpellDirector
    {
        private Dictionary<string, int> costs = SpellDataProvider.GetInstance().GetSpellEffects();
        private Dictionary<string, SpellInfo> effects = SpellDataProvider.GetInstance().GetSpellInfo();
        private IWizard wizard;
        public SpellDirector(IWizard wizard)
        {
            this.wizard = wizard;
        }

        public ISpell Build(string spellName)
        {
            ISpell spell;
            if (effects[spellName].SpellType == SpellType.SelfCastSpell)
            {
                SelfCastSpellBuilder builder = new SelfCastSpellBuilder();

                builder.SetSpellCost(costs[spellName]);

                foreach (string effectName in effects[spellName].EffectNames)
                {
                    builder.AddEffect(effectName);
                }

                // Effect apllied when player activated a booster.
                spell = builder.CreateSpell(wizard);
            }
            else
            {
                ProjectileSpellBuilder builder = new ProjectileSpellBuilder(2);
                builder.SetSpellCost(costs[spellName]);

                foreach (string effectName in effects[spellName].EffectNames)
                {
                    builder.AddEffect(effectName);
                }

                Animation animation = new Animation(effects[spellName].AnimationPath, effects[spellName].AnimationWidth, effects[spellName].AnimationHeight);

                spell = builder.SetAnimation(animation).CreateSpell(wizard);
            }

            return spell;
        }
    }
}
