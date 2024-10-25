using System;

namespace Practica_1
{
    public class PoliceCar : Car
    {
        private bool patrolling;
        private SpeedCamera speedCamera;
        public PoliceCar(string licensePlate) : base(licensePlate, "Police")
        {
            this.speedCamera = new SpeedCamera(50);

        }

        //getters and setters

        public bool Patrolling
        {
            get
            {
                return this.patrolling;
            }
            set
            {
                if (value)
                {
                    if (!this.patrolling)
                    {
                        Console.WriteLine(WriteMessage("Started patrolling."));
                        this.patrolling = value;
                    }
                    else
                    {
                        Console.WriteLine(WriteMessage("Already patrolling."));
                    }
                }
                else
                {
                    Console.WriteLine(WriteMessage("Stopped patrolling."));
                    this.patrolling = value;

                }
            }
        }

        //Methods

        public void ShootRadar(Car car)
        {
            if (patrolling)
            {
                Console.WriteLine(WriteMessage(speedCamera.IsCarSpeeding(car)));
            }
            else
            {
                Console.WriteLine(WriteMessage("Speed camera did not shoot, police car is not patrolling."));
            }
        }

        public void MakeReport()
        {
            Console.WriteLine(WriteMessage("Report speed camera history:"));
            for (int i = 0; i < speedCamera.SpeedHistory.Count; i++)
            {
                Console.WriteLine(speedCamera.SpeedHistory[i]);
            }
        }
    }
}
