using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject enemyOrange, enemyBig, enemyGiant, enemySmall;
    public float spawnRate;
    int perS, perN, perB, perG, totalEnemyCount =0, waveEnemyCount = 10 ,waveCount = 0 , aux;
    float nextSpawn;
    void Start ()
    {
        //spawnEnemy();
        nextSpawn = Time.time + spawnRate;
        aux = waveEnemyCount;
    }

    void Update ()
    {
        
        if(Time.time > nextSpawn)
        {
            Waves(waveCount);
            _spawnEnemy();
            nextSpawn += spawnRate;
            totalEnemyCount++;
        }

        if(totalEnemyCount == aux)
        {
            waveCount++;
        }
    }

    void EnemySmall()
    {
        Instantiate(enemySmall, transform.position + new Vector3(0, 0.25f, 0), Quaternion.Euler(-90, 180, 0));
    }

    void EnemyNormal()
    {
        Instantiate(enemyOrange, transform.position + new Vector3(0, 0.4f, 0), Quaternion.Euler(-90, 180, 0));

    }

    void EnemyBig()
    {
        Instantiate(enemyBig, transform.position + new Vector3(0, 0.6f, 0), Quaternion.Euler(-90, 180, 0));

    }

    void EnemyGiant()
    {
        Instantiate(enemyGiant, transform.position + new Vector3(0, 0.9f, 0), Quaternion.Euler(-90, 180, 0));

    }

    void Waves(int n)
    {
        switch (n)
        {
            case 0:
                perS = 70;
                perN = 30;
                perB = 0;
                perG = 0;

                break;

            case 1:
                perS = 60;
                perN = 30;
                perB = 10;
                perG = 0;

                break;

            case 2:
                perS = 40;
                perN = 30;
                perB = 30;
                perG = 0;

                break;

            case 3:
                perS = 40;
                perN = 30;
                perB = 20;
                perG = 10;

                break;


            default:
                perS = 30;
                perN = 30;
                perB = 30;
                perG = 10;

                break;

        }
    }


    void _spawnEnemy()
    {
        int r = Random.Range(0, 100);

            if (r < perS)
                EnemySmall();
            else if (r >= perS && r < (perS + perN))
                EnemyNormal();
            else if (r >= perN+ perS && r < perS + perB + perN)
                EnemyBig();
            else if (r >=perB+ perG+perB)
                EnemyGiant();


        
        

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
