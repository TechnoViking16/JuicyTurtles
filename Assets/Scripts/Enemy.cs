using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int life;
    public float moveSpeed;
    private float check;
    public MapControllerScript controller;

    private int currentX, currentY;
    private bool up = false, down = false, forward = false, prevDown = false;



    void Start() {
        controller = GameObject.FindObjectOfType<MapControllerScript>();
        check = 2;
        currentX = 0;
        currentY = controller.height/2;

    }

    // Update is called once per frame
    void Update()
    {
        if (check > 1)
        {
            //Escojer direccion
            forward = false;
            up = false;
            down = false;

            if (controller.getLoc(currentX + 1, currentY))
            {
                forward = true;
                check = 0;
                currentX++;
                prevDown = false;
            }
            else if (controller.getLoc(currentX, currentY + 1) && !prevDown)
            {
                up = true;
                check = 0;
                currentY++;
                prevDown = false;
            }
            else if (controller.getLoc(currentX, currentY - 1))
            {
                down = true;
                check = 0;
                currentY--;
                prevDown = true;
            }
        
        }
        else //Mientras se mueve
        {
            
            if(forward)
            transform.position += new Vector3(moveSpeed, 0, 0);
            else if(up)
            transform.position += new Vector3(0, 0, moveSpeed);
            else if(down)
            transform.position += new Vector3(0, 0, -moveSpeed);

            check += moveSpeed;
        }
    }
}
