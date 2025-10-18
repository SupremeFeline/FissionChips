using UnityEngine;

public class ObstacleMoveScript : MonoBehaviour
{
    public float moveSpeed = .5f;
    public float despawnZone = -20;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();

    }

    void MoveObject()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if (transform.position.x < despawnZone)
        {
            Destroy(gameObject);
        }
    }
}
