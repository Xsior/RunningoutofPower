using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerForward : MonoBehaviour {



    public float speed = 500;


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

        Vector2 direction = transform.up * v + transform.right * h;
        GetComponent<Rigidbody2D>().velocity = ( direction * speed  * Time.deltaTime);
    }
    void Rotation()
    {
        Vector3 rotation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rot2d = new Vector3(rotation.x, rotation.y, rotation.z);
        transform.LookAt(rot2d, Vector3.back);
        transform.rotation = new Quaternion(0, 0, transform.rotation.z, transform.rotation.w);
    }


}
