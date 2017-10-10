using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceTxt : MonoBehaviour {

    public MapControllerScript controller;
    
    void Start()
    {

    }

 
    void Update()
    {
        GetComponent<TextMesh>().text = controller.currentJuice.ToString();

    }
}
