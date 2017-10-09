using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleScript : MonoBehaviour {

    public Transform target;
    public float range = 10.0f;
    public string enemyTag = "Enemy";

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
    }
    void Update()
    {
        if (target == null)
            return;

    
    }

    private void OnDrawGizmosSelected() //Selectet para dibujar el gizmo de la selecionada, quitar selected para que aparezca siempre
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
