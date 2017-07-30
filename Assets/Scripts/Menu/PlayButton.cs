using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayButton : Button {

    public override void OnMouseDown()
    {
        base.OnMouseDown();

        EditorSceneManager.LoadScene("main");
    }
}
