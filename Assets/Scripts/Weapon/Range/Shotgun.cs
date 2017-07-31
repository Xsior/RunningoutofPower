using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : WeaponBase
{
    private Transform pos;
    private Damges dmg;

    public Shotgun(WeaponManager parent, Transform weaponPosition, Damges dmg) : base(parent)
    {
        BulletSpeed = 130.0f;
        BulletLifeTime = 0.25f;
        BulletDamage = dmg.shotgunDmgPerBullet;
        weaponCooldown = 2.0f;
        pos = weaponPosition;
        this.dmg = dmg;
    }

    public override void Attack()
    {

        for (int i = 0; i < dmg.shootgunBulletCount; i++)
        {
            GameObject bullet = Instantiate(Resources.Load("bullet"), new Vector2(0, 0), Quaternion.identity) as GameObject;
            bullet.GetComponent<Bullet>().SetProperties(BulletSpeed, BulletLifeTime, BulletDamage, (Camera.main.ScreenToWorldPoint(Input.mousePosition) - pos.position).normalized, dmg.shootgunFireSpread);
            bullet.transform.position = pos.position;
            bullet.GetComponent<Bullet>().FireBullet(Bullet.BulletType.Shotgun);
        }

    }
}
