using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class worldGenerator : MonoBehaviour
{
    public GameObject trap;
    public GameObject ground;
    public GameObject winGround;
    public AudioSource[] Songs = new AudioSource[6];
    public GameObject[] walls = new GameObject[8];
    public GameObject[] wallSorroundings = new GameObject[12];
    public GameObject[] enviroment = new GameObject[6];
    private AudioSource music;
    public int difficulty = 1;
    private int fieldWidth = 10;
    private int fieldHeight = 5;
    private double LevelTime;

    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        LevelTime = Time.realtimeSinceStartup;
        music = Songs[random.Next(6)].GetComponent<AudioSource>();
        //music.volume = 0.1f;
        music.Play();
        buildWorld();
    }

    void buildWorld()
    {
        int toSpawn;
        int i, k;
        System.Random random = new System.Random();


        //setting fiedsize based on the difficulty

        fieldWidth = (int)(5 + difficulty*(difficulty+1));
        fieldHeight = (int)(2.5 + (difficulty*difficulty));

        //spawn the bomb field
        offset = ground.transform.position;
        offset[0] = 0;
        offset[1] += 1.5f;

        for (k = 0; k < fieldHeight; k++)
        {
            for (i = 0; i < fieldWidth; i++)
            {
                /*if ((i == fieldWidth - 1) && (k == fieldHeight - 1))
                {
                    Instantiate(winGround, offset, ground.transform.rotation);
                    continue;
                }*/

                toSpawn = random.Next(100);

                //difficulty equals 1 or 3-> 50% chance of spawning a trap
                //difficulty equals 2 -> 66% chance of spawning a trap
                if (toSpawn <= 35 && (i != 0 && k != 0))
                {
                    Instantiate(ground, offset, ground.transform.rotation);
                    Instantiate(trap, offset, trap.transform.rotation);
                }
                else
                {
                    Instantiate(ground, offset, ground.transform.rotation);
                }
                offset[0] += 1.5f;
            }
            offset[1] += 1.5f;
            offset[0] = 0;
        }
        offset *= 0;

        // ----------------------- BEGIN DO NOT CHANGE -------------------------------------
        //spawn enviroment and walls

        //spawn left walls
        offset[0] -= 3f;
        Instantiate(wallSorroundings[8], offset, trap.transform.rotation);
        offset[0] += 1.5f;
        for (i = 0; i < fieldHeight; i++)
        {
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
        for (i = 0; i < fieldWidth + 2; i++)
        {
            //spawn left corner wall
            if (i == 0) Instantiate(walls[3], offset, trap.transform.rotation);
            //spawn right corner wall
            else if (i == fieldWidth + 1) Instantiate(walls[4], offset, trap.transform.rotation);
            //spawn top wall
            else Instantiate(walls[2], offset, trap.transform.rotation);
            offset[1] += 1.5f;
            if (i == 0) Instantiate(wallSorroundings[1], offset, trap.transform.rotation);
            else if (i == fieldWidth) Instantiate(wallSorroundings[0], offset, trap.transform.rotation);
            else if (i % 2 == 0) Instantiate(wallSorroundings[0], offset, trap.transform.rotation);
            else Instantiate(wallSorroundings[1], offset, trap.transform.rotation);
            offset[1] -= 1.5f;
            offset[0] += 1.5f;
        }

        //spawn right walls

        Instantiate(wallSorroundings[6], offset, trap.transform.rotation);
        offset[0] -= 1.5f;
        for (i = 0; i < fieldHeight; i++)
        {
            offset[1] -= 1.5f;
            if (i == 0)
            {
                Instantiate(winGround, offset, ground.transform.rotation);
                continue;
            }
            else Instantiate(walls[1], offset, trap.transform.rotation);
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
            else if (i == fieldWidth + 1)
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
        offset[0] = -16;
        offset[1] = -12;

        for (k = 0; k < fieldHeight + 20; k++)
        {

            for (i = 0; i < fieldWidth + 20; i++)
            {
                //spawn a random enviroment prefab 
                toSpawn = random.Next(enviroment.Length);
                Instantiate(enviroment[toSpawn], offset, ground.transform.rotation);
                offset[0] += 1.5f;

            }
            offset[0] = -16;
            offset[1] += 1.5f;
        }
        // ----------------------- END DO NOT CHANGE -------------------------------------
    }

    public void ResetLevel()
    {
        var Wally = GameObject.FindGameObjectsWithTag("Trap");

        foreach (GameObject item in Wally) 
        {
            item.SendMessage("ReActivate");
        }
    }

    public void NextLevel()
    {
        this.difficulty += 1;
        this.LevelTime = Time.realtimeSinceStartup;
        var trappy = GameObject.FindGameObjectsWithTag("Trap");
        foreach(GameObject item in trappy)
        {
            Destroy(item);
        }
        var floory = GameObject.FindGameObjectsWithTag("Floor");
        foreach(GameObject item in floory)
        {
            Destroy(item);
        }
        System.Random random = new System.Random();
        music.Stop();
        music = Songs[random.Next(6)].GetComponent<AudioSource>();
        music.Play();
        buildWorld();
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().respawnPlayer(true);
        //player.SendMessage("respawnPlayer", true);
    }

    public double GetTimeFromLevelStart()
    {
        return this.LevelTime;
    }
}
