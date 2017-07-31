using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponBase
{
    private Transform pos;
    public Pistol(WeaponManager parent, Transform weaponPosition, float dmg) : base(parent)
    {
        BulletSpeed = 130.0f;
        BulletLifeTime = 0.4f;
        BulletDamage = dmg;
        weaponCooldown = 0.5f;
        pos = weaponPosition;
    }
	
	public override void Attack()
    {
        GameObject bullet = Instantiate(Resources.Load("bullet"), new Vector2(0,0), Quaternion.identity) as GameObject;
        bullet.GetComponent<Bullet>().SetProperties(BulletSpeed, BulletLifeTime, BulletDamage, (Camera.main.ScreenToWorldPoint(Input.mousePosition) - pos.position).normalized);
        bullet.transform.position = pos.position;
        bullet.GetComponent<Bullet>().FireBullet(Bullet.BulletType.Pistol);
    }
}
