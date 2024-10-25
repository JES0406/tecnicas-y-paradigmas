using System;

namespace Practica_1
{
    public interface ICar
    {
        string LicensePlate { get; set; }
        float Speed { get; set; }

        string ToString();
    }
}