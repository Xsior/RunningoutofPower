using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float startingHp = 100;
    GameObject player;
    bool targetLocked = false;
    int detectionRange = 4;
    public Cooldown attackCooldown;
    float attackDamage = 10;
    float hp;
    float speeedboost = 1f;
    float Hp
    {
        get { return hp; }
        set
        {
            hp = value;
            if (hp <= 0) gameObject.SetActive(false);
        }
    }
    public void SpeedBoost()
    {
        speeedboost = 2.8f;
    }
    public void SpeedNo()
    {
        speeedboost = 1f;
    }
    public void ResetForSpawn()
    {
        hp = startingHp;
        attackCooldown = GetComponent<Cooldown>();
        attackCooldown.Renew();
        targetLocked = false;
    }
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attackCooldown = GetComponent<Cooldown>();
        hp = startingHp;
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
            

            GetComponent<Rigidbody2D>().velocity = (direction * 95 * speeedboost * Time.deltaTime);
        }
        else GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (attackCooldown.canUse)
            {
                attackCooldown.startTimer();
                collision.gameObject.GetComponent<PlayerController>().sanityContr.DealSanityDamage(attackDamage);
            }
        }
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (attackCooldown.canUse)
            {
                attackCooldown.startTimer();
                collision.gameObject.GetComponent<PlayerController>().sanityContr.DealSanityDamage(attackDamage);
            }
        }
        
    }

    public void DealDamage(float damage)
    {
        Hp -= damage;
    }
}
