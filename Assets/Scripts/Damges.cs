using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damages", menuName = "Damages", order = 2)]
public class Damges : ScriptableObject {

    public float shotgunDmgPerBullet;
    public float shootgunFireSpread;
    public float shootgunBulletCount;
    public float pistolDmg;
    public float hammerDmg;
}
