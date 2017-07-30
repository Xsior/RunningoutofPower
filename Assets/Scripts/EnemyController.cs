﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float startingHp = 100;
    GameObject player;
    bool targetLocked = false;
    int detectionRange = 7;
    public Cooldown attackCooldown;
    float attackDamage = 8f;
    float hp;
    float speeedboost = 1f;
    public float speed;
    EnemySpawner spawner;

    public AudioSource audioSource;
    public AudioSource enemyScream;
    public AudioSource enemyCry;
    

    float Hp
    {
        get { return hp; }
        set
        {
            hp = value;
            if (hp <= 0)
            {
                
                if(isActiveAndEnabled)
                {
                    StartCoroutine(playSoundToEnd());
                }
               
                
            }
        }
    }
    public IEnumerator playSoundToEnd()
    {
        yield return new WaitForSeconds(1f);
        spawner.Kill(transform);
        enemyScream.Play();
        enabled = false;
        gameObject.SetActive(false);
    }

    public void SpeedBoost()
    {
        speeedboost = 3f;
    }
    public void SpeedNo()
    {
        speeedboost = 1f;
    }
    public void ResetForSpawn()
    {
        hp = startingHp;
        attackCooldown = GetComponent<Cooldown>();
        attackCooldown.Renew();
        targetLocked = false;
    }
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attackCooldown = GetComponent<Cooldown>();
        hp = startingHp;
        spawner = FindObjectOfType<EnemySpawner>();
        //attackCooldown.SetCooldownTime(2f);
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < detectionRange)
        {
            targetLocked = true;
        }
        else GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if (targetLocked) ChasePlayer();
    }

    void ChasePlayer()
    {
        //transform.LookAt(player.transform, Vector3.back);

        //transform.LookAt(player.transform, Vector3.back);
        Vector3 direction = (player.transform.position - transform.position);
        direction = direction.normalized;

        Quaternion q = Quaternion.LookRotation(direction, Vector3.back);

        transform.rotation = new Quaternion(0, 0, q.z, q.w);

        if (Vector2.Distance(player.transform.position, transform.position) > 0.5f)
        {


            GetComponent<Rigidbody2D>().velocity = (direction * speed * speeedboost * Time.deltaTime);
        }
        else GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (attackCooldown.canUse)
            {
                attackCooldown.startTimer();
                collision.gameObject.GetComponent<PlayerController>().sanityContr.DealSanityDamage(attackDamage);
                audioSource.Play();
            }
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (attackCooldown.canUse)
            {
                attackCooldown.startTimer();
                collision.gameObject.GetComponent<PlayerController>().sanityContr.DealSanityDamage(attackDamage);
                audioSource.Play();
            }
        }

    }

    public void DealDamage(float damage)
    {
        Hp -= damage;
    }
}
