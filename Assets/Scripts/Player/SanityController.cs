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
    float sanityLostAmount = 1.5f;
    public Image sanityBar;
    EnemySpawner spawner;
    public float sanityLightRatio = 1f;
    public float sanityEnemyRatio = 1f;
    public Cooldown spawnTimer;
    bool scaryTime = false;

    [SerializeField] private ParticleSystem dmgParticle;

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
        dmgParticle.Stop();
        dmgParticle.Play();
        CurrentSanity -= sanityDamage;

        GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().playerHurtSource.Stop();
        GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().playerHurtSource.Play();
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

            spawner.SpawanEnemy(transform.position + (direction.normalized * Random.Range(3f, 4f)));
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
