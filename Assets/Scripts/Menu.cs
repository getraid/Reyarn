﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }
    public void Exit()
    {

        Application.Quit();
    }
    public void Reload()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Play()
    {

        SceneManager.LoadScene("main");
    }
}
