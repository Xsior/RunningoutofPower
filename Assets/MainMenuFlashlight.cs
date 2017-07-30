using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFlashlight : MonoBehaviour {

    float flashlightTimer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        flashlightTimer += Time.deltaTime;

	}
}
