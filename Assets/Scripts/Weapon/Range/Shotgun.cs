using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : WeaponBase {

    public Shotgun(WeaponManager parent) : base(parent)
    {
        BulletSpeed = 130.0f;
        BulletLifeTime = 0.18f;
    }

    public override void Attack()
    {
        for(int i =0; i< 6; i++)
        {
            GameObject bullet = Instantiate(Resources.Load("bullet"), new Vector2(0, 0), Quaternion.identity) as GameObject;
            bullet.GetComponent<Bullet>().SetProperties(BulletSpeed, BulletLifeTime);
            bullet.transform.position = parent.transform.position;
            bullet.GetComponent<Bullet>().FireBullet(Bullet.BulletType.Shotgun);
        }
    }
}
