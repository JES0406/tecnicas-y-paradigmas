using System.Threading;

namespace Practica3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Taxi taxi = Taxi.GetInstance();
            ObstacleFactory obstacleFactory = new ObstacleFactory();
            List<Obstacle> obstacles = new List<Obstacle>();
            float timer = 0f;
            float debuffTimer = 0f;

            while (true)
            {
                // Logic
                // Obstacle logic
                ObstacleLogic(obstacleFactory, obstacles);

                // Taxi logic
                // If contact is done, the impact is calculated
                // Then the global timer takes into account the debuff duration
                // If the debuff duration is over, the taxi recovers its speed

                debuffTimer -= 0.02f;
                if (debuffTimer <= 0)
                {
                    taxi.Speed = 1;
                }


                // The loop executes every 20 ms
                Thread.Sleep(20);
                timer += 0.02f;
            }
        }
        static void ObstacleLogic(ObstacleFactory obstacleFactory, List<Obstacle> obstacles)
        {
            string key = AskForObstacle();
            BuildObstacle(key, obstacles, obstacleFactory);
        }
        static string AskForObstacle()
        {
            Console.WriteLine(@"Press a key to create an obstacle: 
            A -> Police car
            S -> Construction fence
            D -> Debuff
            ");

            string key = Console.ReadLine();
            return key;
        }
        static void BuildObstacle(string key, List<Obstacle> obstacles, ObstacleFactory obstacleFactory)
        {
            Obstacle obstacle = null;

            switch (key)
            {
                case "A":
                    obstacle = obstacleFactory.CreateObstacle(ObstacleType.PoliceCar);
                    break;
                case "S":
                    obstacle = obstacleFactory.CreateObstacle(ObstacleType.ConstructionFence); // Fixed typo
                    break;
                case "D":
                    obstacle = obstacleFactory.CreateObstacle(ObstacleType.Debuff); // Fixed typo
                    break;
                default:
                    break;
            }

            if (obstacle != null)
            {
                obstacles.Add(obstacle);
            }
        }
        public float Impact(Obstacle obstacle, Taxi taxi)
        {
            Console.WriteLine($"Taxi impacted by {obstacle.ToString()}");
            taxi.HealthPoints -= obstacle.damage;
            taxi.Speed *= obstacle.speedMultiplier;
            return obstacle.debuffDuration;
        }
    }
}
