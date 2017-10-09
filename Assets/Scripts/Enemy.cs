using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int life;
    public float moveSpeed;
    private float check;
    public MapControllerScript controller;

    private int currentX, currentY;
    private bool up = false, down = false, forward = false;



    void Start() {
        controller = GameObject.FindObjectOfType<MapControllerScript>();
        check = 0;
        currentX = 0;
        currentY = 3;

    }

    // Update is called once per frame
    void Update()
    {

        if (check <= 1)//Mientras se mueve
        {
            
            if(forward)
            transform.position += new Vector3(moveSpeed, 0, 0);
            else if(up)
            transform.position += new Vector3(0, 0, moveSpeed);
            else if(down)
            transform.position += new Vector3(0, 0, -moveSpeed);

            check += moveSpeed;
        }
        else//Cambiar direccion
        {
            forward = false;
            up = false;
            down = false;

            if (controller.getLoc(currentX + 1, currentY))
            {
                forward = true;
                check = 0;
                currentX++;
                Debug.Log("For");
            }
            else if (controller.getLoc(currentX, currentY + 1))
            {
                up = true;
                check = 0;
                currentY++;
                Debug.Log("Up");
            }
            else if (controller.getLoc(currentX, currentY - 1))
            {
                down = true;
                check = 0;
                currentY--;
                Debug.Log("Down");
            }
            else
                Debug.Log(controller.getLoc(currentX, currentY));


        }

    }
}
