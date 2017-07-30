using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    public GameObject PauseScreen;
    enum KeyPressed
    {
        Pressed,
        None
    }
    bool isPaused;
    KeyPressed key;
	// Use this for initialization
	void Start () {
        key = KeyPressed.None;
        isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P) && key == KeyPressed.None)
        {
            if(isPaused == false && key == KeyPressed.None)
            {
                isPaused = true;
                key = KeyPressed.Pressed;
                PauseScreen.SetActive(true);
            }
            if (isPaused == true && key == KeyPressed.None)
            {
                isPaused = false;
                key = KeyPressed.Pressed;
                PauseScreen.SetActive(false);
            }
        }
        if(Input.GetKeyUp(KeyCode.P) && key == KeyPressed.Pressed)
        {
            key = KeyPressed.None;
        }

        if (isPaused == true)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
	}
}
