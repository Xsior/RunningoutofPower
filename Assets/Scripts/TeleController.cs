using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleController : MonoBehaviour {
    public Transform offset;
    public Transform destination;
    public int keyNeeded;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            if (KeyCollector.CheckForKey(keyNeeded))
            {
                Vector3 off = (offset.position - collision.transform.position);
                collision.transform.position = destination.position - off;
            }
            else
            {
                collision.transform.position -= new Vector3(10,0,0);
            }
        }
    }
}
