using System;

class RemoteControlCar
{
    private int nextId = 0;
    public int BatteryLevel { get; set; } = 100;
    public int MetersDriven { get; set; } = 0;
    public int CarId { get; set; }

    public RemoteControlCar() 
    {
        CarId = this.nextId;
        nextId++;
    }

    public static RemoteControlCar Buy()
    {
        RemoteControlCar car = new RemoteControlCar();
        return car;
    }

    public string DistanceDisplay()
    {
        string distanceDisplay = "Driven " + MetersDriven + " meters";
        return distanceDisplay;
    }

    public string BatteryDisplay()
    {
        string batteryDisplay = "Battery at " + BatteryLevel + "%";
        if (BatteryLevel <= 0)
        {
            batteryDisplay = "Battery empty";
        }
        return batteryDisplay;
    }

    public void Drive()
    {
        if(!(BatteryLevel <= 0))
        {
            MetersDriven+=20;
            BatteryLevel--;
        }
    }

    
}
