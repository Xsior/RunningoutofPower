using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{


    SpriteRenderer sprite;
    public int keyId = 1;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            if (Input.GetButtonDown("E"))
            {
                gameObject.SetActive(false);
                KeyCollector.AddKey(keyId);
                KeyCollector.VerboseKeys();
            }
    }
}
