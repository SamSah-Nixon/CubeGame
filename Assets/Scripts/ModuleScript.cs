using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleScript : MonoBehaviour
{

    private bool colliding = false;

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
        if (!collision.gameObject.tag.Equals("Module"))
        {
            colliding = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (!collision.gameObject.tag.Equals("Module"))
        {
            colliding = false;
        }

    }

    public Color GetDefaultColor()
    {
        return defaultColor;
    }


}
