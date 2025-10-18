using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Movement2D : MonoBehaviour
{
    // Start is called before the first frame update

    public int speed = 3;
    public float maxTime = 20;
    public float waterGain = 2;
    public float obstacleLoss = 5;
    private float time;
    public float jumpHeight = 1;
    public float jumpDelay = 0.1f;
    private bool isGrounded = true;
    public Healthbar healthbar;
    public Rigidbody2D rb;


    private Vector3 move;
    private bool isdead = false;
    void Start()
    {
        time = maxTime;
        healthbar.SetMaxTime(time);
    }

    // Update is called once per frame
    void Update()
    {


        if (Keyboard.current.wKey.isPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(0, jumpHeight);
        }
        if (Keyboard.current.wKey.wasReleasedThisFrame && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y*jumpDelay);
        }


        if (isdead)
        {
            SceneManager.LoadScene("GameOver");
        }

        time -= Time.deltaTime;
        healthbar.setTime(time);
        if (time <= 0)
        {
            Debug.Log("game over!");
            isdead = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            time += waterGain;
            if (time > maxTime)
            {
                time = maxTime;
            }
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            time -= obstacleLoss;
            if (time < 0)
            {
                time = 0;
            }
        }
    }

}
