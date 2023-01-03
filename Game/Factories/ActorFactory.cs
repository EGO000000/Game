using Game.Actors;
using Game.Actors.Enemy;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Game.Factories
{
    public class ActorFactory : IFactory
    {
        public IActor Create(string actorType, string actorName, int x, int y)
        {
            IActor actor = null;

            if (actorType == "Player")
            {
                actor = new Player(x, y, 2);
                actor.SetName(actorName);
                actor.SetPhysics(true);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Fly_Eye")
            {
                actor = new Fly_Eye(x, y, 2);
                actor.SetName(actorName);
                actor.SetPhysics(true);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Door")
            {
                actor = new Door(x,y);
                actor.SetName(actorName);
                actor.SetPhysics(true);
                actor.SetPosition(x, y);
                
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

            return actor;
        }
    }
}
