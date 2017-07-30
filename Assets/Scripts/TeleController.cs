using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleController : MonoBehaviour {
    public Transform offset;
    public Transform destination;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Vector3 off = (offset.position - collision.transform.position);
            collision.transform.position = destination.position - off;
        }
    }
}
