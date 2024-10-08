﻿namespace Practica2
{
    public class PoliceStation
    {
        private List<PoliceCar> policeCars = new List<PoliceCar>();
        private string speedingPlate = "";

        // We start the class
        public PoliceStation()
        {
        }

        // getters and setters
        public string SpeedingPlate
        {
            get { return speedingPlate; }
            set { speedingPlate = value; }
        }

        public List<PoliceCar> PoliceCars
        {
            get { return policeCars; }
            set { policeCars = value; }
        }
        // Police car registration logic
        public void AddPoliceCar(PoliceCar policeCar)
        {
            policeCars.Add(policeCar);
        }

        // Alert logic
        public void SetAlert(string speedingPlate)
        {
            this.speedingPlate = speedingPlate;
            SendPlateToPoliceCars(speedingPlate);
        }

        private void SendPlateToPoliceCars(string plate)
        {
            foreach (PoliceCar policeCar in policeCars)
            {
                if (policeCar.IsPatrolling())
                {
                    policeCar.StartPursuit(plate);
                }
            }
        }
    }
}

