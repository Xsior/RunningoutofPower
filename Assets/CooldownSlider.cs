﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CooldownSlider : MonoBehaviour {

    WeaponManager WM;
	// Use this for initialization
	void Start () {
        WM = GameObject.Find("Weapons").GetComponent<WeaponManager>();
    }
	
	// Update is called once per frame
	void Update () {
        //this.GetComponent<Slider>().value = WM
        WM.currentCooldown.GetTime();
        //WM.currentCooldown.cooldownTime;
        //WM.currentCooldown
        if(WM.currentCooldown != null)
        {
            this.GetComponent<Image>().fillAmount = WM.currentCooldown.GetTime() / WM.currentCooldown.cooldownTime;
            if(WM.currentCooldown.GetTime() < WM.currentCooldown.cooldownTime)
            {
                this.GetComponent<Image>().color = Color.red;
            }
            else
            {
                this.GetComponent<Image>().color = Color.green;
            }
        }
	}
}
