using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityController : MonoBehaviour
{
    [SerializeField]
    float startingSanity = 100;
    float currentSanity;
    float sanityTimer = 2f;
    [SerializeField]
    float sanityLostAmount = 1f;
    Image sanityBar;

    public float sanityLossRatio = 1f;


    public float CurrentSanity
    {
        get { return currentSanity; }
        set
        {
            if (value < 0)
            {
                currentSanity = 0;
                //gameObject.SetActive(false);
            }
            else
            {
                currentSanity = value;
            }
            sanityBar.DOFillAmount(currentSanity / startingSanity, 0.5f);
        }
    }

    void Start()
    {
        sanityBar = GameObject.FindGameObjectWithTag("Canvas").transform.Find("SanityBar").GetComponent<Image>();
        CurrentSanity = startingSanity;

    }
    void Update()
    {
        ConstantSanityLoss();
    }

    public void ConstantSanityLoss()
    {
        CurrentSanity -= sanityLostAmount * Time.deltaTime;
    }
    public void SafeHaven()
    {
        if(currentSanity < startingSanity)
        CurrentSanity += 4 * sanityLostAmount * Time.deltaTime;
    }

    public void DealSanityDamage(float sanityDamage)
    {
        CurrentSanity -= sanityDamage;
    }
}
