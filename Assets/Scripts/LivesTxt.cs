using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesTxt : MonoBehaviour {
    public MapControllerScript controller;


    void Start()
    {

    }


    void Update()
    {
        GetComponent<Text>().text = "Life: " + controller.currentLife.ToString();

    }
}

