using Merlin2d.Game.Actors;

namespace Game.Factories
{
    public abstract class SequenceFactory
    {
        private static int Num;
        protected static int GetNext() => ++Num;

        public abstract IActor CerateSequence(int x, int y);
    }
}
