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
        float speed = 1;
        public float originalSpeed;

        public float Speed
        {
            get { return speed; }
            set
            {
                Console.WriteLine($"Speed set to {value} from {speed}");
                speed = value;

            }
        }

        public int HealthPoints
        {
            get { return healthPoints; }
            set
            {
                Console.WriteLine($"Health points set to {value} from {healthPoints}");
                healthPoints = value;
                if ( healthPoints <= 0 )
                {
                    healthPoints = 0;
                    Console.WriteLine("The taxi has died T_T");
                }
            }
        }
        public void Impact(Obstacle obstacle)
        {
            Console.WriteLine($"Taxi impacted by {obstacle.ToString()}");
            this.HealthPoints -= obstacle.damage;
            this.Speed = this.originalSpeed*obstacle.speedMultiplier; 
        }
    }
}
