using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float life;
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
        if (currentX < controller.width - 1)
        {
            if (life > 0)
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
                        //Debug.Log("For");
                        prevDown = false;
                    }
                    else if (controller.getLoc(currentX, currentY + 1) && !prevDown)
                    {
                        up = true;
                        check = 0;
                        currentY++;
                        //Debug.Log("Up");
                        prevDown = false;
                    }
                    else if (controller.getLoc(currentX, currentY - 1))
                    {
                        down = true;
                        check = 0;
                        currentY--;
                        //Debug.Log("Down");
                        prevDown = true;
                    }



                }
                else //Mientras se mueve
                {

                    if (forward)
                        transform.position += new Vector3(moveSpeed, 0, 0);
                    else if (up)
                        transform.position += new Vector3(0, 0, moveSpeed);
                    else if (down)
                        transform.position += new Vector3(0, 0, -moveSpeed);

                    check += moveSpeed;
                }
            }
            else//Muere
            {
                Destroy(gameObject);
            }
        }
        

        else//LLega al final
        {
            Destroy(gameObject);
        }
    }
}
