using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityController : MonoBehaviour
{
    float startingSanity = 100;
    float currentSanity;
    float sanityTimer = 5f;
    float sanityLostAmount = 5f;
    Image sanityBar;

    public float CurrentSanity
    {
        get { return currentSanity; }
        set
        {
            if (value < 0)
            {
                currentSanity = 0;
            }
            else
            {
                currentSanity = value;
            }
               
            sanityBar.DOFillAmount(currentSanity / startingSanity, 0.25f);
        }
    }

	void Start ()
    {
        currentSanity = startingSanity;
        sanityBar = GetComponent<Image>();
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
            sanityTimer = 5f;
            CurrentSanity -= sanityLostAmount;
        }

    }

    public void DealSanityDamage(float sanityDamage)
    {
        CurrentSanity -= sanityDamage;
    }
}
