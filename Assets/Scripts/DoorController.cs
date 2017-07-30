using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int keyNeeded = 0;
    float doorWidth = 3;
    private bool doorGo = false;
    public bool doorStatus = false; // true == otwarte, false == zamknięte
    float smallTimer = 0;
    void Start()
    {
        doorStatus = false;
    }
    private void Update()
    {
        if (smallTimer > 0)
            smallTimer -= Time.deltaTime;
    }
    /* public void OnTriggerEnter2D(Collider2D coll)
     {

         if (coll.gameObject.tag == "Player" && !doorStatus) //ten komunikat powinien się wyświetlić IFF drzwi zamknięte i gracz wbija w drzwi
         {

             if (Input.GetKeyDown(KeyCode.E)) //drzwi otwiera i zamyka klawisz E
             {
                 doorStatus = !doorStatus;
                 OpenDoor();
             }
         }
         if (coll.gameObject.tag == "Player" && doorStatus) //ten komunikat powinien się wyświetlić IFF drzwi zamknięte i gracz wbija w drzwi
         {

             if (Input.GetKeyDown(KeyCode.F)) //drzwi otwiera i zamyka klawisz F
             {
                 doorStatus = !doorStatus;
                 CloseDoor();
             }
         }
     }*/
    public void OnTriggerStay2D(Collider2D coll)
    {
        if (keyNeeded == 0 || KeyCollector.CheckForKey(keyNeeded))
        {
            if (smallTimer <= 0 && coll.gameObject.tag == "Player" && doorStatus) //ten komunikat powinien się wyświetlić IFF drzwi zamknięte i gracz wbija w drzwi
            {

                if (Input.GetButtonDown("E")) //drzwi otwiera i zamyka klawisz E
                {
                    smallTimer = 0.15f;
                    doorStatus = false;
                    CloseDoor();
                }
            }
            else if (smallTimer <= 0 && coll.gameObject.tag == "Player" && !doorStatus)
            {
                if (Input.GetButtonDown("E")) //drzwi otwiera i zamyka klawisz E
                {
                    smallTimer = 0.15f;
                    doorStatus = true;
                    OpenDoor();
                }
            }

        }
    }

    public void OpenDoor()
    {
        GetComponent<AudioSource>().Play();
        transform.parent.Translate(new Vector3(-0.5f * doorWidth, 0, 0)); //zamiast 1.5 powinien być 0.5*szerokość_drzwiów, tutaj exampel
        transform.parent.Rotate(new Vector3(0, 0, 90f));
        // transform.parent.gameObject.GetComponent<Collider2D>().enabled = false;
        transform.parent.Translate(new Vector3(-0.5f * doorWidth, 0, 0));
    }
    public void CloseDoor()
    {
        transform.parent.Translate(new Vector3(0.5f * doorWidth, 0, 0));
        transform.parent.Rotate(new Vector3(0, 0, 270f));
        // transform.parent.gameObject.GetComponent<Collider2D>().enabled = false;
        transform.parent.Translate(new Vector3(0.5f * doorWidth, 0, 0));
    }
}
