using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{




    public float speed = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

    }


    void HandleInput()
    {
        Movement();
        Rotation();

    }
    void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (v == 0 && h == 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        
        Vector2 direction = new Vector3(h, v).normalized;
        GetComponent<Rigidbody2D>().velocity = (direction * speed * 50 * Time.deltaTime);
    }
    void Rotation()
    {
        Vector3 rotation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rot2d = new Vector3(rotation.x, rotation.y, rotation.z);
        transform.LookAt(rot2d, Vector3.back);
        transform.rotation = new Quaternion(0,0, transform.rotation.z, transform.rotation.w);
    }


}

