using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject player;
    bool targetLocked = false;
    int detectionRange = 3;
    public Cooldown attackCooldown;
    float attackDamage = 10;
	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attackCooldown = GetComponent<Cooldown>();
        //attackCooldown.SetCooldownTime(2f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < detectionRange)
        {
            targetLocked = true;
        }
        else GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if(targetLocked) ChasePlayer();
    }

    void ChasePlayer()
    {
        //transform.LookAt(player.transform, Vector3.back);

        //transform.LookAt(player.transform, Vector3.back);
        Vector3 direction = (player.transform.position - transform.position);
        direction = direction.normalized;

        Quaternion q = Quaternion.LookRotation(direction, Vector3.back);

        transform.rotation = new Quaternion(0, 0, q.z, q.w);

        if (Vector2.Distance(player.transform.position, transform.position) > 0.5f)
        {
            

            GetComponent<Rigidbody2D>().velocity = (direction * 250 * Time.deltaTime);
        }
        else GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void AttackPlayer()
    {
        player.GetComponent<PlayerController>().CurrentHp -= attackDamage;
        Debug.Log("DIPSY");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(attackCooldown.canUse)
        {
            attackCooldown.startTimer();
            AttackPlayer();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (attackCooldown.canUse)
        {
            attackCooldown.startTimer();
            AttackPlayer();
        }
    }
}
