using Practica2;
using System;

public abstract class MeasuringDevice: IMessageWritter
{
    private List<float> history;

    public MeasuringDevice()
	{
        history = new List<float>();

    }

    public List<float> History
    {
        get { return history; }
        set { history = value; }
    }
    public virtual void Trigger(VehicleWithPlate vehicle)
    {
    }
    public virtual  string GetLastReading()
    {
        return "";
    }
    public virtual string WriteMessage(string message)
    {
        return $"{this}: {message}";
    }
}
