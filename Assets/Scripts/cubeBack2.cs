using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeBack2 : MonoBehaviour {

	float y,speed;
	bool inc;

	void Start () {
		Renderer rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", new Color(Random.Range(240f, 255f) / 255f, Random.Range(70f, 150f) / 255f, 0f / 255f, 1));

        if (Random.Range (0, 2) == 0)
			inc = true;
		else
			inc = false;
		
		speed = Random.Range (0.0025f, 0.01f);

	}


	void Update () {

		if (y > 0)
			inc = false;
		if (y < -0.5)
			inc = true;

		if (inc)
			y += speed;
		else
			y -= speed;

		transform.position = new Vector3(transform.position.x,y,transform.position.z);

	}
}
