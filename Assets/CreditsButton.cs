using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CreditsButton : MonoBehaviour {

    public virtual void OnMouseDown()
    {

        SceneManager.LoadScene("Credits");
    }
}
