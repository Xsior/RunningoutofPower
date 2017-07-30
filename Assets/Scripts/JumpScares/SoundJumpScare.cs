using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundJumpScare : JumpScareBase
{
    float volume = 1f;
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        audioSource.volume = volume;

    }
    

    public override void OnJumpScareExecution()
    {
        if (collidedObject.gameObject.CompareTag("Player"))
        {
            jumpsScareDone = true;
            audioSource.Play();
            collidedObject.gameObject.GetComponent<PlayerController>().sanityContr.DealSanityDamage(4f);

            Tween t = DOTween.To(() => volume, x => volume = x, 0, 6f);
        }
    }
}
