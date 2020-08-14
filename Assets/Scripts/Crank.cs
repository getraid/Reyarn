using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crank : MonoBehaviour
{
    private bool allowSpin;
    private bool doSpin = false;
    private Vector2 prevDirection;
    private Yarn yarn;
    public float speedRamp = 0.1f;
    private GameObject mouseBanner;
    private Animator anim;
    public float spoolspeed =1f;

    // Start is called before the first frame update
    void Start()
    {
        yarn = gameObject.GetComponent<Yarn>();
        //threw me error at UnityEditor.Graphs.Edge.WakeUp()...therefore instanciating new empty obj
        mouseBanner = new GameObject();
        mouseBanner = GameObject.Find("mouse1");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // convert mouse position into world coordinates
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (allowSpin)
        {
            doSpin = Input.GetMouseButton(0);


        }
        if (doSpin)
        {
            // get direction you want to point at
            Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
      

            if (direction.y != prevDirection.y)
            {
                if (!(yarn.speed >= yarn.speedO))
                    yarn.speed += speedRamp;

            }
            transform.up = direction;
            if (!Input.GetMouseButton(0))
            {
                doSpin = false;
            }
            prevDirection = direction;

            anim.speed = spoolspeed;


            mouseBanner.SetActive(false);
        }
        else
        {
            if (!(yarn.speed <= 0))
                yarn.speed -= speedRamp;

            anim.speed = 0f;
        }

    }
    public void OnMouseOver()
    {
        allowSpin = true;
    }
    public void OnMouseExit()
    {
        allowSpin = false;

    }
}
