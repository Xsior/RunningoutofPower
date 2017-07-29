using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeLight : MonoBehaviour
{
    RaycastHit2D[] ray;
    bool burning = false;
    public Cooldown cd;
    void BurnOut(object sender, System.EventArgs e)
    {
        transform.DOScale(0, 5f).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
    private void Start()
    {
        cd.cdElapsed += BurnOut;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<SanityController>()!=null)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, ( collision.transform.position - transform.position).normalized, 10000);
            if (hit)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    if(!burning)
                    {
                        cd.startTimer();
                    }
                    Debug.Log("Safe");
                    collision.GetComponent<SanityController>().SafeHaven();
                }

            }

        }
    }

}
