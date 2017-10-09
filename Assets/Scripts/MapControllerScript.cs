using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControllerScript : MonoBehaviour {

    public GameObject freeBlock,pathBlock,rockBlock,spawn;
    enum state { FREE, PATHh, PATHv,PATHcu,PATHcd, ROCK }
  
    public int width, height,maxRocks;
    public float distance;
    state[,] location;

   public int lastX, lastY;


    public bool getLoc(int x, int y)
    {

        if (location[x, y] == state.FREE || location[x, y] == state.ROCK)
            return false;
        else
            return true;
    }
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
                    case state.ROCK:
                        Instantiate(rockBlock, new Vector3(i * distance, 0, j * distance), Quaternion.identity);
                        break;

                    case state.PATHh:
                    case state.PATHv:
                    case state.PATHcu:
                    case state.PATHcd:
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
        lastY = height/2;
        location[lastX, lastY] = state.PATHh;
        Instantiate(spawn, new Vector3(lastX, 1, lastY),Quaternion.identity);

    }

    void generatePath()
    {
        int perc;
        bool lastUp = true, lastDown = true, lastForward= false;

        while (lastX < width - 1)
        {
            perc = Random.Range(0, 5);

            if (perc == 0)//Forward
            {
                location[lastX, lastY] = state.PATHh;
                lastX++;
                

                if (lastForward)
                {
                    lastUp = false;
                    lastDown = false;
                }

                lastForward = true;
            }
            else if (perc >0 && perc < 3 && lastY != 1 && !lastUp)//Up
            {
                if (lastDown)
                    location[lastX, lastY] = state.PATHcd;
                else
                location[lastX, lastY] = state.PATHv;
                lastY--;

                lastDown = true;
                lastForward = false;
            }
            else if (perc > 2 && perc < 5  && lastY != height - 2 && !lastDown)//Down
            {
                if(lastUp)
                    location[lastX, lastY] = state.PATHcu;
                else
                location[lastX, lastY] = state.PATHv;

                lastY++;
                lastUp = true;
                lastForward = false;
            }
        }

        location[lastX, lastY] = state.PATHh;
    }


    void generateRocks()
    {
        int x, y;
        int i = 0;
        while (i < maxRocks)
        {
            x = Random.Range(0, width);
            y = Random.Range(0, height);

            if(location[x,y] == state.FREE)
            {
                location[x, y] = state.ROCK;
                i++;
            }

        }

    }

    void Start () {




        startMap();
        generatePath();
        //generateRocks();
        printMap();

        
	}
	
	// Update is called once per frame
	void Update () {
		


	}
}
