using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EquippedWeaponManager : MonoBehaviour {

    public Sprite hammerImage;
    public Sprite pistolImage;
    public Sprite shotgunImage;

    WeaponManager WM;
	// Use this for initialization
	void Start () {
        WM = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(WM.currentWeapon == WeaponManager.SelectedWeaponType.Hammer && WM.hasHammer)
        {
            this.GetComponent<Image>().sprite = hammerImage;
        }
        if (WM.currentWeapon == WeaponManager.SelectedWeaponType.Pistol && WM.hasPistol)
        {
            this.GetComponent<Image>().sprite = pistolImage;
        }
        if (WM.currentWeapon == WeaponManager.SelectedWeaponType.Shotgun && WM.hasShotgun)
        {
            this.GetComponent<Image>().sprite = shotgunImage;
        }
    }
}
