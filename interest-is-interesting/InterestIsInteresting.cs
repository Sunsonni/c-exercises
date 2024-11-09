using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        return balance switch 
        {
            < 0 => 3.213f,
             < 1000 => 0.5f,
             >= 1000 and < 5000 => 1.621f,
             >= 5000 => 2.475f
        };
    }

    public static decimal Interest(decimal balance)
    {
        float rate = InterestRate(balance);
        return balance * (decimal)rate /100;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return Interest(balance) + balance;
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int yearsNeeded = 0;
        while(balance < targetBalance)
        {
            balance = AnnualBalanceUpdate(balance);
            yearsNeeded++;
        }
        return yearsNeeded;
    }
}
