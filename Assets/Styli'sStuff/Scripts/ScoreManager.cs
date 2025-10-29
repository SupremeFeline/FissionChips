using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Text scoreText;
    public float multiplyer = 1f;
    public static float score = 0f;
   
    
    void Start()
    {
        scoreText.text = "Score:";
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime*multiplyer;
        scoreText.text = "Score: " + (int)score;

    }

  
}
