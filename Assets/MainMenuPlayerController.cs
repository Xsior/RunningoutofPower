using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPlayerController : MonoBehaviour
{

    float rotationTimer;
    Quaternion InitialRotation;
    float rand;
    // Use this for initialization
    void Start()
    {
        InitialRotation = transform.rotation;
        rand = Random.Range(-10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        rotationTimer += Time.deltaTime;
        rotationTimer = Mathf.PingPong(rotationTimer, 1);
        if(rotationTimer < 0.01f || rotationTimer > 0.99f)
        {
            rand = Random.Range(-10, 10);
            InitialRotation = transform.rotation;
        }
        transform.rotation = Quaternion.Lerp(InitialRotation, Quaternion.Euler(InitialRotation.eulerAngles.x, InitialRotation.eulerAngles.y, InitialRotation.eulerAngles.z + rand), rotationTimer);
    }
}
