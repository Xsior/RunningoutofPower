using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KeyController : MonoBehaviour
{


    SpriteRenderer sprite;
    public int keyId = 1;
    public GameObject keyAnim;
    public GameObject UIText;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            UIText.GetComponent<Text>().text = "Press 'E' to pickup";
            UIText.SetActive(true);
            if (Input.GetButtonDown("E"))
            {
                gameObject.SetActive(false);
                KeyCollector.AddKey(keyId);
                KeyCollector.VerboseKeys();
                if (keyAnim != null)
                    keyAnim.SetActive(true);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            UIText.SetActive(false);
        }
    }
}
