

namespace Practica3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Taxi taxi = Taxi.GetInstance();
            float originalSpeed = taxi.Speed;
            taxi.originalSpeed = originalSpeed;
            ObstacleFactory obstacleFactory = new();
            float debuffTimer = 0f;
            // Usar el datatime para tener un reloj
            DateTime now = DateTime.Now;
            TimeSpan delay = TimeSpan.FromMilliseconds(20);
            // Comparar el actual 
            Console.WriteLine(@"Press a key to create an obstacle: 
            A -> Police car
            S -> Construction fence
            D -> Debuff
            ");

            while (true)
            {
                if (DateTime.Now > now + delay) 
                {
                    now = DateTime.Now;
                    Obstacle? obstacle = ObstacleLogic(obstacleFactory);
                    if (obstacle != null)
                    {
                        taxi.Impact(obstacle);
                        debuffTimer = obstacle.debuffDuration;
                    }

                    debuffTimer -= 0.02f;
                    if (debuffTimer <= 0)
                    {
                        taxi.Speed = 1;
                    }
                }
            }
        }
        static Obstacle? ObstacleLogic(ObstacleFactory obstacleFactory)
        {
            ConsoleKey key = AskForObstacle();
            ObstacleType? obstacleType = BuildObstacle(key);
            Obstacle? obstacle = null;
            if (obstacleType != null)
            {
                obstacle = obstacleFactory.CreateObstacle(obstacleType.Value); // Safe by the if statement
            }
            return obstacle;
        }
        static ConsoleKey AskForObstacle()
        {

            ConsoleKey key = Console.ReadKey(true).Key;
            return key;
        }
        static ObstacleType? BuildObstacle(ConsoleKey key)
        {
            ObstacleType? obstacle = null;
            switch (key)
            {
                case ConsoleKey.A:
                    obstacle = ObstacleType.PoliceCar;
                    break;
                case ConsoleKey.S:
                    obstacle = ObstacleType.ConstructionFence; 
                    break;
                case ConsoleKey.D:
                    obstacle = ObstacleType.Debuff;
                    break;
            }
            return obstacle;            
        }
    }
}
