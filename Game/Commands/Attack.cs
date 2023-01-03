using Game.Actors;

namespace Game.Commands
{
    internal class Attack : IAction<AbstractCharacter>
    {
        AbstractCharacter actor;
        public Attack(AbstractCharacter character)
        {
            this.actor = character;
            if(this.actor == null) throw new NotImplementedException();
        }
        public void Execute(AbstractCharacter value) => value.ChangeHealth(-actor.GetDamage());
    }
}