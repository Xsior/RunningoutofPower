using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButton : Button {

    public override void OnMouseDown()
    {
        base.OnMouseDown();

        SceneManager.LoadScene("NowyLevel");
    }
}
