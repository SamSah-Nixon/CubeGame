using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleScript : MonoBehaviour
{
    public Color defColor;

    private bool colliding = false;

    private Rigidbody rb;
    private Renderer color;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        color = GetComponent<Renderer>();
        defColor = color.material.color;
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
            Pulse();
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (!collision.gameObject.tag.Equals("Module"))
        {
            colliding = false;
        }
        
    }

    private void Pulse()
    {
        //Create a white pulse effect for 0.5 seconds
        //color.material.color = Color.white;
        //Invoke(nameof(ResetColor), 0.15f);
    }

    private void ResetColor()
    {
        color.material.color = defColor;
    }


}
