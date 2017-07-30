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
        spawnTimer.cdElapsed += OnTimerElapsed;

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
            CurrentSanity += 4 * sanityLostAmount * Time.deltaTime;
    }

    public void DealSanityDamage(float sanityDamage)
    {
        CurrentSanity -= sanityDamage;
    }

    void OnTimerElapsed(object sender, System.EventArgs e)
    {
        float lightDegrees = 80 + (currentSanity - 100) / 2;
        RaycastHit2D r;
        Vector3 direction;
        int sign = 0;
        do
        {
            sign = Random.Range(-1, 2);
        } while (sign == 0);
        do
        {
            transform.TransformDirection(direction = Quaternion.Euler(0, 0, sign * Random.Range(lightDegrees, 100)) * transform.up);
            r = Physics2D.Raycast(transform.position, direction.normalized);
            Debug.Log(r.distance);
        } while (r.distance < 3.5f);
        spawner.SpawanEnemy(transform.position + (direction.normalized * Random.Range(2f, 3f)));
    }
    private void SpawnHandler()
    {

        if (currentSanity < 90)
        {
            int i = 1;
            i =1 -(int)(currentSanity - 100) / 20;
            //Debug.Log(i);
            if (spawnTimer.canUse && spawner.enemyCount() < i)
            {
                spawnTimer.SetCooldownTime(Random.Range(currentSanity / 100 * 2f, currentSanity / 100 * 10f));
                spawnTimer.startTimer();
            }
        }

    }
}
