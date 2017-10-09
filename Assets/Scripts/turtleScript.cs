using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleScript : MonoBehaviour {

    public GameObject bullet;
    public GameObject target;
    public float fireRate = 5.0f;
    public float speed;
    float nextShot;

   

    void Start()
    {
        nextShot = Time.time + fireRate;
    }

    void Update()
    {

        if (Time.time > nextShot)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextShot = Time.time + fireRate;
            float distance = Vector3.Distance(transform.position, target.transform.position);
            float moduloVector = Mathf.Sqrt(Mathf.Pow(target.transform.position.x - transform.position.x, 2) + Mathf.Pow(transform.position.y - transform.position.y, 2) + Mathf.Pow(transform.position.z - transform.position.z, 2));

            float unitX = (target.transform.position.x - transform.position.x) / distance;
            float unitY = (target.transform.position.z - transform.position.z) / distance;

            bullet.transform.position = new Vector3((unitX * speed + target.transform.position.x), target.transform.position.y, (unitY * speed + target.transform.position.z));
        }
    }
}
