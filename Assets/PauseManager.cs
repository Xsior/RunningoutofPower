using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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

                key = KeyPressed.Pressed;
                Time.timeScale = 1;
                SceneManager.LoadScene("MainMenu");
            }
        }
        if(Input.GetKeyUp(KeyCode.Escape) && key == KeyPressed.Pressed)
        {
            key = KeyPressed.None;
        }
        if (Input.GetKeyDown(KeyCode.Space) && key == KeyPressed.None)
        {
            if (isPaused == true && key == KeyPressed.None)
            {

                isPaused = false;
                key = KeyPressed.Pressed;
                PauseScreen.SetActive(false);
            }
        }
        if (isPaused == true)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
	}
}
