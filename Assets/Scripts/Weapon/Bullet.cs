﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public enum BulletType
    {
        Pistol,
        Shotgun
    }
    private float lifeTime = 10.0f;
    private float lifeTimer = 0;
    private float bulletSpeed = 1;
    bool isFiredPistol = false;
    bool isFiredShotgun = false;
    public float bulletDamage;

    private Vector2 direction;

    private void Start()
    {
        direction = GameObject.FindWithTag("Player").transform.up;

        if (isFiredPistol)
        {
            GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
        }
        if (isFiredShotgun)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x + Random.Range(0.7f, -0.7f), direction.y + Random.Range(0.7f, -0.7f)) * bulletSpeed, ForceMode2D.Impulse);
        }
    }

    public void FixedUpdate()
    {
        //if(isFiredPistol)
        //{
        //    GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
        //}
        //if (isFiredShotgun)
        //{
        //    GetComponent<Rigidbody2D>().AddForce(new Vector3(direction.x + Random.Range(0.7f, -0.7f), direction.y , direction.z + Random.Range(0.7f,-0.7f)) * bulletSpeed, ForceMode2D.Impulse);
        //}
    }

    public void Update()
    {
        lifeTimer += Time.deltaTime;
        if(lifeTimer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }


    public void SetProperties(float BulletSpeed, float LifeTime, float BulletDamage)
    {
        this.lifeTime = LifeTime;
        this.bulletSpeed = BulletSpeed;
        this.bulletDamage = BulletDamage;
    }

    public void FireBullet(BulletType bulletType)
    {
        switch (bulletType)
        {
            case BulletType.Pistol:
                isFiredPistol = true;
                break;
            case BulletType.Shotgun:
                isFiredShotgun = true;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            if (collision.GetComponent<EnemyController>())
            {
                collision.GetComponent<EnemyController>().DealDamage(bulletDamage);
            }
            if (collision.GetComponent<EnemyStandingController>())
            {
                collision.GetComponent<EnemyStandingController>().DealDamage(bulletDamage);
            }
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
