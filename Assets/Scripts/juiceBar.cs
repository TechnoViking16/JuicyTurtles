using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juiceBar : MonoBehaviour {

	public MapControllerScript controller;

	void Start () {
		
	}

	void Update () {

		transform.localScale = new Vector3 (0.5f + 0.5f*((float)controller.currentJuice/(float)controller.maxJuice), 0.8f*((float)controller.currentJuice/(float)controller.maxJuice), transform.localScale.z);



	}
}
