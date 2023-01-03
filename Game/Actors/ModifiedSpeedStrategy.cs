namespace Game.Actors
{
    public class ModifiedSpeedStrategy : ISpeedStrategy
    {
        public double GetSpeed(double speed)
        {
            return 0.8 * speed;
        }
    }
}
