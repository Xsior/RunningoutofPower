using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public enum SelectedWeaponType
    {
        Pistol, Shotgun, Hammer, None
    }
    public WeaponBase EquippedWeapon;
    private Cooldown pistolCooldown;
    private Cooldown shotgunCooldown;
    private Cooldown reloadCooldown;
    private Cooldown hammerCooldown;
    public Cooldown currentCooldown;
    public GameObject triggeredEnemy;
    public SObject Cooldowns;

    public bool hasPistol;
    public bool hasShotgun;
    public bool hasHammer;

    [SerializeField] private Animator animHammer;

    [SerializeField] private Transform weapons;

    [SerializeField]
    private Damges dmg;

    public SelectedWeaponType currentWeapon;
    // Use this for initialization
    public void Awake()
    {
    }
    public WeaponManager()
    {

    }
    public void Start()
    {
        hasPistol = false;
        hasShotgun = false;
        hasHammer = true;
        EquippedWeapon = new Hammer(this, dmg.hammerDmg);

        currentWeapon = SelectedWeaponType.Hammer;

        ChangeWeapon("hammer");

        pistolCooldown = GetComponents<Cooldown>()[0];
        shotgunCooldown = GetComponents<Cooldown>()[1];
        reloadCooldown = GetComponents<Cooldown>()[2];
        hammerCooldown = GetComponents<Cooldown>()[3];
        currentCooldown = hammerCooldown;
        triggeredEnemy = null;
        pistolCooldown.SetCooldownTime(Cooldowns.PistolCooldown);
        shotgunCooldown.SetCooldownTime(Cooldowns.ShotgunCooldown);
        reloadCooldown.SetCooldownTime(Cooldowns.Reloadcooldown);
        hammerCooldown.SetCooldownTime(Cooldowns.HammerCooldown);
        pistolCooldown.resetTimer();
        shotgunCooldown.resetTimer();
        reloadCooldown.resetTimer();
        hammerCooldown.resetTimer();



    }
    // Update is called once per frame
    void Update()
    {
        if (reloadCooldown.canUse)
        {
            if (Input.GetKeyUp(KeyCode.Alpha1) && hasPistol)
            {
                EquippedWeapon = new Pistol(this, weapons.Find("pistol"), dmg.pistolDmg);
                currentWeapon = SelectedWeaponType.Pistol;
                currentCooldown = pistolCooldown;
                reloadCooldown.startTimer();
                ChangeWeapon("pistol");
            }
            else if (Input.GetKeyUp(KeyCode.Alpha2) && hasShotgun)
            {
                EquippedWeapon = new Shotgun(this, weapons.Find("shotgun"), dmg);
                currentWeapon = SelectedWeaponType.Shotgun;
                currentCooldown = shotgunCooldown;
                reloadCooldown.startTimer();
                ChangeWeapon("shotgun");
            }
            else if (Input.GetKeyUp(KeyCode.Alpha3) && hasHammer)
            {
                EquippedWeapon = new Hammer(this, dmg.hammerDmg);
                currentWeapon = SelectedWeaponType.Hammer;
                currentCooldown = hammerCooldown;
                reloadCooldown.startTimer();
                ChangeWeapon("hammer");
            }
        }


        if (Input.GetMouseButton(0))
        {
            switch (currentWeapon)
            {
                case SelectedWeaponType.Pistol:
                    {
                        if (pistolCooldown.canUse && hasPistol)
                        {
                            pistolCooldown.startTimer();
                            EquippedWeapon.Attack();

                            GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().audioSource.Stop();
                            GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().audioSource.volume = 0.7f;
                            GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().audioSource.clip =
                                GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().clipList[3];
                            GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().audioSource.Play();

                        }
                    }
                    break;
                case SelectedWeaponType.Shotgun:
                    {
                        if (shotgunCooldown.canUse && hasShotgun)
                        {
                            shotgunCooldown.startTimer();
                            EquippedWeapon.Attack();

                            GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().audioSource.Stop();
                            GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().audioSource.volume = 0.7f;
                            GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().audioSource.clip =
                                GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().clipList[2];
                            GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().audioSource.Play();
                        }
                    }
                    break;
                case SelectedWeaponType.Hammer:
                    {
                        if (hammerCooldown.canUse && hasHammer)
                        {
                            
                            GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().audioSource.Stop();
                            GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().audioSource.volume = 1f;
                            GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().audioSource.clip =
                                GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().clipList[0];
                            GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().audioSource.Play();

                            hammerCooldown.startTimer();
                            EquippedWeapon.Attack();
                            if (animHammer)
                                animHammer.SetTrigger("Attack");


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
        if (gameObject.layer == LayerMask.GetMask("Light"))
            return;
        if (collision.tag == "Enemy" || collision.tag == "Chest")
        {
            triggeredEnemy = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.layer == LayerMask.GetMask("Light"))
            return;
        if (collision.tag == "Enemy" || collision.tag == "Chest")
        {
            triggeredEnemy = null;
        }
    }

    public void AddWeapon(SelectedWeaponType type)
    {
        switch (type)
        {
            case SelectedWeaponType.Pistol:
                hasPistol = true;
                break;
            case SelectedWeaponType.Shotgun:
                hasShotgun = true;
                break;
            case SelectedWeaponType.Hammer:
                hasHammer = true;
                break;
        }
    }

    private void ChangeWeapon(string name)
    {
        if (weapons)
        {
            foreach (Transform item in weapons)
            {
                if (item.gameObject.name == name)
                {
                    item.gameObject.SetActive(true);
                }
                else
                {
                    item.gameObject.SetActive(false);
                }
            }
        }

    }
}
