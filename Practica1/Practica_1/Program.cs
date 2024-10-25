using System;
using System.Collections.Generic;

namespace Practica_1
{
    public class Program
    {
        private static void Main()
        {
            TaxiCar taxi1 = new TaxiCar("0001 AAA");
            TaxiCar taxi2 = new TaxiCar("0002 BBB");
            PoliceCar policeCar1 = new PoliceCar("0001 CNP");
            PoliceCar policeCar2 = new PoliceCar("0002 CNP");
            policeCar1.Patrolling = true;
            policeCar1.ShootRadar(taxi1);
            taxi2.PickUpPassenger();
            policeCar2.ShootRadar(taxi2);
            policeCar2.Patrolling = true;
            policeCar2.ShootRadar(taxi2);
            taxi2.PickDownPassenger();
            policeCar2.Patrolling = false;
            taxi1.PickUpPassenger();
            taxi1.PickUpPassenger();
            policeCar1.Patrolling = true;
            policeCar1.ShootRadar(taxi1);
            taxi1.PickDownPassenger();
            taxi1.PickDownPassenger();
            policeCar1.Patrolling = false;
            policeCar1.MakeReport();
            policeCar2.MakeReport();

        }
    }
}