using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUIActivator : MonoBehaviour
{
    public GameObject redKey;
    public GameObject goldKey;
    public GameObject greenKey;
    public GameObject blueKey;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (KeyCollector.CheckForKey(1))//red
            redKey.SetActive(true);
        else
            redKey.SetActive(false);

        if (KeyCollector.CheckForKey(2))//gold
            goldKey.SetActive(true);
        else
            goldKey.SetActive(false);

        if (KeyCollector.CheckForKey(3))//green
            greenKey.SetActive(true);
        else
            greenKey.SetActive(false);
        if (KeyCollector.CheckForKey(4))//blue\
            blueKey.SetActive(false);
        else
            blueKey.SetActive(false);

    }
}
