using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles1, obstacles2, obstacles3, obstacles4;
    public GameObject obstacle, obstacle2, token, knifeBox;
    public float spawnDistance = 4f;
    public int tokenFrequency = 3, obstacleFrequency = 3;

    private Vector3 nextSpawnPos;
    private int skin;
    private bool canSpawnBox = true;

    [HideInInspector]
    public bool scoreReached = false;

    void Awake()
    {
        nextSpawnPos = transform.position;
    }

    public void SkinCheck()
    {
        skin = PlayerPrefs.GetInt("Skin", 0);
        FirstSpawn();
    }

    public void FirstSpawn()
    {
        nextSpawnPos.z = -3.3f;

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Destroyable"))
            Destroy(obj);

        for (int i = 0; i < 11; i++)
            Spawn();
    }

    public void Spawn()
    {
        if (!FindObjectOfType<GameManager>().gameIsOver && !scoreReached)        //If the game is not over yet
        {
            nextSpawnPos.z += spawnDistance;
            transform.position = nextSpawnPos;

            if (Random.Range(0, obstacleFrequency) == 0)        //If it is time to spawn an obstacle
            {
                if (Random.Range(0, 2) == 0)
                    Instantiate(obstacle, transform.position, Quaternion.identity);
                else
                    Instantiate(obstacle2, transform.position, Quaternion.identity);
            }
            else if (Random.Range(0, tokenFrequency) == 0)      //If it is time to spawn a token
                Instantiate(token, transform.position, Quaternion.identity);
            else         //Spawns destroyable objects
            {
                switch (skin)       //Decides which obstacle needs to be spawned based on skin's value
                {
                    case 0:
                        Instantiate(obstacles1[Random.Range(0, obstacles1.Length)], transform.position, Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(obstacles2[Random.Range(0, obstacles1.Length)], transform.position, Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(obstacles3[Random.Range(0, obstacles1.Length)], transform.position, Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(obstacles4[Random.Range(0, obstacles1.Length)], transform.position, Quaternion.identity);
                        break;
                }
            }
        }
        else if (!FindObjectOfType<GameManager>().gameIsOver && scoreReached && canSpawnBox)        //If the player reached the goal score for this level
        {
            canSpawnBox = false;
            nextSpawnPos.z += spawnDistance;
            transform.position = nextSpawnPos;
            Instantiate(knifeBox, transform.position, Quaternion.identity);     //Spawns KnifeBox
        }
    }
}
