using System;

namespace Practica_1
{
    public class TaxiCar : Car
    {
        private bool isOccupied;

        public TaxiCar(string licensePlate) : base(licensePlate, "Taxi")
        {
            this.isOccupied = false;
            this.Speed = 45;
        }

        // getters and setters

        public bool IsOccupied
        {
            get
            {
                return isOccupied;
            }
            set
            {
                isOccupied = value;
            }
        }

        // Methods

        public void PickUpPassenger()
        {
            if (!isOccupied)
            {
                isOccupied = true;
                Speed = 100;
                Console.WriteLine(WriteMessage("Started ride."));
            }
            else
            {
                Console.WriteLine(WriteMessage("Already occupied."));
            }
        }

        public void PickDownPassenger()
        {
            if (isOccupied)
            {
                isOccupied = false;
                Speed = 45;
                Console.WriteLine(WriteMessage("Finished ride."));
            }
            else
            {
                Console.WriteLine(WriteMessage("Not on a ride."));
            }
        }

    }
}