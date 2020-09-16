using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text timeText;
    public bool win = false;
    public float fastestTime;
    public float currentTime = 0f;
    public float moveSpeed = 5f;
    public float jumpSpeed = 7f;
    Rigidbody2D myRigidbody;
    BoxCollider2D box;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        fastestTime = PlayerPrefs.GetFloat("fastestTime", 10000);
    }

    void Update()
    {

        Run();
        Jump();
        if(!win)
        {
            currentTime += Time.deltaTime * 1;
        }
        timeText.text = (int)currentTime + " seconds";
    }

    public void Run()
    {
        float horThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(horThrow * moveSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }

    
    public void Jump()
    {
        if(box.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if(Input.GetButtonDown("Jump"))
            {
                Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
                myRigidbody.velocity += jumpVelocityToAdd;
            }
        }
    }

    public void Win()
    {
        win = true;
        StartCoroutine(WinGame());
    }

    IEnumerator WinGame()
    {
        yield return new WaitForSeconds(3);
        if(fastestTime > currentTime)
        {
            PlayerPrefs.SetFloat("fastestTime", currentTime);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene("MainMenu");
    }
}
