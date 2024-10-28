using System.Threading;
using System.Timers;

namespace Practica3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Taxi taxi = Taxi.GetInstance();
            float originalSpeed = taxi.Speed;
            ObstacleFactory obstacleFactory = new ObstacleFactory();
            float timer = 0f;
            float debuffTimer = 0f;
            // Usar el datatime para tener un reloj
            // Comparar el actual 
            Console.WriteLine(@"Press a key to create an obstacle: 
            A -> Police car
            S -> Construction fence
            D -> Debuff
            ");

            while (true)
            {
                // Logic
                // Obstacle logic
                Obstacle? obstacle = ObstacleLogic(obstacleFactory);
                if (obstacle != null)
                {
                    taxi.Impact(obstacle);
                }

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
