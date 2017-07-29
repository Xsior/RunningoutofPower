using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    private WeaponBase EquippedWeapon;
    // Use this for initialization
    public void Awake()
    {
        EquippedWeapon = new Pistol(this);
    }
    public WeaponManager()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EquippedWeapon.Attack();           
        }
    }

    public void Attach(GameObject obj)
    {
        obj.transform.parent = transform;
    }

}
