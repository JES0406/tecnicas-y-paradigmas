namespace Practica2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Practica 1
            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");
            SpeedRadar radar1 = new SpeedRadar();
            SpeedRadar radar2 = new SpeedRadar();
            PoliceCar policeCar1 = new PoliceCar("0001 CNP", radar1); // Null because the police car has no base station
            PoliceCar policeCar2 = new PoliceCar("0002 CNP", radar2);
            policeCar1.StartPatrolling();
            policeCar1.UseDevice(taxi1);
            taxi2.StartRide();
            policeCar2.UseDevice(taxi2);
            policeCar2.StartPatrolling();
            policeCar2.UseDevice(taxi2);
            taxi2.StopRide();
            policeCar2.EndPatrolling();
            taxi1.StartRide();
            taxi1.StartRide();
            policeCar1.StartPatrolling();
            policeCar1.UseDevice(taxi1);
            taxi1.StopRide();
            taxi1.StopRide();
            policeCar1.EndPatrolling();
            policeCar1.PrintHistory();
            policeCar2.PrintHistory();
            // Practica 2
            City city = new City();
            PoliceStation policeStation = new PoliceStation();
            city.SetPoliceStation(policeStation);
            // Register taxis
            Taxi taxi3 = new Taxi("0011 AAA");
            Taxi taxi4 = new Taxi("0022 BBB");
            city.AddTaxi(taxi3);
            city.AddTaxi(taxi4);
            // Register police cars
            PoliceCar policeCar3 = new PoliceCar("0011 CNP");
            SpeedRadar radar3 = new SpeedRadar();
            PoliceCar policeCar4 = new PoliceCar("0022 CNP", radar3);
            policeStation.AddPoliceCar(policeCar3);
            policeStation.AddPoliceCar(policeCar4);
            // Try to use the radar of the police car without a radar
            policeCar3.StartPatrolling();
            policeCar3.UseDevice(taxi3);
            // Use the radar on a vehicle that is speeding
            taxi3.StartRide(); // This makes the taxi go at 100 km/h
            policeCar4.StartPatrolling();
            policeCar4.UseDevice(taxi3);
            // Take the taxi license
            city.RemoveLicense("0011 AAA");


        }
    }
}