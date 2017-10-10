using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject enemyOrange, enemyBig, enemyGiant, enemySmall;
    public float spawnRate = 1.0f;
    float nextSpawn;
    void Start ()
    {
        spawnEnemy();
        nextSpawn = Time.time + spawnRate;
    }

    void Update ()
    {
        if(Time.time > nextSpawn)
        {
            spawnEnemy();
            nextSpawn += spawnRate;

        }
    }
    void spawnEnemy()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                     Instantiate(enemyBig, transform.position, Quaternion.Euler(-90, 180, 0));
                break;
            case 1:
                
                     Instantiate(enemySmall, transform.position, Quaternion.Euler(-90, 180, 0));
                break;
            case 2:
                
                     Instantiate(enemyOrange, transform.position, Quaternion.Euler(-90, 180, 0));
                break;
            case 3:
                
                     Instantiate(enemyGiant, transform.position, Quaternion.Euler(-90, 180, 0));
                break;

            default:
                break;
        }

    }
}
