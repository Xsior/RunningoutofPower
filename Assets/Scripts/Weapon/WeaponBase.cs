using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour {
    
    public WeaponManager parent;
    protected float BulletSpeed;
    protected float BulletLifeTime;
    protected float BulletDamage;
    public float weaponCooldown;

    public WeaponBase(WeaponManager parent)
    {
        this.parent = parent;
    }

    public virtual void Attack()
    {

    }
    
}
