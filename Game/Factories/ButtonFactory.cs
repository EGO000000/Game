using Game.Actors;
using Game.Actors.Button_and_door;
using Game.Actors.Enemy;
using Merlin2d.Game.Actors;

namespace Game.Factories
{
    internal class ButtonFactory : SequenceFactory
    {
        public override IActor CerateSequence(int x, int y)
        {
            IActor actor = new PressurePlate(x, y);
            actor.SetName($"Button-{GetNext()}");
            actor.SetPhysics(true);

            return actor;
        }
    }
}
