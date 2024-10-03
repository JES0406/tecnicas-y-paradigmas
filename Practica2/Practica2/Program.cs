namespace Practica2
{
    class Program
    {
        static void Main(string[] args)
        {
            City city = new City();
            PoliceStation policeStation = new PoliceStation();
            city.RegisterTaxi("0001 AAA");
            city.RegisterTaxi("0002 BBB");
            policeStation.RegisterPoliceCar("0001 CNP", "radar");

        }
    }
}