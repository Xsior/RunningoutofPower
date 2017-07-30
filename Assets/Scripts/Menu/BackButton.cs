using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : Button {

    public override void OnMouseDown()
    {
        base.OnMouseDown();

        Application.Quit();
    }
}
