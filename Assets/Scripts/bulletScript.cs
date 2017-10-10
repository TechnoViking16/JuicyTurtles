using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

    private Transform target;
    public float speed = 50;

    public GameObject ImpactEffect;

    public void seek (Transform _target)
    {
        target = _target;

    }

	// Update is called once per frame
	void Update ()
    {
	    if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceFrame, Space.World);
	}

    void HitTarget()
    {
        GameObject effect = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effect,1f);
        Destroy(gameObject);
        Debug.Log("HIT");
    }

}
