using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CreditsButton : MonoBehaviour {

    public virtual void OnMouseDown()
    {
        EditorSceneManager.LoadScene("Credits");
    }
}
