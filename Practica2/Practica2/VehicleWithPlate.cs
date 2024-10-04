using Practica2;
using System;

namespace Practica2
{
    public abstract class VehicleWithPlate : Vehicle
    {
        public string plate;
        public VehicleWithPlate(string typeOfVehicle, string plate) : base(typeOfVehicle)
        {
            this.plate = plate;
        }
        public string GetPlate()
        {
            return plate;
        }

        public override string ToString()
        {
            return $"{GetTypeOfVehicle()} with plate {plate}";
        }
    }
}
