

// generalizar la la factoria

namespace Practica3
{
    internal class ObstacleFactory
    {
        // Class that constructs the objects

        public ObstacleFactory() { }

        public virtual Obstacle CreateObstacle(ObstacleType obstacleType) 
        {
            switch (obstacleType) {
                case ObstacleType.PoliceCar:
                    return new PoliceCar();
                case ObstacleType.ConstructionFence:
                    return new CosntructionFence();
                case ObstacleType.Debuff:
                    return new Debuff();
                default:
                    return null;
            }
        }
    }
}
