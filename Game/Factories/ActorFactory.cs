using Game.Actors;
using Game.Actors.Enemy;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Game.Factories
{
    public class ActorFactory : IFactory
    {
        readonly Fly_EyeFactory fly_EyeFactory = new Fly_EyeFactory();
        readonly PlayerFactory playerFactory = new PlayerFactory();
        readonly DoorFactory doorFactory = new DoorFactory();

        public IActor Create(string actorType, string actorName, int x, int y)
        {

            if (actorType == "Player")
            {
                return playerFactory.CerateSequence(x, y);
            }
            else if (actorType == "Fly_Eye")
            {
                return fly_EyeFactory.CerateSequence(x, y);
            }
            else if (actorType == "Door")
            {
                return doorFactory.CerateSequence(x, y);
                
            }
            /*else if (actorType == "Door")
            {
                actor = new Switch();
                actor.SetName(actorName);
                //actor.SetPhysics(true);
                actor.SetPosition(x+1, y);
            }*/
            /*else if (...) {
                // TODO: add support for loading other actor types from map
            }*/
            else
            {
                throw new ArgumentException("Unknown type");
            }
        }
    }
}
