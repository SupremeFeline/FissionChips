using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawnScript : MonoBehaviour
{
    public GameObject water;
    public float spawnRate = 0;
    public float timer = 0;
    int lastSpawn = -1;
    bool lastWaterSpawn = false;

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
        int waterSpawn = Random.Range(0, 8);
        int duplicateRandomPrevention = Random.Range(0, 7);
        float position = -1;
        GameObject obstacle;


        if (lastSpawn == 1 || lastSpawn == 2)
        {
            randomHeight = (duplicateRandomPrevention > 1) ? 0 : Random.Range(1, 3);
        }


        switch (randomHeight)
        {
            case 0:
                position = -3;
                lastSpawn = 0;
                int randomSandcastleType = Random.Range(0, 3);
                obstacle = obstacles.ElementAt(randomSandcastleType);
                break;
            case 1:
                position = 0;
                lastSpawn = 1;
                obstacle = obstacles.ElementAt(3);
                break;
            default:
                position = 2.5f;
                lastSpawn = 2;
                obstacle = obstacles.ElementAt(4);
                break;
        }

        if (waterSpawn > 1 || lastWaterSpawn == true)
        {
            Instantiate(obstacle, new Vector3(transform.position.x, position, 0), transform.rotation);
            lastWaterSpawn = false;
        }
        else
        {
            Instantiate(water, new Vector3(transform.position.x, position, 0), transform.rotation);
            lastWaterSpawn = true;
        }

    }
}
