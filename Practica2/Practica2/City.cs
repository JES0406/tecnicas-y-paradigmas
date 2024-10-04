using Practica2;
using System;

public class City: IMessageWritter
{
	private PoliceStation policeStation = new PoliceStation();
    private List<Taxi> taxiList;
    public City()
	{
        taxiList = new List<Taxi>();
    }

    public PoliceStation PoliceStation()
    {
        return policeStation;
    }
    public List<Taxi> TaxiList
    {
        get { return taxiList; }
        set { taxiList = value; }
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
                Console.WriteLine(WriteMessage($"Taxi with plate {plate} has been removed."));
                break;
            }
        }
    }

    public override string ToString()
    {
        return "City";
    }

    public string WriteMessage(string message)
    {
        return $"{this}: {message}";
    }
}
