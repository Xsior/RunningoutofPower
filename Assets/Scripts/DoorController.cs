using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int keyNeeded = 0;
    float doorWidth = 3;
    private bool doorGo = false;
    public bool doorStatus = false; // true == otwarte, false == zamknięte
    float smallTimer = 0;
    public GameObject UIText;
    public GameObject red,blue,green,gold;

    [SerializeField] private Sprite opened, closed;
    void Start()
    {
        doorStatus = false;
    }
    private void Update()
    {
        if (smallTimer > 0)
            smallTimer -= Time.deltaTime;

        if(keyNeeded == 1 && doorStatus == true)
        {
            red.SetActive(false);
        }
        if (keyNeeded == 2 && doorStatus == true)
        {
            gold.SetActive(false);
        }
        if (keyNeeded == 3 && doorStatus == true)
        {
            green.SetActive(false);
        }
        if (keyNeeded == 4 && doorStatus == true)
        {
            blue.SetActive(false);
        }
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
                UIText.GetComponent<Text>().text = "Press E to close doors";
                UIText.SetActive(true);
                if (Input.GetButtonDown("E")) //drzwi otwiera i zamyka klawisz E
                {
                    smallTimer = 0.15f;
                    doorStatus = false;
                    CloseDoor();
                }
            }
            else if (smallTimer <= 0 && coll.gameObject.tag == "Player" && !doorStatus)
            {
                UIText.GetComponent<Text>().text = "Press E to open doors";
                UIText.SetActive(true);
                if (Input.GetButtonDown("E")) //drzwi otwiera i zamyka klawisz E
                {
                    smallTimer = 0.15f;
                    doorStatus = true;
                    OpenDoor();
                }
            }

        }
        else
        {
            if(coll.tag == "Player")
            {
                UIText.GetComponent<Text>().text = "You need key to open";
                UIText.SetActive(true);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            UIText.SetActive(false);
        }
    }

    public void OpenDoor()
    {
        GetComponent<AudioSource>().Play();
        transform.parent.Find("GameObject (1)").GetComponent<SpriteRenderer>().sprite = opened;
        transform.parent.Find("GameObject (2)").GetComponent<SpriteRenderer>().sprite = opened;
        transform.parent.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void CloseDoor()
    {
        transform.parent.Find("GameObject (1)").GetComponent<SpriteRenderer>().sprite = closed;
        transform.parent.Find("GameObject (2)").GetComponent<SpriteRenderer>().sprite = closed;
        transform.parent.GetComponent<BoxCollider2D>().enabled = true;
    }
}
