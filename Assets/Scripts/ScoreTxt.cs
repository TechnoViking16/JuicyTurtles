using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTxt : MonoBehaviour {

    public MapControllerScript controller;


    void Start()
    {

    }


    void Update()
    {
        GetComponent<Text>().text = "Score: " +controller.score.ToString();

    }
}

