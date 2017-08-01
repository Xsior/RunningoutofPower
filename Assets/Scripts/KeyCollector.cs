using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KeyCollector  {


    private static List<int> keys = new List<int>();
    private static bool isReset;

    public static bool IsKeysReset()
    {
        return isReset;
    }
    
    public static void AddKey(int i)
    {
        keys.Add(i);
        isReset = false;
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
        Debug.Log(s);
    }

    public static void ResetKeys()
    {
        isReset = true;
        keys.RemoveAll(k => true);
    }

}
