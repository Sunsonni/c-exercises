using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    
     public override bool Equals(object obj)
    {
        
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        
        FacialFeatures other = (FacialFeatures)obj;
        
        return EyeColor == other.EyeColor && PhiltrumWidth == other.PhiltrumWidth;
    }
    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }

}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    // TODO: implement equality and GetHashCode() methods
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Identity identity = (Identity)obj;

        return Email == identity.Email && FacialFeatures.Equals(identity.FacialFeatures);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }
}

public class Authenticator
{
    private int nextId = 0;
    Dictionary<int, Identity> admins = new Dictionary<int, Identity>();
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        Identity builtIn = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
        return builtIn.Equals(identity);
    }

    public bool Register(Identity identity)
    {
       if(!IsRegistered(identity))
        {
            admins.Add(nextId, identity);
            nextId++;
            return true;
        }
        return false;
    }

    public bool IsRegistered(Identity identity)
    {
        foreach(var admin in admins.Values)
        {
            if(admin.Equals(identity))
            {
                return true; 
            }
        }
        return false;
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
      return object.ReferenceEquals(identityA, identityB);
    }
}
