using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    float doorWidth = 3;
    private bool doorGo = false;
    public bool doorStatus = false; // true == otwarte, false == zamknięte
    void Start()
    {
        doorStatus = false;
    }

    public void OnTriggerEnter2D(Collider2D coll)
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
    }
    public void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && !doorStatus)
        {
            if (Input.GetKeyDown(KeyCode.E)) //drzwi otwiera i zamyka klawisz E
            {
                doorStatus = true;
                OpenDoor();
            }
        }
        if (coll.gameObject.tag == "Player" && doorStatus) //ten komunikat powinien się wyświetlić IFF drzwi zamknięte i gracz wbija w drzwi
        {

            if (Input.GetKeyDown(KeyCode.F)) //drzwi otwiera i zamyka klawisz E
            {
                doorStatus = false;
                CloseDoor();
            }
        }
    }

    public void OpenDoor()
    {
        GetComponent<AudioSource>().Play();
        transform.parent.Translate(new Vector3(-0.5f*doorWidth, 0, 0)); //zamiast 1.5 powinien być 0.5*szerokość_drzwiów, tutaj exampel
        transform.parent.Rotate(new Vector3(0, 0, 90f));
        // transform.parent.gameObject.GetComponent<Collider2D>().enabled = false;
        transform.parent.Translate(new Vector3(-0.5f*doorWidth, 0, 0));
    }
    public void CloseDoor()
    {
        transform.parent.Translate(new Vector3(0.5f * doorWidth, 0, 0));
        transform.parent.Rotate(new Vector3(0, 0, 270f));
        // transform.parent.gameObject.GetComponent<Collider2D>().enabled = false;
        transform.parent.Translate(new Vector3(0.5f * doorWidth, 0, 0));
    }
}
