using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightDetector : MonoBehaviour
{

    private SanityController sanity;
    private bool saw = false;
    private void Start()
    {
        sanity = FindObjectOfType<SanityController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, (collision.transform.position - transform.position).normalized, 10000);
        if (hit)
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                Debug.Log("It's a me, mario");
                saw = false;
                if (hit.collider.gameObject.GetComponent<EnemyStandingController>() != null)
                {
                    if (Vector2.Distance(transform.position, hit.collider.transform.position) < hit.collider.gameObject.GetComponent<EnemyStandingController>().detectionRange)
                    {
                        Debug.Log("Hello there");
                        hit.collider.gameObject.GetComponent<EnemyStandingController>().SpeedBoost();
                        hit.collider.gameObject.GetComponent<EnemyStandingController>().Seen();
                    }


                }
                else if (collision.GetComponent<EnemyController>() != null)
                {
                    hit.collider.gameObject.GetComponent<EnemyController>().SpeedBoost();
                }

            }

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyController>() != null)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, (collision.transform.position - transform.position).normalized, 10000);
            if (hit)
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    saw = true;
                }
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyController>() != null)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, (collision.transform.position - transform.position).normalized, 10000);
            if (hit)
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    saw = false;
                    if (hit.collider.gameObject.GetComponent<EnemyStandingController>() != null)
                    {
                        hit.collider.gameObject.GetComponent<EnemyStandingController>().SpeedNo();

                    }
                    else if (collision.GetComponent<EnemyController>() != null)
                    {
                        hit.collider.gameObject.GetComponent<EnemyController>().SpeedNo();
                    }

                }
            }

        }
    }
    private void Update()
    {
        if (saw)
        {
            sanity.sanityEnemyRatio = 2f;

        }
        else
        {
            sanity.sanityEnemyRatio = 1f;

        }


        //saw = false;
    }
}
