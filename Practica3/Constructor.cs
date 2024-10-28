

// generalizar la la factoria

namespace Practica3
{
    internal class ObstacleFactory
    {
        public ObstacleFactory() { }

        public virtual Obstacle CreateObstacle(ObstacleType obstacleType)
        {
            string className = obstacleType.ToString();
            Type obstacleTypeClass = Type.GetType(className);

            if (obstacleTypeClass == null)
            {
                Console.WriteLine($"Class for {className} not found.");
                return null;
            }

            // Use reflection to create an instance of the type
            return Activator.CreateInstance(obstacleTypeClass) as Obstacle;
        }
    }

}
