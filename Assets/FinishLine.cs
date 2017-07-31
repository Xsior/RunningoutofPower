using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    float timer = 1f;
    bool chuj = true;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 1f;
            if(chuj)
            {
                transform.Find("NewSprite").GetComponent<SpriteRenderer>().DOFade(0, 1);
                chuj = !chuj;
            }
            else
            {
                transform.Find("NewSprite").GetComponent<SpriteRenderer>().DOFade(1, 1);
                chuj = !chuj;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("MainMenu");
        }
        

    }
}
