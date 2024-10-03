namespace Practica2
{
    public class PoliceCar : VehicleWithPlate
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car"; 
        private bool isPatrolling;
        private MeasuringDevice measuringDevice;
        private bool pursuing = false;

        public PoliceCar(string plate, MeasuringDevice measuringDevice = null) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            this.measuringDevice = measuringDevice; // radar can be NULL
        }

        public void UseRadar(Vehicle vehicle)
        {
            if (checkDevice())
            { 
                Console.WriteLine(WriteMessage("No radar available."));
                return;
            }
            if (isPatrolling)
                {
                if (vehicle is VehicleWithPlate vehicleWithPlate)
                    {
                        measuringDevice.Trigger(vehicleWithPlate);
                        string meassurement = measuringDevice.GetLastReading();
                        Console.WriteLine(WriteMessage($"Triggered measuring device. Result: {meassurement}"));
                        if (meassurement.Contains("Catched"))
                        {
                            StartPursuit(vehicleWithPlate.GetPlate());
                        }
                    }
                else
                {
                    Console.WriteLine(WriteMessage("tried to scan a vehicle with no plate."));
                }
            }
                else
                {
                    Console.WriteLine(WriteMessage($"has no active device."));
                }
        }

        private bool checkDevice()
        {
            if (measuringDevice == null)
            {
                Console.WriteLine(WriteMessage("has no device."));
                return false;
            }
            return true;
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintHistory()

        {
            if (!checkDevice())
            {
                Console.WriteLine(WriteMessage("No device available."));
                return;
            }
            Console.WriteLine(WriteMessage("Report radar speed history:"));
            foreach (float speed in measuringDevice.history)
            {
                Console.WriteLine(speed);
            }
        }

        public void StartPursuit(string plate)
        {
            pursuing = true;
            Console.WriteLine(WriteMessage($"started pursuit of {plate}."));
        }
    }
}