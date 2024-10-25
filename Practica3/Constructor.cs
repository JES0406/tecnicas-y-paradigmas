﻿

namespace Practica3
{
    internal class ObstacleFactory: Singleton<ObstacleFactory>
    {
        // Class that constructs the objects
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
