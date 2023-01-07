using Game.Actors;
using Game.Actors.Enemy;
using Merlin2d.Game.Actors;

namespace Game.Factories
{
    internal class DoorFactory : SequenceFactory
    {
        public override IActor CerateSequence(int x, int y)
        {
            IActor actor = new Door(x, y);
            actor.SetName($"Door-{GetNext()}");
            actor.SetPhysics(true);

            return actor;
        }
    }
}
