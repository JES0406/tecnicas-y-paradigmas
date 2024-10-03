namespace Practica2
{
    public class PoliceStation
    {
        private List<PoliceCar> policeCars = new List<PoliceCar>();
        private bool alert = false;
        private string speedingPlate = "";

        // We start the class
        public PoliceStation()
        {
        }

        // getters and setters

        public bool SetAlert(bool alert, string speedingPlate)
        {
            this.alert = alert;
            this.speedingPlate = speedingPlate;
            SendPlateToPoliceCars(speedingPlate);
            return alert;
        }

        public string SpeedingPlate
        {
            get { return speedingPlate; }
            set { speedingPlate = value; }
        }

        public void AddPoliceCar(PoliceCar policeCar)
        {
            policeCars.Add(policeCar);
        }

        public void RegisterPoliceCar(string plate, string typeOfMeasuringDevice)
        {
            MeasuringDevice measuringDevice = null;
            if (typeOfMeasuringDevice == "SpeedRadar")
            {
                measuringDevice = new SpeedRadar();
            }
            else if (typeOfMeasuringDevice == "Breathalyser")
            {
                measuringDevice = new Breathalyser();
            }
            PoliceCar policeCar = new PoliceCar(plate);
            AddPoliceCar(policeCar);
        }
        public void SendPlateToPoliceCars(string plate)
        {
            foreach (PoliceCar policeCar in policeCars)
            {
               policeCar.StartPursuit(plate);

            }
        }
}

