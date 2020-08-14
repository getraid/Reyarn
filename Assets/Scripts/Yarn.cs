using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Yarn : MonoBehaviour
{

    // Start is called before the first frame update
    public List<GameObject> posList;
    public Material lineMat;
    private LineRenderer linerenderer;
    public float speed = 2;
    public float speedO = 0;
    private int currIndex = 0;


    void Start()
    {
        speedO = speed;
        //posList.Add(gameObject);
        posList.Insert(0, gameObject);
        posList.Reverse();
        linerenderer = gameObject.AddComponent<LineRenderer>();

    }
    // Update is called once per frame
    void Update()
    {
        var posVec3List = ReturnAllPositions();
        DrawLine(posVec3List);
        MoveToSpool();
    }

    private void MoveToSpool()
    {
        for (int i = 0; i < posList.Count - 1; i++)
        {
            GameObject firstElement = posList[i];
            GameObject prevElement = posList[i + 1];
            Vector3 test = prevElement.transform.position - firstElement.transform.position;
            test.Normalize();
            firstElement.transform.Translate(test * speed * Time.deltaTime);
        }

    }
    List<Vector3> ReturnAllPositions()
    {
        List<Vector3> pos = new List<Vector3>();
        for (int i = 0; i < posList.Count; i++)
        {
            pos.Add(posList[i].transform.position);
        }


        return pos;
    }

    private void DrawLine(List<Vector3> posList)
    {
        var x = LineSmoother.SmoothLine(posList.ToArray(), 0.5f);

        linerenderer.material = lineMat;
        linerenderer.textureMode = LineTextureMode.Tile;
        linerenderer.startWidth = 0.5f;
        linerenderer.endWidth = 0.5f;
        linerenderer.positionCount = x.Length - 1;
        linerenderer.SetPositions(x);
        linerenderer.useWorldSpace = true;
    }
  
    public void OnTriggerEnter2D(Collider2D x) 
    {
        if(x.gameObject.name == "plattform") 
        {
            x.gameObject.SetActive(false);
        }
    }

}
