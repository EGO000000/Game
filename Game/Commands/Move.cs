using Game.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace Game.Commands
{
    public class Move : ICommand
    {
        private AbstractCharacter actor;
        //private double step;
        private int dx;
        private int dy;

        public Move(AbstractCharacter movable, int dx, int dy)
        {
            if (!(movable is AbstractCharacter))
            {
                throw new ArgumentException("Can only move actors");
            }
            else
            {
                this.actor = movable;
                //this.step = step;
                this.dx = dx;
                this.dy = dy;
            }
            
        }
        public void Execute()
        {
            // TODO: should work with float values - lab 8
            int oldX = this.actor.GetX();
            int oldY = this.actor.GetY();
            int newX = this.actor.GetX() +  (int)this.actor.GetSpeed() * dx;
            int newY = this.actor.GetY() + (int)this.actor.GetSpeed() * dy;

            this.actor.SetPosition(newX, newY);

            if (this.actor.GetWorld().IntersectWithWall(this.actor))
                this.actor.SetPosition(oldX, oldY);
        }
    }
}
