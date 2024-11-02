using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        StringBuilder sb = new StringBuilder();
        bool isKababCase = false;

        foreach (char c in identifier)
        {
            string character = "";

            if (c >= '\u03B1' && c <= '\u03C9' ||
                char.IsDigit(c) || // Digits
                char.IsSurrogate(c))
            {
                continue;
            }
            else if(c.ToString() == " ")
            {
                character = "_";
            } else if (char.IsControl(c))
            {
                character =  "CTRL";
            } else if (c.ToString() == "-")
            {
                isKababCase = true;
                continue;

            } else 
            {
                character = c.ToString();
            }

            if(isKababCase)
            {
                character = character.ToUpper(CultureInfo.InvariantCulture);
                isKababCase = false;
            }

            sb.Append(character);
        }
        return sb.ToString();
    }
}
