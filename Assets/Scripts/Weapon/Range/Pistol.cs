using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponBase {

    public Pistol(WeaponManager parent) : base(parent)
    {
        hasAmmo = true;
        ammoCapacity = 10;
        ammoCount = ammoCapacity;
        projectileSpeed = 200;
        _WeaponState = WeaponState.NonAttacking;
    }
	
	public override void Attack()
    {
        GameObject bullet = null;
        ammoCount--;
        bullet = Instantiate(Resources.Load("bullet"), new Vector2(0,0), Quaternion.identity) as GameObject;
        //bullet.transform.parent = base.transform;
        bullet.transform.position = parent.transform.position;
    }
}
