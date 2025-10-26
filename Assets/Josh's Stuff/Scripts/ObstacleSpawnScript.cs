using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawnScript : MonoBehaviour
{
    public GameObject water;
    public float spawnRate = 0;
    public float timer = 0;
    public bool lastSpawnOnTop;

    public List<GameObject> obstacles = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnObstacle();

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnObstacle();
            timer = 0;
        }

    }

    void SpawnObstacle()
    {
        int randomHeight = Random.Range(0, 3);
        int randomObject = Random.Range(0, 6);
        int duplicatRandomPrevention = Random.Range(0, 5);
        float position = -1;
        GameObject obstacle;

        if (lastSpawnOnTop)
        {
            bool spawnOnTopAgain = (duplicatRandomPrevention > 0) ? true : false;
            if (!spawnOnTopAgain)
            {
                randomHeight = Random.Range(0, 2);
            }
        }


        switch (randomHeight)
        {
            case 0:
                position = -3;
                lastSpawnOnTop = false;
                int randomSandcastleType = Random.Range(0, 3);
                obstacle = obstacles.ElementAt(randomSandcastleType);
                break;
            case 1:
                position = 0;
                lastSpawnOnTop = false;
                obstacle = obstacles.ElementAt(1);
                break;
            default:
                position = 2.5f;
                lastSpawnOnTop = true;
                obstacle = obstacles.ElementAt(2);
                break;
        }

        if (randomObject > 1)
        {
            Instantiate(obstacle, new Vector3(transform.position.x, position, 0), transform.rotation);
        }
        else
        {
            Instantiate(water, new Vector3(transform.position.x, position, 0), transform.rotation);
        }

    }
}
