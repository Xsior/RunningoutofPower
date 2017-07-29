using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour {

    public enum WeaponState
    {
        Attacking,
        NonAttacking
    }

    public bool hasAmmo = false;
    public int ammoCapacity = 0;
    public int ammoCount = 0;
    public WeaponManager parent;
    protected WeaponState _WeaponState = WeaponState.NonAttacking;
    public float projectileSpeed;

    public WeaponBase(WeaponManager parent)
    {
        this.parent = parent;
    }

    public virtual void Attack()
    {

    }

    public virtual void Reload()
    {

    }

    public virtual void PlayAnimation()
    {

    }
    
}
