namespace Practica2
{
    public class SpeedRadar : MeasuringDevice, IMessageWritter
    {
        //Radar doesn't know about Vechicles, just speed and plates
        private string plate;
        private float speed;
        private float legalSpeed = 50.0f;

        public SpeedRadar() : base()
        {
            plate = "";
            speed = 0f;
        }

        public override void Trigger(VehicleWithPlate vehicle)
        {
            plate = vehicle.GetPlate();
            speed = vehicle.GetSpeed();
            history.Add(speed);
        }
        
        public override string GetLastReading()
        {
            if (speed > legalSpeed)
            {
                return WriteMessage("Catched above legal speed.");
            }
            else
            {
                return WriteMessage("Driving legally.");
            }
        }

        public virtual string WriteMessage(string radarReading)
        {
            return $"Vehicle with plate {plate} at {speed.ToString()} km/h. {radarReading}";
        }
    }
}