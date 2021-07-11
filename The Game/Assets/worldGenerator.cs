using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class worldGenerator : MonoBehaviour
{
    public GameObject trap;
    public GameObject ground;
    public GameObject[] walls = new GameObject[8];
    public GameObject[] wallSorroundings = new GameObject[12];
    public GameObject[] enviroment = new GameObject[6];

    private int fieldWidth = 10;
    private int fieldHeight = 5;
    public int difficulty = 2;

    Vector3 offset;
    // Start is called before the first frame update
    void Start(){
        int toSpawn;
        int i, k;
        System.Random random = new System.Random();
        int diffConstant;

        //setting fiedsize based on the difficulty

        //middle map, 50% chance of bomb spawn
        if (difficulty == 1)
        {
            diffConstant = 1;
            fieldWidth = 15;
            fieldHeight = 10;
        }
        //big map, 66% chance of bomb spawn
        else if (difficulty == 2)
        {
            diffConstant = 1;
            fieldWidth = 20;
            fieldHeight = 15;
        }
        //GRAMDE map, 50% chance of bomb spawn
        else{
            diffConstant = 0;
            fieldWidth = 30;
            fieldHeight = 20;
        }

        
        //spawn the bomb field
        offset = ground.transform.position;
        offset[0] = 0;
        offset[1] += 1.5f;

        for (k = 0; k < fieldHeight; k++)
        {
            for (i = 0; i < fieldWidth; i++)
            {
   
                toSpawn = random.Next(difficulty + diffConstant);

                //difficulty equals 1 or 3-> 50% chance of spawning a trap
                //difficulty equals 2 -> 66% chance of spawning a trap
                if (toSpawn == 0 || (i == 0 && k == 0))
                {
                    Instantiate(ground, offset, ground.transform.rotation);
                    offset[0] += 1.5f;
                }
                else
                {
                    Instantiate(ground, offset, ground.transform.rotation);
                    Instantiate(trap, offset, trap.transform.rotation);
                    offset[0] += 1.5f;
                }

            }
            offset[1] += 1.5f;
            offset[0] = 0;
        }
        offset *=0;

        // ----------------------- BEGIN DO NOT CHANGE -------------------------------------
        //spawn enviroment and walls

        //spawn left walls
        offset[0] -= 3f;
        Instantiate(wallSorroundings[8], offset, trap.transform.rotation);
        offset[0] += 1.5f;
        for (i = 0; i < fieldHeight; i++){
            offset[1] += 1.5f;
            Instantiate(walls[0], offset, trap.transform.rotation);
            offset[0] -= 1.5f;
            if (i % 2 == 0) Instantiate(wallSorroundings[4], offset, trap.transform.rotation);
            else Instantiate(wallSorroundings[5], offset, trap.transform.rotation);
            offset[0] += 1.5f;
        }


        offset[1] += 1.5f;
        offset[0] -= 1.5f;
        Instantiate(wallSorroundings[10], offset, trap.transform.rotation);
        offset[0] += 1.5f;

        //spawn top walls
        for (i = 0; i < fieldWidth+2; i++){
            //spawn left corner wall
            if (i == 0) Instantiate(walls[3], offset, trap.transform.rotation);
            //spawn right corner wall
            else if (i == fieldWidth+1) Instantiate(walls[4], offset, trap.transform.rotation);
            //spawn top wall
            else Instantiate(walls[2], offset, trap.transform.rotation);
            offset[1] += 1.5f;
            if (i == 0) Instantiate(wallSorroundings[1], offset, trap.transform.rotation);
            else if(i == fieldWidth) Instantiate(wallSorroundings[0], offset, trap.transform.rotation);
            else if(i%2 == 0) Instantiate(wallSorroundings[0], offset, trap.transform.rotation);
            else Instantiate(wallSorroundings[1], offset, trap.transform.rotation);
            offset[1] -= 1.5f;
            offset[0] += 1.5f;
        }
  
        //spawn right walls

        Instantiate(wallSorroundings[6], offset, trap.transform.rotation);
        offset[0] -= 1.5f;
        for (i = 0; i < fieldHeight; i++){
            offset[1] -= 1.5f;
            Instantiate(walls[1], offset, trap.transform.rotation);
            offset[0] += 1.5f;
            if (i % 2 == 0) Instantiate(wallSorroundings[6], offset, trap.transform.rotation);
            else Instantiate(wallSorroundings[7], offset, trap.transform.rotation);
            offset[0] -= 1.5f;
        }
        offset[0] += 1.5f;
        Instantiate(wallSorroundings[7], offset, trap.transform.rotation);
        offset[0] -= 1.5f;
        offset[1] -= 1.5f;

        //spawn botton wall
        for (i = 0; i < fieldWidth + 2; i++)
        {
            //spawn right corner wall
            if (i == 0)
            {
                Instantiate(walls[7], offset, trap.transform.rotation);
                offset[1] -= 1.5f;
                Instantiate(wallSorroundings[2], offset, trap.transform.rotation);
                offset[1] += 1.5f;
            }
            //spawn left corner wall
            else if (i == fieldWidth+1)
            {
                Instantiate(walls[6], offset, trap.transform.rotation);
 
            }
            //spawn botton wall
            else
            {
                Instantiate(walls[5], offset, trap.transform.rotation);
                offset[1] -= 1.5f;
                Instantiate(wallSorroundings[2], offset, trap.transform.rotation);
                offset[1] += 1.5f;

            }

            offset[0] -= 1.5f;
        }

        
        //spawn the enviroment

        //offset to fill the visible area below the initial position
        offset[0] = -12;
        offset[1] = -9;

        for(k = 0; k < fieldHeight + 15; k++) { 
     
            for (i = 0; i < fieldWidth+15; i++)
            {
                //spawn a random enviroment prefab 
                toSpawn = random.Next(enviroment.Length);
                Instantiate(enviroment[toSpawn], offset, ground.transform.rotation);
                offset[0] += 1.5f;

            }
            offset[0] = -12;
            offset[1] += 1.5f;
        }
        // ----------------------- END DO NOT CHANGE -------------------------------------
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
