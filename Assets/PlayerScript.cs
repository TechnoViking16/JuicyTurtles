using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    RaycastHit hit;

    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.cyan);

        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hit, 1000)){
                Debug.Log("AIII");
                if (hit.collider.gameObject.tag == "cube")
                {
                  
                    hit.collider.gameObject.SendMessage("HitByRay");
                }
                // if (Physics.Raycast(transform.position, -Vector3.up, out hit))
              // hit.transform.SendMessage("HitByRay");
            }
        }
    }
}
