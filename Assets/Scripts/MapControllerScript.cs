using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControllerScript : MonoBehaviour {

    public GameObject freeBlock,pathBlock;
    enum state { FREE, PATH, ROCK }
  
    public int width, height;
    public float distance;
    state[,] location;

    private int lastX, lastY;



    void printMap()
    {
        
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {

                switch (location[i, j]) {
                    case state.FREE:
                Instantiate(freeBlock, new Vector3(i * distance, 0, j * distance), Quaternion.identity);
                        break;

                    case state.PATH:
                Instantiate(pathBlock, new Vector3(i * distance, 0, j * distance), Quaternion.identity);
                        break;

                    default:
                        break;

            }


            }
        }
    }

    void startMap()
    {
        location = new state[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                location[i, j] = state.FREE;
            }
        }

        lastX = 0;
        lastY = 3;
        location[lastX, lastY] = state.PATH;

    }

    void generateMap()
    {
        int perc;
        bool lastUp = true, lastDown = true;

        while (lastX < width - 1)
        {
            perc = Random.Range(0, 5);

            if (perc == 0)//Forward
            {
                location[lastX, lastY] = state.PATH;
                lastX++;
                lastUp = false;
                lastDown = false;
            }
            else if (perc >0 && perc < 3 && lastY != 0 && !lastUp)//Up
            {
                location[lastX, lastY] = state.PATH;
                lastY--;

                lastDown = true;
            }
            else if (perc > 2 && perc < 5  && lastY != height - 1 && !lastDown)//Down
            {

                location[lastX, lastY] = state.PATH;
                lastY++;
                lastUp = true;
            }
        }

        location[lastX, lastY] = state.PATH;
    }




    void Start () {




        startMap();
        generateMap();
        printMap();

        
	}
	
	// Update is called once per frame
	void Update () {
		


	}
}
