using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityController : MonoBehaviour
{
    float startingSanity = 100;
    float currentSanity;
    float sanityTimer = 2f;
    float sanityLostAmount = 10f;
    Image sanityBar;

    public float CurrentSanity
    {
        get { return currentSanity; }
        set
        {
            if (value < 0)
            {
                currentSanity = 0;
                gameObject.SetActive(false);
            }
            else
            {
                currentSanity = value;
            }
            sanityBar.DOFillAmount(currentSanity / startingSanity, 0.5f);
        }
    }

	void Start ()
    {
        sanityBar = GameObject.FindGameObjectWithTag("Canvas").transform.Find("SanityBar").GetComponent<Image>();
        CurrentSanity = startingSanity;
        
    }
	void Update ()
    {
        ConstantSanityLost();
    }

    public void ConstantSanityLost()
    {
        if (sanityTimer > 0)
        {
            sanityTimer -= Time.deltaTime;
        }
        else
        {
            sanityTimer = 2f;
            CurrentSanity -= sanityLostAmount;
        }

    }

    public void DealSanityDamage(float sanityDamage)
    {
        CurrentSanity -= sanityDamage;
    }
}
