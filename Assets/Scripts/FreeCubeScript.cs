using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCubeScript : MonoBehaviour
{

    public MapControllerScript controller;
	Color startColor;
	Renderer rend;


    void Start()
    {
		startColor = new Color (Random.Range (0f, 50f) / 255f, Random.Range (200f, 255f) / 255f, Random.Range (30f, 150f) / 255f, 1);
        rend = GetComponent<Renderer>();

		rend.material.SetColor("_Color",startColor);

        controller = GameObject.FindObjectOfType<MapControllerScript>();
    }

	void OnMouseEnter()
	{
	
		rend.material.SetColor("_Color",new Color (255, 255, 0, 1));
	
	}

	void OnMouseExit(){
		rend.material.SetColor("_Color",startColor);
	}

    void HitByRay()
    {
       
        controller.SendMessage("generateTurtle", transform.position);
         
    }

    void Update()
    {
		



    }
}
