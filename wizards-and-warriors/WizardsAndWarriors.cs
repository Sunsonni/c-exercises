using System;

abstract class Character
{
    protected string CharacterType { get; }

    protected Character(string characterType)
    {
        CharacterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return $"Character is a {CharacterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior"){}

    public override int DamagePoints(Character target)
    {

        return target.Vulnerable()? 10: 6;
    }
}

class Wizard : Character
{
    protected bool spellPrepared = false;
    public Wizard() : base("Wizard") {}

    public override int DamagePoints(Character target)
    {
        return spellPrepared? 12 : 3; 
    }

    public void PrepareSpell()
    {
        spellPrepared = true;
    }

    public override bool Vulnerable()
    {
        return !spellPrepared;
    }
}
