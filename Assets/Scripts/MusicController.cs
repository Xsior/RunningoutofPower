using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MusicController : MonoBehaviour
{
    [SerializeField]
    AudioSource ambient;
    [SerializeField]
    AudioSource insane;

    float ambientVolume = 1f;
    float insaneVolume = 0f;

    SanityController sanityContr;

    float lastFrameSanity = 100f;
    float currentFrameSanity = 100f;
	// Use this for initialization
	void Start ()
    {
        sanityContr = GameObject.FindGameObjectWithTag("Player").GetComponent<SanityController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        ambient.volume = ambientVolume;
        insane.volume = insaneVolume;

        lastFrameSanity = currentFrameSanity;
        currentFrameSanity = sanityContr.CurrentSanity;

        if(lastFrameSanity >= 50 && currentFrameSanity < 50)
        {
            changeTracks(false);
        }
        else if (lastFrameSanity < 50 && currentFrameSanity >= 50)
        {
            changeTracks(true);
        }
    }

    void changeTracks(bool forGood)
    {
        if(forGood)
        {
            Tween u = DOTween.To(() => insaneVolume, x => insaneVolume = x, 0, 3f);
            Tween t = DOTween.To(() => ambientVolume, x => ambientVolume = x, 1, 3f);
        }
        else
        {
            Tween t = DOTween.To(() => ambientVolume, x => ambientVolume = x, 0, 3f);
            Tween u = DOTween.To(() => insaneVolume, x => insaneVolume = x, 1, 3f);
        }
        
    } 
}
