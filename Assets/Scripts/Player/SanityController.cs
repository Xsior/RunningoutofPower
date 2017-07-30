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
    public Image sanityBar;
    EnemySpawner spawner;
    public float sanityLightRatio = 1f;
    public float sanityEnemyRatio = 1f;
    public Cooldown spawnTimer;
    bool scaryTime = false;
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
        spawner = FindObjectOfType<EnemySpawner>();
        CurrentSanity = startingSanity;
        //spawnTimer.cdElapsed += OnTimerElapsed;

    }
    void Update()
    {

        ConstantSanityLoss();
        SpawnHandler();
    }

    public void ConstantSanityLoss()
    {
        CurrentSanity -= sanityLostAmount * sanityLightRatio * sanityEnemyRatio * Time.deltaTime;
    }
    public void SafeHaven()
    {
        if (currentSanity < startingSanity)
            CurrentSanity += 8 * sanityLostAmount * Time.deltaTime;
    }

    public void DealSanityDamage(float sanityDamage)
    {
        CurrentSanity -= sanityDamage;
    }

    bool OnTimerElapsed()
    {
        float lightDegrees = 80 + (currentSanity - 100) / 2;
        RaycastHit2D r;
        Vector3 direction;
        int sign = 1;
        if (Random.Range(0, 1) == 0)
        {
            sign = -1;
        }
        transform.TransformDirection(direction = Quaternion.Euler(0, 0, sign * Random.Range(lightDegrees, 100)) * transform.up);
        r = Physics2D.Raycast(transform.position, direction.normalized);

        if (r.distance > 3.5f)
        {

            spawner.SpawanEnemy(transform.position + (direction.normalized * Random.Range(2f, 3f)));
            return true;
        }
        else
            return false;
    }
    private void SpawnHandler()
    {

        if (currentSanity < 90)
        {
            if (scaryTime)
            {
                int i = 1;
                i = 1 - (int)(currentSanity - 100) / 7;

                if (spawnTimer.canUse && spawner.enemyCount() < i)
                {
                    if (OnTimerElapsed())
                    {
                        spawnTimer.SetCooldownTime(Random.Range(currentSanity / 100 * 1.2f, currentSanity / 100 * 7f));
                        spawnTimer.startTimer();
                    }
                }
            }
            if (!scaryTime)
            {
                scaryTime = true;
                spawnTimer.Renew();
                spawnTimer.SetCooldownTime(3);
                spawnTimer.startTimer();
            }
        }


        else
        {
            if (scaryTime)
            {
                scaryTime = false;
            }
        }

    }
}
