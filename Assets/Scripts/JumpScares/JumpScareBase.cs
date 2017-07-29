using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareBase : MonoBehaviour
{
    protected bool jumpsScareDone = false;
    protected AudioSource audioSource;
    protected Collider2D collidedObject;
    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!jumpsScareDone)
        {
            collidedObject = collision;
            OnJumpScareExecution();

        }
    }

    public virtual void OnJumpScareExecution()
    {

    }
}
