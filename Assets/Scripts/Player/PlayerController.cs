using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float currentHp;

    private Animator anim;

    Vector3 mousePoint;
    public float speed = 10;
    public SanityController sanityContr;

 

    // Use this for initialization
    void Start()
    {
        sanityContr = GetComponent<SanityController>();
        anim = GetComponent<Animator>();
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
            anim.SetBool("isWalking", false);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
        Vector2 direction = new Vector3(h, v).normalized;
        GetComponent<Rigidbody2D>().velocity = (direction * speed * 50 * Time.deltaTime);
    }
    void Rotation()
    {
        if (mousePoint == null)
        {
            mousePoint = Input.mousePosition;
        }
        if (Vector3.Distance(mousePoint, Input.mousePosition) > 0.0001f)
        {
            mousePoint = Input.mousePosition;
            Vector3 rotation = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.LookAt(rotation, Vector3.back);
            transform.rotation = new Quaternion(0, 0, transform.rotation.z, transform.rotation.w);
        }

    }


}

