using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3
{
    public class Taxi : Singleton<Taxi>
    {
        int healthPoints = 100;
        int lastHealthPoints;
        float speed = 1;
        float lastSpeed;

        public float Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                Console.WriteLine($"Speed set to {value} from {lastSpeed}");
                lastSpeed = value;
            }
        }

        public int HealthPoints
        {
            get { return healthPoints; }
            set
            {
                Console.WriteLine($"Health points set to {value} from {lastHealthPoints}");
                healthPoints = value;
                lastHealthPoints = value;
            }
        }
    }
}
