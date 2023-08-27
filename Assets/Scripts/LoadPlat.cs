using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoadPlat : MonoBehaviour
{
    private Renderer rend;
    private Rigidbody rb;
    private bool collision = false;

    [SerializeField] private UnityEvent onDestroy;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rend.material.color.a > 0 && collision)
        {
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, rend.material.color.a - 0.003f);   
        }
        else if (rend.material.color.a <= 0)
        {
            Destroy(gameObject);
            onDestroy.Invoke();
        }
    }

    void OnCollisionEnter()
    {
        collision = true;
    }
}
