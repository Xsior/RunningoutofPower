using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    bool chuj = false;
    public Image image;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            image.DOFade(1, 1).OnComplete(() => SceneManager.LoadScene("MainMenu") );
        }
        

    }
}
