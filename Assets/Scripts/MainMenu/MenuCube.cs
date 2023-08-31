using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCube : MonoBehaviour
{
    private float x;
    private float y;
    private float z;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(255, 213, 0);
        transform.GetChild(1).GetComponent<Renderer>().material.color = new Color(185, 0, 0);
        transform.GetChild(2).GetComponent<Renderer>().material.color = new Color(255, 89, 0);
        transform.GetChild(3).GetComponent<Renderer>().material.color = new Color(0, 69, 173);
        transform.GetChild(4).GetComponent<Renderer>().material.color = new Color(0, 155, 72);
        transform.GetChild(5).GetComponent<Renderer>().material.color = new Color(255, 255, 255);

        foreach (Transform child in transform)
        {
            child.GetComponent<Renderer>().material.color /= 255;
        }
    }

    // Update is called once per frame
    void Update()
    {
        x += Random.Range(-5f, 5f);
        y += Random.Range(-5f, 5f);
        z += Random.Range(-5f, 5f);
        //Cube rotates randomly slowly and smoothly
        transform.Rotate(new Vector3(x,y,z), 100f * Time.deltaTime);
    }
}
