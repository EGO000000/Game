using Game.Actors;
using Game.Actors.Enemy;
using Merlin2d.Game.Actors;

namespace Game.Factories
{
    internal class PlayerFactory : SequenceFactory
    {
        public override IActor CerateSequence(int x, int y)
        {
            IActor actor = new Player(x, y, 2);
            actor.SetName($"Player-{GetNext()}");
            actor.SetPhysics(true);

            return actor;
        }
    }
}
