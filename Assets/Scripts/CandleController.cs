﻿using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : MonoBehaviour {

    public Cooldown cd;
    public Transform player;
    public GameObject light;
    private bool burnt = false;
    
    private void Start()
    {
        cd.cdElapsed += BurnOut;
        player = FindObjectOfType<SanityController>().transform;
    }
    void BurnOut(object sender, EventArgs e)
    {
        light.transform.DOScale(0, 5f).OnComplete(()=> 
        {
            light.SetActive(false);
        });
    }
    private void Update()
    {
        

        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!burnt && Input.GetButtonDown("E"))
        {
            burnt = true;
            cd.startTimer();
            light.transform.localScale = new Vector3(8, 8, 8);
            light.SetActive(true);
        }
    }
}
