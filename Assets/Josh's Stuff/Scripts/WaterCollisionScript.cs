using UnityEngine;

public class WaterCollisionScript : MonoBehaviour
{
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
