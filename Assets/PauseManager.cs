using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    public GameObject PauseScreen;

    public static PauseManager instance;
    enum KeyPressed
    {
        Pressed,
        None
    }
    public bool isPaused;
    KeyPressed key;
	// Use this for initialization
	void Start () {
        key = KeyPressed.None;
        isPaused = false;
	    instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape) && key == KeyPressed.None)
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
                Time.timeScale = 1;
                PauseScreen.SetActive(false);
            }
        }
        if(Input.GetKeyUp(KeyCode.Escape) && key == KeyPressed.Pressed)
        {
            key = KeyPressed.None;
        }

        if (isPaused == true)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
	}
}
