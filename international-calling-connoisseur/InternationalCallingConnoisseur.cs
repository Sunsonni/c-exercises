using System;
using System.Collections.Generic;

public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary()
    {
        Dictionary<int, string> dict = new Dictionary<int, string>();
        return dict;
    }

    public static Dictionary<int, string> GetExistingDictionary()
    {
        Dictionary<int, string> dialingCodes = new Dictionary<int, string>
        {
            {1, "United States of America"},
            {55, "Brazil"},
            {91, "India"}
        };
        return dialingCodes;
    }

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        Dictionary<int, string> dictionary = new Dictionary<int, string>();
        dictionary.Add(44, "United Kingdom");
        return dictionary;
    }

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        existingDictionary.Add(countryCode, countryName);
        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        string value = "";
        if (existingDictionary.ContainsKey(countryCode))
        {
            existingDictionary.TryGetValue(countryCode, out value);
        }
        return value;
    }

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
    {
        if(existingDictionary.ContainsKey(countryCode)) {return true;}
        return false;
    }

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if (existingDictionary.ContainsKey(countryCode)) 
        {
            existingDictionary[countryCode] = countryName;
        }
        return existingDictionary;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        string longestCountryName = "";
        foreach(var value in existingDictionary.Values) 
        {
            if(value.Length > longestCountryName.Length)
            {
                longestCountryName = value;
            }
        }
        return longestCountryName;
    }
}