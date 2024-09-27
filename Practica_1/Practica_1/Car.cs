using System;

namespace Practica_1
{
    public abstract class Car : ICar, IMessageWriter
    {
        private string type;
        private string licensePlate;
        private float speed;
        public Car(string licensePlate, string type)
        {
            this.type = type;
            this.licensePlate = licensePlate;
            Console.WriteLine(WriteMessage("Created."));
        }

        //getters and setters

        public string LicensePlate
        {
            get
            {
                return licensePlate;
            }
            set
            {
                licensePlate = value;
            }
        }

        public float Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        //Methods
        public override string ToString()
        {
            return $"{type} with plate: {licensePlate}";
        }

        public string WriteMessage(string message)
        {
            return $"{ToString()}: {message}";
        }

    }
}