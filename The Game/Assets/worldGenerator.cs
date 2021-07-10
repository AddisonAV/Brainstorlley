using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class worldGenerator : MonoBehaviour
{
    public GameObject wall;
    public GameObject trap;
    public GameObject ground;
    public GameObject bottonWall;

    public GameObject[] enviroment = new GameObject[6];

    private int TABLESIZE = 100;

    Vector3 offset;
    // Start is called before the first frame update
    void Start(){

        int toSpawn;
        int i;
        offset*=0;
        offset[1] -= 2f;
        offset[0] -= 1.5f;
        for(i = 0; i < Math.Sqrt(TABLESIZE)+2; i++)
        {
            offset[1] += 1.5f;
            Instantiate(wall, offset, wall.transform.rotation);
        }

        for (i = 0; i < Math.Sqrt(TABLESIZE) + 1; i++)
        {
            offset[0] += 1.5f;
            Instantiate(wall, offset, wall.transform.rotation);
        }

        for (i = 0; i < Math.Sqrt(TABLESIZE) + 1; i++)
        {
            offset[1] -= 1.5f;
            Instantiate(wall, offset, wall.transform.rotation);
        }
        offset[1] += 0.5f;
        for (i = 0; i < Math.Round(Math.Sqrt(TABLESIZE)); i++)
        {
            offset[0] -= 1.5f;
            Instantiate(bottonWall, offset, bottonWall.transform.rotation);
        }

        System.Random random = new System.Random();
        //spawn the enviroment

        int enviromentSize = TABLESIZE * 5;
        int sqrtEnv = (int)(Math.Sqrt(enviromentSize));
        offset[0] = -12;
        offset[1] = -12;
        Debug.Log(Math.Sqrt(enviromentSize));
        for (i = 0; i < enviromentSize; i++)
        {
            toSpawn = random.Next(6);

            if (i % sqrtEnv == 0)
            {
                offset[0] = -12;
                offset[1] += 2f;
            }

            Instantiate(enviroment[toSpawn], offset, ground.transform.rotation);
            offset[0] += 2f;

        }

        offset = ground.transform.position;
        


        for(i = 0; i < TABLESIZE; i++){
            toSpawn = random.Next(2);

            if (i % (Math.Sqrt(TABLESIZE)) == 0){
                offset[0] = 0;
                offset[1] += 1.5f;
            }
            if(toSpawn == 0 || i == 0){
                Instantiate(ground, offset, ground.transform.rotation);
                offset[0] += 1.5f;
            }
            else{
                Instantiate(ground, offset, ground.transform.rotation);
                Instantiate(trap, offset, trap.transform.rotation);
                offset[0] += 1.5f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
