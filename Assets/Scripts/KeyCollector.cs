using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KeyCollector  {


    private static List<int> keys = new List<int>();

    
    public static void AddKey(int i)
    {
        keys.Add(i);
    }

    public static bool CheckForKey(int i)
    {
        return (keys.Contains(i));
    }

    public static void VerboseKeys()
    {
        string s = "";
        foreach(int i in keys)
        {
            s += i + " ";
        }

    }



}
