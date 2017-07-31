using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerCont;

    public GameObject[] enemies;

    bool deathDone = false;
	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCont = player.GetComponent<PlayerController>();

        playerCont.GetComponent<SanityController>().OnDeath += PlayerCont_OnDeath;
    }

    private void PlayerCont_OnDeath(object sender, System.EventArgs e)
    {
        if(!deathDone)
        {
            StartCoroutine(DeathScene());
            deathDone = true;
            player.GetComponent<LightsController>().SetBattery(0);
        }
    }

    private IEnumerator DeathScene()
    {
        player.transform.position = new Vector2(-45, -15);
        playerCont.walkingDisabled = true;
        transform.position = player.transform.position;
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(true);
        }

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<DeathScriptedEnemyController>().ChasePlayer();
            enemy.GetComponent<DeathScriptedEnemyController>().attacked = true;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(3f);
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
