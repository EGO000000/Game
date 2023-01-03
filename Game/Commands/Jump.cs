using Game.Actors;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace Game.Commands
{
    public class Jump : IAction<AbstractCharacter>
    {
        public void Execute(AbstractCharacter player)
        {
            int oldY = player.GetY();
            int newY = (int)(oldY - player.GetSpeed() * 2);

            player.SetPosition(player.GetX(), newY);

            if (player.GetWorld().IntersectWithWall(player))
                player.SetPosition(player.GetX(), oldY);
        }
    }
}
