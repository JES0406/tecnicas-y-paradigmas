namespace Practica2
{
    public class PoliceCar : VehicleWithPlate
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car"; 
        private bool isPatrolling;
        private MeasuringDevice measuringDevice;
        private bool pursuing = false;
        private PoliceStation baseStation;

        public PoliceCar(string plate, PoliceStation baseStation, MeasuringDevice measuringDevice = null) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            this.baseStation = baseStation;
            this.measuringDevice = measuringDevice; // radar can be NULL
        }

        // Patrolling logic

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("Started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("Is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("Stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("Was not patrolling."));
            }
        }


        // Device logic
        private bool checkDevice()
        {
            if (measuringDevice == null)
            {
                Console.WriteLine(WriteMessage("Has no device."));
                return false;
            }
            return true;
        }
        public void UseDevice(Vehicle vehicle)
        {
            if (!checkDevice())
            {
                Console.WriteLine(WriteMessage("No device available."));
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
                        SendAlarm(vehicleWithPlate.GetPlate());
                    }
                }
                else
                {
                    Console.WriteLine(WriteMessage("Tried to scan a vehicle with no plate."));
                }
            }
        }
        public void PrintHistory()

        {
            if (!checkDevice())
            {
                Console.WriteLine(WriteMessage("No device available."));
                return;
            }
            Console.WriteLine(WriteMessage("Report device result history:"));
            foreach (float result in measuringDevice.History)
            {
                Console.WriteLine(result);
            }
        }
        // Pursuit logic
        public bool IsPursuing()
        {
            return pursuing;
        }
        public void SendAlarm(string plate)
        {
            baseStation.SetAlert(plate);
            StartPursuit(plate);
        }
        public void StartPursuit(string plate)
        {
            pursuing = true;
            Console.WriteLine(WriteMessage($"Started pursuit of {plate}."));
        }
    }
}