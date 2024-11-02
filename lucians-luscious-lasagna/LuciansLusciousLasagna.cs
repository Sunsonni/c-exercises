class Lasagna
{
    // TODO: define the 'ExpectedMinutesInOven()' method

    public int ExpectedMinutesInOven()
    {
        return 40;
    }

    // TODO: define the 'RemainingMinutesInOven()' method

    public int RemainingMinutesInOven(int minutesElapsed) 
    {
        int remainder = this.ExpectedMinutesInOven() - minutesElapsed;
        return remainder;
    }

    // TODO: define the 'PreparationTimeInMinutes()' method
    public int PreparationTimeInMinutes(int numOfLayers)
    {
        int prepTimeInMinutes = numOfLayers * 2;
        return prepTimeInMinutes;
    }
    // TODO: define the 'ElapsedTimeInMinutes()' method
    public int ElapsedTimeInMinutes(int numOfLayers, int timeInOven)
    {
        int ElapsedTime = this.PreparationTimeInMinutes(numOfLayers) + timeInOven;
        return ElapsedTime;
    }
}
