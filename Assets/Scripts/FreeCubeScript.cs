using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCubeScript : MonoBehaviour
{

    public MapControllerScript controller;

    GameObject cube;


    void Start()
    {
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
