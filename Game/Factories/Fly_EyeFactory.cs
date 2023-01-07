using Game.Actors.Enemy;
using Merlin2d.Game.Actors;

namespace Game.Factories
{
    internal class Fly_EyeFactory : SequenceFactory
    {
        public override IActor CerateSequence(int x, int y)
        {
            IActor actor = new Fly_Eye(x, y, 2);
            actor.SetName($"Fly_Eye-{GetNext()}");
            actor.SetPhysics(true);

            return actor;
        }
    }
}
