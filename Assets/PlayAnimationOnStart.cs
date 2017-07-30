﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationOnStart : MonoBehaviour {

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(this.enabled)
        {
            anim.SetTrigger("ShowPistol");
        }
	}
}
