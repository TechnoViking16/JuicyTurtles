using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject enemyOrange;
    public float timer;
    public float spawnRate = 5.0f;
    float nextSpawn;
    void Start ()
    {
        nextSpawn = Time.time + spawnRate;
    }

	void Update ()
    {
       

        

        if(Time.time > nextSpawn)
        {
            Instantiate(enemyOrange, transform.position, Quaternion.identity);
            nextSpawn += spawnRate;

        }
	}
}
