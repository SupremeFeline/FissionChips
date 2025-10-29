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
    public float jumpHeight = 2;
    public float jumpDelay = 0.1f;
    private bool isGrounded = true;
    public Healthbar healthbar;
    public Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;

    //obstacle flash props
    public Color flashColor = new Color(1f, 0f, 0f, 0.5f);
    public float flashDuration = 0.1f;
    public int flashCount = 3;

    //water flash props
    public Color waterHealthColor = new Color(0f, 0f, 1f, 0.5f);
    public float waterFadeDuration = 0.5f;
    public float waterHealthHoldTime = 0.1f;

    private Color originalColor;

    private Vector3 move;
    private bool isdead = false;
    void Start()
    {
        time = maxTime;
        healthbar.SetMaxTime(time);
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

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
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y * jumpDelay);
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
            StartCoroutine(FlashBlue());
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            time -= obstacleLoss;
            if (time < 0)
            {
                time = 0;
            }

            StartCoroutine(FlashRed());

        }
    }

    private IEnumerator FlashRed()
    {
        for (int i = 0; i < flashCount; i++)
        {
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
        }

    }

    private IEnumerator FlashBlue()
    {
        spriteRenderer.color = waterHealthColor;
        yield return new WaitForSeconds(waterHealthHoldTime);

        float elapsed = 0f;
        while(elapsed < waterFadeDuration)
        {
            spriteRenderer.color = Color.Lerp(waterHealthColor, originalColor, elapsed / waterFadeDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = originalColor;
    }
}
