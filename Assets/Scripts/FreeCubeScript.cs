using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCubeScript : MonoBehaviour
{

    public MapControllerScript controller;



    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
		rend.material.SetColor("_Color", new Color(Random.Range(0f, 50f) / 255f, Random.Range(200f, 255f) / 255f, Random.Range(30f,150f) / 255f, 1));


        controller = GameObject.FindObjectOfType<MapControllerScript>();
    }

    void HitByRay()
    {
       
            controller.SendMessage("generateTurtle", transform.position);
         
    }

    void Update()
    {
       



    }
}
