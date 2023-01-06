using Game.Actors;

namespace Game.Spells
{
    public interface IEffect
    {
        public void SetTarget(ICharacter target);
    }
}