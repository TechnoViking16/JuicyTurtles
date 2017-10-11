using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JuiceTxt : MonoBehaviour {

    public MapControllerScript controller;
  

    void Start()
    {

    }

 
    void Update()
    {
        GetComponent<Text>().text = controller.currentJuice.ToString();

    }
}
