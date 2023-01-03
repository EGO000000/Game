namespace Game.Actors
{
    public interface IMovable
    {
        void SetSpeedStrategy(ISpeedStrategy strategy);
        double GetSpeed(double speed);
        double GetSpeed();
    }
}
