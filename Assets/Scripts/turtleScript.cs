using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleScript : MonoBehaviour {

   [Header("Atributes")]
    public float range = 10.0f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    [Header("EnemyStaff")]
    public Transform target;
    public string enemyTag = "Enemy";

    public GameObject bulletPref;
    public Transform SpawnPos;

    
    void Start()
    {
        InvokeRepeating("updateTarget",0.0f,0.5f);

        //nextShot = Time.time + fireRate;
    }


    void updateTarget()
    {
        GameObject[] oranges = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in oranges)
        {
            float distanceToenemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToenemy < shortestDistance)
            {
                shortestDistance = distanceToenemy;
                nearestEnemy = enemy;
            }

        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
            target = null;
    }
    void Update()
    {
        if (target == null)
            return;

        if (fireCountdown <= 0f)
        {
            shoot();
            fireCountdown = 1f / fireRate;

        }
        fireCountdown -= Time.deltaTime;
    
    }

    void shoot()
    {
        GameObject BulletGO  = (GameObject)Instantiate(bulletPref, SpawnPos.position, SpawnPos.rotation);
        bulletScript bullet = BulletGO.GetComponent<bulletScript>();

        if (bullet != null)
        {
            bullet.seek(target);
        }
        Debug.Log("Shoot!!");
    }

    private void OnDrawGizmosSelected() //Selectet para dibujar el gizmo de la selecionada, quitar selected para que aparezca siempre
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
