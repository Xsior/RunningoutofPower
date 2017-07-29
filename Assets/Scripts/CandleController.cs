using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : MonoBehaviour {

    public Cooldown cd;

    public GameObject light;
    private bool burnt = false;
    private void Start()
    {
        cd.cdElapsed += BurnOut;
    }
    void BurnOut(object sender, EventArgs e)
    {
        light.transform.DOScale(Vector3.zero, 1f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!burnt && Input.GetButtonDown("E"))
        {
            cd.startTimer();
            light.transform.localScale = new Vector3(5, 5, 5);
            light.SetActive(true);
        }
    }
}
