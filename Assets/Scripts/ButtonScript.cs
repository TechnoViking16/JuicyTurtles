using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {
    public MapControllerScript controller;
    public int number;
	
	void Start () {
		
	}

    void HitByRay()
    {
        controller.SendMessage("ButtonPressed", number);
    }
    // Update is called once per frame
    void Update () {


    }
}
