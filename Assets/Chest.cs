using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Chest : MonoBehaviour {
    public enum ChestReward
    {
        Pistol,
        Shotgun,
        Battery,
        Beer,
        Szatan
    }
    int Hp;
    GameObject target;
    public ChestReward Reward;
    public GameObject pistolAnimation;
    public GameObject shotgunanimation;

    // Use this for initialization
	void Start () {
        Hp = 3;
	}
	
	// Update is called once per frame
	void Update () {
        if (Hp <= 0)
        {
            if(Reward == ChestReward.Shotgun)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponManager>().AddWeapon(WeaponManager.SelectedWeaponType.Shotgun);
                if (shotgunanimation != null)
                    shotgunanimation.gameObject.SetActive(true);
            }
            if (Reward == ChestReward.Pistol)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponManager>().AddWeapon(WeaponManager.SelectedWeaponType.Pistol);
                if(pistolAnimation != null)
                    pistolAnimation.gameObject.SetActive(true);
            }
            if (Reward == ChestReward.Battery)
                GameObject.FindGameObjectWithTag("Player").GetComponent<LightsController>().AddBattery(20);
            Destroy(gameObject);
            Instantiate(Resources.Load("Zniszczenia"), transform.position, Quaternion.identity);
        }

	}

    public void Hit()
    {
        Hp--;
        Debug.Log(Hp);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        target = collision.gameObject;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        target = null;
    }
}
