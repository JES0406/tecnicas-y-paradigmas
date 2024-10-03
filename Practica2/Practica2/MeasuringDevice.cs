using Practica2;
using System;

public abstract class MeasuringDevice
{
    public List<float> history { get; private set; }

    public MeasuringDevice()
	{
        history = new List<float>();

    }
    public virtual void Trigger(VehicleWithPlate vehicle)
    {
    }
    public virtual  string GetLastReading()
    {
        return "";
    }
}
