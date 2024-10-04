namespace Practica2
{
    class Program
    {
        static void Main(string[] args)
        {
            City city = new City();
            // Register taxis
            city.RegisterTaxi("0001 AAA");
            city.RegisterTaxi("0002 BBB");
            // Register police cars
            city.PoliceStation().RegisterPoliceCar("0001 CNP", "None");
            city.PoliceStation().RegisterPoliceCar("0002 CNP", "SpeedRadar");
            // Try to use the radar of the police car without a radar
            city.PoliceStation().PoliceCars[0].StartPatrolling();
            city.PoliceStation().PoliceCars[0].UseDevice(city.TaxiList[0]);
            // Use the radar on a vehicle that is speeding
            city.TaxiList[0].StartRide(); // This makes the taxi go at 100 km/h
            city.PoliceStation().PoliceCars[1].StartPatrolling();
            city.PoliceStation().PoliceCars[1].UseDevice(city.TaxiList[0]);
            // Take the taxi license
            city.RemoveLicense("0001 AAA");


        }
    }
}