using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public List<Transform> enemies = new List<Transform>();
    public List<Transform> activeEnemies = new List<Transform>();
    private Transform player;


    private void Start()
    {
        player = GameObject.Find("Player").transform;
        foreach (Transform child in transform)
            enemies.Add(child);
    }


    public void SpawanEnemy(Vector3 pos)
    {
        Debug.Log("Hi");
        foreach(Transform t in enemies)
        {
            if(t.gameObject.activeSelf == false)
            {
                t.parent = player;
                Debug.Log("spawning");
                t.position = pos;
                t.GetComponent<EnemyController>().ResetForSpawn();
                activeEnemies.Add(t);
                t.gameObject.SetActive(true);
                t.parent = transform;
                break;
            }
        }
    }
    public void Kill(Transform enemy)
    {
        enemy.gameObject.SetActive(false);
        activeEnemies.Remove(enemy);

    }
    public int enemyCount()
    {
        return activeEnemies.Count;
    }
}
