using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScriptedEnemyController : MonoBehaviour
{

    [SerializeField]
    
    GameObject player;
    
    public Cooldown attackCooldown;
   
    float speeedboost = 1f;
    public float speed;
    

    public AudioSource audioSource;
    public AudioSource enemyScream;
    public AudioSource enemyCry;

    bool ded = false;
    

    public bool attacked = false;
    
    void Die()
    {
        ded = true;
        GetComponent<SpriteRenderer>().enabled = false;
        enabled = false;
        gameObject.SetActive(false);
    }
    public void SpeedBoost()
    {
        speeedboost = 3f;
    }
    public void SpeedNo()
    {
        speeedboost = 1f;
    }
    

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }
    // Use this for initialization
    void Start()
    {
        ded = false;
        GetComponent<SpriteRenderer>().enabled = true;
        
        attackCooldown = GetComponent<Cooldown>();
        attackCooldown.SetCooldownTime(2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ded)
        {
            HandleMovement();
        }
    }

    void HandleMovement()
    {
            
    }

    public void ChasePlayer()
    {
        Vector3 direction = (player.transform.position - transform.position);
        direction = direction.normalized;

        Quaternion q = Quaternion.LookRotation(direction, Vector3.back);

        transform.rotation = new Quaternion(0, 0, q.z, q.w);

        if (Vector2.Distance(player.transform.position, transform.position) > 0.5f)
        {
            GetComponent<Rigidbody2D>().velocity = (direction * speed * speeedboost * Time.deltaTime);
        }
        else GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !ded)
        {
            if (attackCooldown.canUse)
            {
                audioSource.Play();
                StartCoroutine(DieDieDie());
            }
        }
    }
    
    public IEnumerator DieDieDie()
    {
        yield return new WaitForSeconds(1f);
        Die();
    }
}
