using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class Movement2D : MonoBehaviour
{
    // Start is called before the first frame update

    public int speed = 3;
    public float maxTime = 20;
    public float waterGain = 2;
    public float obstacleLoss = 5;
    private float time;
    public Healthbar healthbar;



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


        if (Keyboard.current.wKey.isPressed)
        {
            transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }

        if (isdead)
        {
            Application.Quit();
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
        Debug.Log("game over!");
        isdead = true;
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
