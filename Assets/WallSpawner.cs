using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour {

    public enum WallType
    {
        Straight,
        corner
    };
    GameObject wall;
    public WallType type;
	// Use this for initialization
	void Start () {
        switch (type)
        {
            case WallType.Straight:
                wall = (GameObject)Instantiate(Resources.Load("MurStright"), transform.position, transform.rotation);
                break;
            case WallType.corner:
                wall = (GameObject)Instantiate(Resources.Load("MurCorner"), transform.position, Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.z - 90.0f)));
                break;
            default:
                break;
        }
	}
}
