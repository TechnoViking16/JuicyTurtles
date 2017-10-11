using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject enemyOrange, enemyBig, enemyGiant, enemySmall;
    public float spawnRate;
    float nextSpawn;
    void Start ()
    {
        //spawnEnemy();
        nextSpawn = Time.time + spawnRate;
    }

    void Update ()
    {
        if(Time.time > nextSpawn)
        {
            //EnemySmall();
            //spawnEnemy();
            nextSpawn += spawnRate;
        }
    }

    void EnemySmall()
    {
            Instantiate(enemySmall, transform.position + new Vector3(0, 0.25f, 0), Quaternion.Euler(-90, 180, 0));
    }

    void spawnEnemy()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
			Instantiate(enemyBig, transform.position + new Vector3(0,0.6f,0), Quaternion.Euler(-90, 180, 0));
                break;
            case 1:
                
			Instantiate(enemySmall, transform.position + new Vector3(0,0.25f,0), Quaternion.Euler(-90, 180, 0));
                break;
            case 2:
                
			Instantiate(enemyOrange, transform.position + new Vector3(0,0.4f,0), Quaternion.Euler(-90, 180, 0));
                break;
            case 3:
                
			Instantiate(enemyGiant, transform.position + new Vector3(0,0.9f,0), Quaternion.Euler(-90, 180, 0));
                break;

            default:
                break;
        }
    }
}
