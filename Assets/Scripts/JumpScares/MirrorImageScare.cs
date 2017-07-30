using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorImageScare : JumpScareBase
{

    public float speed = 1;
    GameObject player;
    bool goingStarted = false;
    public GameObject mirrorImage;
    float alpha = 1f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(goingStarted)
        {
            GoToPlayer();
            mirrorImage.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
        }
    }

    void GoToPlayer()
    {
        if(Vector3.Distance(player.transform.position, mirrorImage.transform.position) > 2)
        {
            Vector3 direction = (player.transform.position - mirrorImage.transform.position);
            direction = direction.normalized;

            Quaternion q = Quaternion.LookRotation(direction, Vector3.back);

            mirrorImage.transform.rotation = new Quaternion(0, 0, q.z, q.w);
            if (Vector2.Distance(player.transform.position, mirrorImage.transform.position) > 0.5f)
            {


                mirrorImage.GetComponent<Rigidbody2D>().velocity = (direction * 250 * speed * Time.deltaTime);
            }
            else mirrorImage.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else mirrorImage.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!jumpsScareDone)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                jumpsScareDone = true;
                collidedObject = collision;
                OnJumpScareExecution();
                mirrorImage.SetActive(true);
            }
            

        }
    }

    public override void OnJumpScareExecution()
    {
        goingStarted = true;
        Tween t = DOTween.To(() => alpha, x => alpha = x, 0, 4f).OnComplete(() => mirrorImage.SetActive(false));

    }
}

