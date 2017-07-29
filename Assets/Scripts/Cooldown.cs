using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Cooldown : MonoBehaviour
{
    private float timerValue;
    private bool isTimerRunning;

    public bool canUse;
    public float cooldownTime;

    public event EventHandler cdElapsed;

    public Cooldown(float cooldownTime)
    {
        this.cooldownTime = cooldownTime;
        isTimerRunning = false;
        timerValue = cooldownTime;
        canUse = true;

        cdElapsed += Cooldown_cdElapsed;
    }

    private void Cooldown_cdElapsed(object sender, EventArgs e)
    {
        canUse = true;
    }
    public void SetTime(float time)
    {
        timerValue = time;
    }

    public void startTimer()
    {
        isTimerRunning = true;
        canUse = false;

    }
    public void stopTimer()
    {
        isTimerRunning = false;
    }
    public void resetTimer()
    {
        timerValue = cooldownTime;

    }
    public void Update()
    {
        if (isTimerRunning)
        {
            timerValue -= Time.deltaTime;
            if (timerValue < 0)
            {   
                if (cdElapsed != null)
                {
                    cdElapsed.Invoke(this, EventArgs.Empty);
                }
               
                stopTimer();
                resetTimer();
            }
        }
    }
    
}

