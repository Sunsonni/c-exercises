using System;
using System.Collections.Generic;

// TODO implement the IRemoteControlCar interface
public interface IRemoteControlCar
{
    int DistanceTravelled { get; set; }
    void Drive();
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    public int CompareTo(ProductionRemoteControlCar other)
    {
        if (other == null) return 1;
        return NumberOfVictories.CompareTo(other.NumberOfVictories);
    }


}

public class ExperimentalRemoteControlCar : IRemoteControlCar, IComparable
{
    public int DistanceTravelled { get; set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        if(obj is ProductionRemoteControlCar productionCar)
        {
            return DistanceTravelled.CompareTo(productionCar.DistanceTravelled);
        } 
        else
        {
            throw new ArgumentException("Object is not a ProductionRemoteControllCar");
        }
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        List<ProductionRemoteControlCar> rank = new List<ProductionRemoteControlCar>{null};
        if(prc1.CompareTo(prc2) <= 0)
        {
            rank.Add(prc2);
            rank.Add(prc1);
        }
        else 
        {
            rank.Add(prc1);
            rank.Add(prc2);
        }

        return rank;
    }
}
