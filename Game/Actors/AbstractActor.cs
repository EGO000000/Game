using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Game.Actors
{
    public abstract class AbstractActor : IActor
    {
        private string name;
        private int posX;
        private int posY;
        private Animation animation;
        private IWorld world;
        private bool affectedByPhysics;
        private bool toBeRemoved = false;
        protected Animation? animation_run;
        protected Animation? animation_jump;
        protected Animation? animation_stay;
        protected Animation? animation_fight;
        protected Animation? animation_fight_run;

        public AbstractActor()
        {
            name = "";
        }

        public AbstractActor(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public int GetX()
        {
            return posX;
        }

        public int GetY()
        {
            return posY;
        }

        public void SetPosition(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        public int GetHeight()
        {
            return animation.GetHeight();
        }

        public int GetWidth()
        {
            return animation.GetWidth();
        }

        public void OnAddedToWorld(IWorld world)
        {
            this.world = world;
        }

        public IWorld GetWorld()
        {
            return world;
        }

        public Animation GetAnimation()
        {
            return animation;
        }

        public void SetAnimation(Animation animation)
        {
            this.animation = animation;
        }

        public void SetAnimation(string animation)
        {
            if (animation == "fight")
            {
                this.animation = animation_fight;
            } 
            else if (animation == "fight_run")
            {
                this.animation = animation_fight_run;
            }
            else if (animation == "run")
            {
                this.animation = animation_run;
            }
            else if (animation == "jump")
            {
                this.animation = animation_jump;
            }
            else if (animation == "stay")
            {
                this.animation = animation_stay;
            }
        }

        public void SetPhysics(bool isPhysicsEnabled)
        {
            this.affectedByPhysics = isPhysicsEnabled;
        }

        public bool IsAffectedByPhysics()
        {
            return affectedByPhysics;
        }

        public bool IntersectsWithActor(IActor other)
        {
            if ((posX < other.GetX() - GetWidth()) || (posX > other.GetX() + other.GetWidth()))
            {
                return false;
            }

            if ((posY < other.GetY() - GetHeight()) || (posY > other.GetY() + other.GetHeight()))
            {
                return false;
            }
            return true;
        }

        public bool RemovedFromWorld()
        {
            return toBeRemoved;
        }

        public void RemoveFromWorld()
        {
            toBeRemoved = true;
        }

        public abstract void Update();
    }
}
