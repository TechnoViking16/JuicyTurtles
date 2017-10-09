using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeRockScript : MonoBehaviour {
    public GameObject rock; 
	// Use this for initialization
	void Start () {

        Instantiate(rock, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
