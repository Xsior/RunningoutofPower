﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Light2D;
using UnityEngine;

public class LightsController : MonoBehaviour
{

    private GameObject flashlight, matchstick;
    private SanityController sanity;
    private bool flashlightEnabled;

    private int battery;

    public void SetBattery (int power)
    {
        battery = power;
    }

    private float timer, timerWait;
    [SerializeField]
    private float speed = 1, wait = 0.5f;


    void Awake()
    {
        flashlight = gameObject.transform.Find("Flashlight").gameObject;
        matchstick = gameObject.transform.Find("Light").gameObject;
        battery = 100;
        timer = 0;
        timerWait = 0;
        flashlightEnabled = true;
    }
    private void Start()
    {
        sanity = FindObjectOfType<SanityController>();
    }
    private void Update()
    {
        if (timer >= speed && flashlightEnabled)
        {
            battery -= 1;
            timer = 0;
            flashlight.GetComponent<LightSprite>().Color.a = Mathf.Clamp(battery / 100f, 0.4f, 1.0f);
            flashlight.transform.Find("FlashlightChild").GetComponent<LightSprite>().Color.a = Mathf.Clamp(battery / 100f, 0.25f, 1.0f);
        }
        timer += Time.deltaTime;

        if (battery <= 25 && flashlightEnabled)
        {
            RandomFlashlighOff();
            if (sanity.sanityLightRatio != 1.4f)
            {
                sanity.sanityLightRatio = 1.4f;
            }
            timerWait += Time.deltaTime;
        }
        if (battery == 0)
        {
            flashlight.SetActive(false);
            matchstick.SetActive(true);
            if (sanity.sanityLightRatio != 2f)
            {
                sanity.sanityLightRatio = 2f;
            }
            flashlightEnabled = false;
        }
        else if (!flashlightEnabled)
        {
            flashlight.SetActive(true);
            matchstick.SetActive(false);
            if (sanity.sanityLightRatio != 1.5f)
            {
                sanity.sanityLightRatio = 1.5f;
            }
            flashlightEnabled = true;
        }
    }

    private void RandomFlashlighOff()
    {
        if (timerWait >= wait)
        {
            int randomNumber = Random.Range(0, 20);
            if (randomNumber == 0)
            {
                flashlight.SetActive(false);
            }
            if (timerWait >= wait + Random.Range(0.1f, 0.5f))
            {
                if (!flashlight.activeInHierarchy)
                    flashlight.SetActive(true);
                timerWait = 0;
            }
        }
    }

    public void AddBattery(int value)
    {
        battery = Mathf.Clamp(battery + value, 0, 100);
    }
}
