using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cooldowns", menuName = "Cooldowns", order = 1)]
public class SObject : ScriptableObject {

    public float ShotgunCooldown;
    public float PistolCooldown;
    public float HammerCooldown;
    public float Reloadcooldown;
}
