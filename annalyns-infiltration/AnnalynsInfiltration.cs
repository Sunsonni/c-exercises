using System;

static class QuestLogic
{
    public static bool CanFastAttack(bool knightIsAwake)
    {
        bool canFastAttack = false;
        if(!knightIsAwake)
        {
            canFastAttack = true;
        }
        return canFastAttack;
    }

    public static bool CanSpy(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake)
    {
        bool canSpy = false;
        if(knightIsAwake || archerIsAwake || prisonerIsAwake)
        {
            canSpy = true;
        }
        return canSpy;
    }

    public static bool CanSignalPrisoner(bool archerIsAwake, bool prisonerIsAwake)
    {
       bool canSignalPrisoner = false;
       if(!archerIsAwake && prisonerIsAwake)
       {
        canSignalPrisoner = true;
       }
       return canSignalPrisoner;
    }

    public static bool CanFreePrisoner(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake, bool petDogIsPresent)
    {
        bool canFreePrisoner = false;
        if(petDogIsPresent && !archerIsAwake)
        {
            canFreePrisoner = true;
        } else if (!petDogIsPresent && prisonerIsAwake && !knightIsAwake && !archerIsAwake)
        {
            canFreePrisoner = true;
        }
        return canFreePrisoner;
    }
}
