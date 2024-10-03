using Practica2;
using System;

public class City
{
	PoliceStation policeStation = new PoliceStation();
	public List<Taxi> TaxiList { get; set; }
    public City()
	{
        TaxiList = new List<Taxi>();
    }

    private void AddTaxi(Taxi taxi)
    {
        TaxiList.Add(taxi);
    }

    public void RegisterTaxi(string plate)
    {
        Taxi taxi = new Taxi(plate);
        AddTaxi(taxi);
    }

    public void RemoveLicense(string plate)
    {
        foreach (Taxi taxi in TaxiList)
        {
            if (taxi.GetPlate() == plate)
            {
                TaxiList.Remove(taxi);
                break;
            }
        }
    }
}
