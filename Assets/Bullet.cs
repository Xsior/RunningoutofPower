using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float lifeTime = 10.0f;
    private float lifeTimer = 0;
    public void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(GameObject.FindWithTag("Player").transform.up * 1000000000.0f);
    }

    public void Update()
    {
        lifeTimer += Time.deltaTime;
        if(lifeTimer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

}
