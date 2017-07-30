using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponBase {
    public Pistol(WeaponManager parent) : base(parent)
    {
        BulletSpeed = 130.0f;
        BulletLifeTime = 0.4f;
        BulletDamage = 30;
        weaponCooldown = 0.5f;
    }
	
	public override void Attack()
    {
        GameObject bullet = Instantiate(Resources.Load("bullet"), new Vector2(0,0), Quaternion.identity) as GameObject;
        bullet.GetComponent<Bullet>().SetProperties(BulletSpeed, BulletLifeTime, BulletDamage);
        bullet.transform.position = parent.transform.position;
        bullet.GetComponent<Bullet>().FireBullet(Bullet.BulletType.Pistol);
    }
}
