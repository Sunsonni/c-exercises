using System;

class RemoteControlCar
{
    // TODO: define the constructor for the 'RemoteControlCar' class
    private int BatteryLevel { get; set; } = 100;
    public int Speed { get; set; }
    private int BatteryDrain { get; set; }
    private int DistanceDrived {get; set; } = 0;
    public int nextId = 0;
    private int Id { get; set; }

    public RemoteControlCar(int speed, int batteryDrain) 
    {
        Speed = speed; 
        BatteryDrain = batteryDrain;
        Id = nextId;
        nextId++;
    }

    public bool BatteryDrained()
    {
        if(BatteryLevel < BatteryDrain)
        {
            return true;
        }
        return false;
    }

    public int DistanceDriven()
    {
        return DistanceDrived;
    }

    public void Drive()
    {
        if (!(BatteryLevel < BatteryDrain))
        {  
            BatteryLevel = BatteryLevel - BatteryDrain;
            DistanceDrived += Speed;
        }
    }

    public static RemoteControlCar Nitro()
    {
        RemoteControlCar nitro = new RemoteControlCar(50, 4);
        return nitro;
    }
}

class RaceTrack
{
    // TODO: define the constructor for the 'RaceTrack' class
    public int Distance { get; set; }
    public RaceTrack (int distance)
    {
        Distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        int remainingDistance = Distance;
        while(remainingDistance > 0)
        {
            if(car.BatteryDrained())
            { 
                return false;
            }
            car.Drive();
            remainingDistance -= car.Speed;
        } 
        return true;
    }
}
