using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeRockScript : MonoBehaviour {
    public GameObject rock; 

	void Start () {

        Renderer rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", new Color(Random.Range(80f,160f) / 255f, 0f / 255f, 255f / 255f, 1));
	}
 
    void Update () {
		
	}
}
