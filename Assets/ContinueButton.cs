using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{

    public void OnContinueClick()
    {
        PauseManager.instance.isPaused = false;
        Time.timeScale = 1;
        transform.parent.gameObject.SetActive(false);
    }

    public void OnMenuClick()
    {
        PauseManager.instance.isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
