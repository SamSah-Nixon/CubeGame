using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ModuleScript : MonoBehaviour
{



    private Rigidbody rb;
    private Color defaultColor;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defaultColor = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Equals("Ball"))
        {
            Debug.Log("AUKHDIUAWHDOAUH");
            HitByBall();
        }
    }

    private void OnCollisionExit(Collision collision)
    {

    }

    void HitByBall()
    {
        GetComponent<Renderer>().material = transform.parent.parent.GetComponent<CubeModules>().getGlowMat();
        GetComponent<Renderer>().material.color = defaultColor;
        Invoke("Reset Glow", 1f);
    }

    void ResetGlow()
    {

    }

    public Color GetDefaultColor()
    {
        return defaultColor;
    }


}
