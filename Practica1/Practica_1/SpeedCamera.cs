using System;
using System.Collections.Generic;

namespace Practica_1 
{ 

    public class SpeedCamera : IMessageWriter
    {
        private float maxSpeed;
        private List<float> speedHistory = new List<float>();
        public SpeedCamera(float maxSpeed)
        {
            this.maxSpeed = maxSpeed;
        }

        //getters and setters
    
        public float MaxSpeed
        {
            get
            {
                return maxSpeed;
            }
            set
            {
                maxSpeed = value;
            }
        }

        public List<float> SpeedHistory
        {
            get
            {
                return speedHistory;
            }
        }

        //Methods

        public float DetectSpeed(Car car)
        {
            float speed = 0;
            speed = car.Speed;
            return speed;
        }

        public string IsCarSpeeding(Car car)
        {
            float speed = 0;
            string message = "";
            speed = DetectSpeed(car);
            speedHistory.Add(speed);
            if (speed <= maxSpeed)
            {
                message = " not";
            }
            return WriteMessage($"Car with plate: {car.LicensePlate}, with speed: {speed}KM/H, is{message} speeding.");
        }

        public string WriteMessage(string customMessage)
        {
            return $"Trigered speed camera. Result: {customMessage}";
        }
    }
}