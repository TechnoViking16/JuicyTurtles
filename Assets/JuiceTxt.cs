using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceTxt : MonoBehaviour {

    public MapControllerScript controller;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMesh>().text = controller.currentJuice.ToString();

    }
}
