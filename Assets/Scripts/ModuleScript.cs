using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ModuleScript : MonoBehaviour
{



    private Rigidbody rb;
    private Renderer rend;
    private Material defaultMat;
    public Color defaultColor;
    public bool isColliding = false;
    public bool isLit = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        rend.material.color = defaultColor;
        defaultMat = rend.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        isColliding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }


    public void LightUp()
    {
        rend.material = transform.parent.parent.GetComponent<CubeModules>().GetGlowMat();
        rend.material.SetColor("_EmissionColor", defaultColor * 5);
        rend.material.color = defaultColor;
        isLit = true;
    }

    public void LightDown()
    {
        rend.material = defaultMat;
        isLit = false;
    }

    public Color GetDefaultColor()
    {
        return defaultColor;
    }


}
