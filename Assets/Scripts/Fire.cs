using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject gameoverobj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D x)
    {
      if(x.name == "player") 
        {
            Destroy(x.gameObject);
            gameoverobj.SetActive(true);
        }
    }
}
