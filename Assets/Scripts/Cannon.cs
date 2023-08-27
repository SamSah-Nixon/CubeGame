using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannonBall;
    public float fireRate = 0.25f;
    private float lastfiretime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && lastfiretime + fireRate < Time.time)
        {
            Fire();
        }
    }

    void Fire()
    {
        lastfiretime = Time.time;
        //Creates a new ball
        GameObject ball = Instantiate(cannonBall, transform.position, transform.rotation);
        //Adds force to the ball
        ball.GetComponent<Renderer>().material.color = RandomColor();
        ball.GetComponent<Rigidbody>().AddForce(transform.up * 2000);
        //Destroys the ball after 5 seconds
        Destroy(ball, 5);

    }

    Color RandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0, 1f));
    }
}
