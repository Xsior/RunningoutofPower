using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundJumpScare : JumpScareBase
{
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        
	}
    

    public override void OnJumpScareExecution()
    {
        if (collidedObject.gameObject.CompareTag("Player"))
        {
            jumpsScareDone = true;
            audioSource.Play();
            collidedObject.gameObject.GetComponent<PlayerController>().sanityContr.DealSanityDamage(5f);
        }
    }
}
