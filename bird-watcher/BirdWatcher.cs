using System;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        int[] lastWeek = {0, 2, 5, 3, 7, 8, 4};
        return lastWeek;
    }

    public int Today()
    {
      int lastItem = birdsPerDay[^1];
      return lastItem;
    }

    public void IncrementTodaysCount()
    {
        int index = birdsPerDay.GetUpperBound(0);
        int newValue = birdsPerDay[^1] + 1;
        birdsPerDay.SetValue(newValue, index);
    }

    public bool HasDayWithoutBirds()
    {
        foreach (int day in birdsPerDay)
        {
            if (day == 0) {return true;}
        }
        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int birdCount = 0;
        for (int i = 0; i < numberOfDays; i++)
        {
            birdCount+= birdsPerDay[i];
        }
        return birdCount;
    }

    public int BusyDays()
    {
        int busyDays = 0;
        foreach(int day in birdsPerDay) 
        {
            if(day >= 5) {busyDays++;}
        }
        return busyDays;
    }
}
