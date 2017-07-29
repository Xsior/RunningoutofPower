using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {




    public float speed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleInput();

    }


    void HandleInput()
    {
        Movement();


    }
    void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if(v == 0 && h == 0){
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        Debug.Log(h + " " + v);
        Vector2 direction = new Vector3(h, v).normalized;
        GetComponent<Rigidbody2D>().velocity = (direction * speed * 50 * Time.deltaTime);
    }
    void HandleRotation()
    {
        


    }
}
