using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner instance;

    [SerializeField]
    private GameObject left_Platform, right_Platform;
    private float left_X_Min = -4.4f, left_X_Max = -2.8f, right_X_Min = 4.4f, right_X_Max = 2.8f; // random spawn range for left platform and random spawn range for right platform
    private float y_Treshold = 2.6f; //difference of height between 2 platforms
    private float last_Y;
    private int spawn_Count = 8; // how many platforms per spawn
    private int platform_Spawned; // which platform (left or right) spawned control variable

    [SerializeField]
    private Transform platform_Parent;

    // more variables to spawn bird enemy
    [SerializeField]
    private GameObject bird;

    public float bird_Y = 5f;
    private float bird_X_Min = -2.3f, bird_X_Max = 2.3f;

    // more variables to spawn coin
    [SerializeField]
    private GameObject coin;

    public float coin_Y = 3.5f;
    private float coin_X_Min = -2.3f, coin_X_Max = 2.3f;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        last_Y = transform.position.y; // equal last_y to our current y position of our gameobject (platform spawner)
        SpawnPlatforms();
    }

    public void SpawnPlatforms()
    {
        Vector2 temp = transform.position;
        GameObject newPlatform = null;

        for(int i = 0; i < spawn_Count; i++)
        {
            temp.y = last_Y;
            
            // we have even number
            if ((platform_Spawned % 2) == 0)
            {
                temp.x = Random.Range(left_X_Min, left_X_Max);
                newPlatform = Instantiate(right_Platform, temp, Quaternion.identity);
            }
            else
            {
                // if we have odd number
                temp.x = Random.Range(right_X_Min, right_X_Max);
                newPlatform = Instantiate(left_Platform, temp, Quaternion.identity);
            }

            newPlatform.transform.parent = platform_Parent;
            last_Y += y_Treshold;
            platform_Spawned++;
        }

        if (Random.Range(0, 2) > 0)
        {
            SpawnBird();
        }

        if(Random.Range(0, 3) > 0)
        {
            SpawnCoin();
        }


    } // spawn platforms

    void SpawnBird()
    {
        Vector2 temp = transform.position;
        temp.x = Random.Range(bird_X_Min, bird_X_Max);
        temp.y += bird_Y;

        GameObject newBird = Instantiate(bird, temp, Quaternion.identity);
        newBird.transform.parent = platform_Parent;
    }

    void SpawnCoin()
    {
        Vector2 temp = transform.position;
        temp.x = Random.Range(coin_X_Min, coin_X_Max);
        temp.y += coin_Y;

        GameObject newCoin = Instantiate(coin, temp, Quaternion.identity);
        newCoin.transform.parent = platform_Parent;
    }

} // class
