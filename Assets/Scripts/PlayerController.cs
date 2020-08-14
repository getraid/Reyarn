using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4;
    public float smoothing = 0.98f;
    public float fallingV = 2f;
    public float fallingVC = 0;
    public float jumpSpeed = 10f;
    public float jumpSpeedDec = 0.1f;
    private float jumpSpeedC = 0;
    private bool jtoggle = false;
    private bool dtoggle = false;

    private bool jumpable = false;
    private float v = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        jumpSpeedC = jumpSpeed;
        fallingVC = fallingV;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xPos = Input.GetAxis("Horizontal");

        jtoggle = Input.GetButton("Jump") ? true : jtoggle;

        if (jtoggle && jumpable)
        {
           
            gameObject.transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime);
            jumpSpeed -= jumpSpeedDec;
            if (jumpSpeed <= 0)
            {
                jtoggle = false;
                jumpable = false;
                jumpSpeed = jumpSpeedC;
            }
        }
        if (dtoggle)
        {
            v = 0;
    
        }

        float delta = v * Time.deltaTime + (fallingV) * Time.deltaTime * Time.deltaTime * 0.5f;
        v = v + (fallingV) * Time.deltaTime;

        gameObject.transform.Translate(Vector3.down * delta * smoothing);
        gameObject.transform.Translate(Vector3.right * xPos * speed * Time.deltaTime * smoothing);
    }
    public void OnCollisionEnter2D(Collision2D col)
    {

        dtoggle = true;
        fallingV = fallingVC;
        jumpable = true;
    }
    public void OnCollisionExit2D(Collision2D col)
    {
        dtoggle = false;
        fallingV = fallingVC;
      
    }
}
