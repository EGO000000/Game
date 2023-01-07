namespace Game.Actors
{
    public class QuickSpeedStrategy : ISpeedStrategy
    {
        public double GetSpeed(double speed)
        {
            return 2 * speed;
        }
    }
}
