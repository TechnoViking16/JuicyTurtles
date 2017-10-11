using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControllerScript : MonoBehaviour
{

    public GameObject freeBlock, pathBlock, rockBlock, backBlock, backTwo, spawn, turtle1, turtle2, turtle3, turtle4;
    enum state { FREE, PATHh, PATHv, PATHcu, PATHcd, ROCK }

    public int width, height,maxLife,currentLife, maxRocks, maxJuice, startingJuice, currentJuice,score, cost1, cost2, cost3, cost4;
    public float distance;
    state[,] location;
    RaycastHit hit;
    public bool button1 = false, button2 = false, button3 = false, button4 = false;
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

                switch (location[i, j])
                {
                    case state.FREE:
                        Instantiate(freeBlock, new Vector3(i * distance, Random.Range(0, 0.3f), j * distance), Quaternion.identity);
                        break;
                    case state.ROCK:
                        Instantiate(rockBlock, new Vector3(i * distance, Random.Range(0.3f,0.5f), j * distance), Quaternion.identity);
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
        lastY = height / 2;
        location[lastX, lastY] = state.PATHh;
        Instantiate(spawn, new Vector3(lastX, 1, lastY), Quaternion.identity);

    }

    void generatePath()
    {
        int perc;
        bool lastUp = true, lastDown = true, lastForward = false;

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
            else if (perc > 0 && perc < 3 && lastY != 1 && !lastUp)//Up
            {
                if (lastDown)
                    location[lastX, lastY] = state.PATHcd;
                else
                    location[lastX, lastY] = state.PATHv;
                lastY--;

                lastDown = true;
                lastForward = false;
            }
            else if (perc > 2 && perc < 5 && lastY != height - 2 && !lastDown)//Down
            {
                if (lastUp)
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

    void generateTurtle(Vector3 pos)
    {
        if (button1 && currentJuice >= cost1)
        {
            Instantiate(turtle1, pos + new Vector3(0, 1, 0), Quaternion.Euler(-90, 90, 0));
            currentJuice -= cost1;
        }
        else if (button2 && currentJuice >= cost2)
        {
            Instantiate(turtle2, pos + new Vector3(0, 1, 0), Quaternion.Euler(-90, 90, 0));
            currentJuice -= cost2;
        }
        else if (button3 && currentJuice >= cost3)
        {
            Instantiate(turtle3, pos + new Vector3(0, 1, 0), Quaternion.Euler(-90, 90, 0));
            currentJuice -= cost3;
        }
        else if (button4 && currentJuice >= cost4)
        {
            Instantiate(turtle4, pos + new Vector3(0, 1, 0), Quaternion.Euler(-90, 90, 0));
            currentJuice -= cost4;
        }
    }


    void generateRocks()
    {
        int x, y;
        int i = 0;
        while (i < maxRocks)
        {
            x = Random.Range(0, width);
            y = Random.Range(0, height);

            if (location[x, y] == state.FREE)
            {
                location[x, y] = state.ROCK;
                i++;
            }
        }
    }

    void ButtonPressed(int n)
    {
        switch (n)
        {
            case 1:
                button1 = true;
                break;

            case 2:
                button2 = true;
                break;
            case 3:
                button3 = true;
                break;
            case 4:
                button4 = true;
                break;

            default:
                break;
        }
    }

    void background()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Instantiate(backBlock, new Vector3(i  +width, Random.Range(-1, 2), j),Quaternion.identity);
                Instantiate(backBlock, new Vector3(i - width, Random.Range(-1, 2), j), Quaternion.identity);
                Instantiate(backBlock, new Vector3(i, Random.Range(-1, 2), j + height), Quaternion.identity);
				Instantiate(backTwo, new Vector3(i, Random.Range(-1, 1), j - height), Quaternion.identity);
				Instantiate(backBlock, new Vector3(i - width, Random.Range(-1, 2), j + height), Quaternion.identity);
				Instantiate(backBlock, new Vector3(i + width, Random.Range(-1, 2), j + height), Quaternion.identity);
				Instantiate(backTwo, new Vector3(i - width, Random.Range(-1, 1), j - height), Quaternion.identity);
				Instantiate(backTwo, new Vector3(i + width, Random.Range(-1, 1), j - height), Quaternion.identity);
            }
        }
    }
    void Start()
    {
        currentJuice = startingJuice;
        startMap();
        generatePath();
        generateRocks();
        printMap();
        background();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.cyan);





        if (Input.GetMouseButtonUp(1))
        {

            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.gameObject.CompareTag("turtle"))
                    hit.collider.gameObject.SendMessage("HitByRay");
            }
        }
    if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hit, 1000))
            {

                if (hit.collider.gameObject.CompareTag("cube") && button1 || button2 || button3 || button4)                    
                    hit.collider.gameObject.SendMessage("HitByRay");  
                }

            button1 = false;
            button2 = false;
            button3 = false;
            button4 = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 1000))
            {

                if (hit.collider.gameObject.CompareTag("Button"))
                    hit.collider.gameObject.SendMessage("HitByRay");

            }
        }
    }
}
