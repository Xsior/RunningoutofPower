using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    enum SelectedWeaponType
    {
        Pistol, Shotgun, Hammer
    }
    private WeaponBase EquippedWeapon;
    private Cooldown pistolCooldown;
    private Cooldown shotgunCooldown;
    private Cooldown reloadCooldown;
    private Cooldown hammerCooldown;
    public GameObject triggeredEnemy;
    public SObject Cooldowns;

    SelectedWeaponType currentWeapon;
    // Use this for initialization
    public void Awake()
    {
        EquippedWeapon = new Pistol(this);
        pistolCooldown = GetComponents<Cooldown>()[0];
        shotgunCooldown = GetComponents<Cooldown>()[1];
        reloadCooldown = GetComponents<Cooldown>()[2];
        hammerCooldown = GetComponents<Cooldown>()[3];
        triggeredEnemy = null;
    }
    public WeaponManager()
    {

    }
    public void Start()
    {
        pistolCooldown.SetCooldownTime(Cooldowns.PistolCooldown);
        shotgunCooldown.SetCooldownTime(Cooldowns.ShotgunCooldown);
        reloadCooldown.SetCooldownTime(Cooldowns.Reloadcooldown);
        hammerCooldown.SetCooldownTime(Cooldowns.HammerCooldown);
    }
    // Update is called once per frame
    void Update()
    {
        if (reloadCooldown.canUse)
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                EquippedWeapon = new Pistol(this);
                currentWeapon = SelectedWeaponType.Pistol;
                reloadCooldown.startTimer();
            }
            else if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                EquippedWeapon = new Shotgun(this);
                currentWeapon = SelectedWeaponType.Shotgun;
                reloadCooldown.startTimer();
            }
            else if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                EquippedWeapon = new Hammer(this);
                currentWeapon = SelectedWeaponType.Hammer;
                reloadCooldown.startTimer();
            }
        }


        if (Input.GetMouseButton(0))
        {
            switch (currentWeapon)
            {
                case SelectedWeaponType.Pistol:
                    {
                        if (pistolCooldown.canUse)
                        {
                            pistolCooldown.startTimer();
                            EquippedWeapon.Attack();
                        }
                    }
                    break;
                case SelectedWeaponType.Shotgun:
                    {
                        if (shotgunCooldown.canUse)
                        {
                            shotgunCooldown.startTimer();
                            EquippedWeapon.Attack();
                        }
                    }
                    break;
                case SelectedWeaponType.Hammer:
                    {
                        if (hammerCooldown.canUse)
                        {
                            hammerCooldown.startTimer();
                            EquippedWeapon.Attack();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            triggeredEnemy = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            triggeredEnemy = null;
        }
    }
}
