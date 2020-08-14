using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Needle : MonoBehaviour
{
    public string nextLevelName;
    public GameObject gameover;
    public GameObject gameoverm;
    public GameObject win;
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        //This is kinda wrong, but gives a neat animation at the start, so I just keep it
        gameObject.transform.Rotate(new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y + 0.1f, gameObject.transform.rotation.z));
    }

    public void OnTriggerEnter2D(Collider2D x)
    {
        if (x.name == "player")
        {
            if (nextLevelName == "complete")
            {
                if (gameover != null && gameoverm != null && win != null)
                {
                    gameover.SetActive(false);
                    gameoverm.SetActive(true);
                    win.SetActive(true);
                }
            }
            else
            {

                SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
            }
        }
    }
}
