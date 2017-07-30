using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : WeaponBase
{

    public Hammer(WeaponManager parent) : base(parent)
    {

    }

    public override void Attack()
    {
        //base.Attack();
        if (parent.triggeredEnemy != null)
        {
            if(parent.triggeredEnemy.tag == "Enemy")
            {
                if (parent.triggeredEnemy.GetComponent<EnemyController>())
                {
                    parent.triggeredEnemy.GetComponent<EnemyController>().DealDamage(50);
                }
                if(parent.triggeredEnemy.GetComponent<EnemyStandingController>())
                {
                    parent.triggeredEnemy.GetComponent<EnemyStandingController>().DealDamage(50);
                }
                GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().hammerHit.Stop();
                GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().hammerHit.clip =
                                GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().clipList[1];
                GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().hammerHit.Play();
                return;
            }
            else if (parent.triggeredEnemy.tag == "Chest")
            {
                parent.triggeredEnemy.GetComponent<Chest>().Hit();

                GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().hammerHit.Stop();
                GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().hammerHit.clip =
                                GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().clipList[1];
                GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerSounds").GetComponent<PlayerSounds>().hammerHit.Play();
                return;
            }

        }

    }
}
