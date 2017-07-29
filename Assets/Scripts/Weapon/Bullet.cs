using System.Collections;
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
    private float bulletSpeed = 1000.0f;
    bool isFiredPistol = false;
    bool isFiredShotgun = false;
    public float bulletDamage;
    public void FixedUpdate()
    {
        if(isFiredPistol)
        {
            GetComponent<Rigidbody2D>().AddForce(GameObject.FindWithTag("Player").transform.up * bulletSpeed);
        }
        if (isFiredShotgun)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(GameObject.FindWithTag("Player").transform.up.x + Random.Range(0.7f, -0.7f), GameObject.FindWithTag("Player").transform.up.y , GameObject.FindWithTag("Player").transform.up.z + Random.Range(0.7f,-0.7f)) * bulletSpeed);
        }
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
}
