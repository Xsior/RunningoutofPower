using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeLight : MonoBehaviour
{
    RaycastHit2D[] ray;
    public LayerMask layerMask;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("found something");
        if (collision.GetComponent<SanityController>()!=null)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, ( collision.transform.position - transform.position).normalized, 10000);
            if (hit)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    collision.GetComponent<SanityController>().SafeHaven();
                }

            }

        }
    }

}
