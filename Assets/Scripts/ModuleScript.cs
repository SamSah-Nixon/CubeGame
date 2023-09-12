using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class ModuleScript : MonoBehaviour
{



    private Rigidbody rb;
    private Renderer rend;
    private Material defaultMat;
    public Color defaultColor;
    [HideInInspector]
    public bool isColliding = false;
    public bool isLit = false;
    public int health = -1;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        rend.material.color = defaultColor;
        defaultMat = rend.material;
        health = -1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isColliding = true;
        health--;
        UpdateMaterial();
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

    public void UpdateMaterial()
    {
        if (health >= 5)
        {
            rend.material = transform.parent.parent.GetComponent<Levels>().getArmor2Material();
        }
        else if (health >= 2)
        {
            rend.material = transform.parent.parent.GetComponent<Levels>().getArmor1Material();
        }
        else if (health == 1)
        {
            LightDown();
        }
        else if (health == 0)
        {
            LightUp();
        }
    }

}
