using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareController : MonoBehaviour
{
    bool jumpsScareDone = false;
    AudioSource audioSource;
	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!jumpsScareDone)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                jumpsScareDone = true;
                audioSource.Play();
                collision.gameObject.GetComponent<PlayerController>().sanityContr.DealSanityDamage(5f);

            }

        }
    }
}
