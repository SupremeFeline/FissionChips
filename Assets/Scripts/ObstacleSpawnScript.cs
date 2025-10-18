using UnityEngine;

public class ObstacleSpawnScript : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnRate = 0;
    public float timer = 0;
    public bool lastSpawnOnTop;

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
        int randomHeight = Random.Range(0, 2);
        int duplicatRandomPrevention = Random.Range(0, 5);
        float position = -1;

        if (lastSpawnOnTop)
        {
            randomHeight = (duplicatRandomPrevention > 0) ? 0 : 1;
        }

        switch (randomHeight)
        {
            case 0:
                position = -3;
                lastSpawnOnTop = false;
                break;
            default:
                position = 3;
                lastSpawnOnTop = true;
                break;
        }

        Instantiate(obstacle, new Vector3(transform.position.x, position, 0), transform.rotation);

    }
}
