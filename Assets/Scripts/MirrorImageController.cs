using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorImageController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.isTrigger == false)
        {
            collision.gameObject.GetComponent<SanityController>().DealSanityDamage(15f);
        }
                
    }
}
