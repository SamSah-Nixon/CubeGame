using UnityEngine;

public class Crusher : MonoBehaviour
{ 
    private string behavior = "still";
    private float timeDown = 0.5f;
    private bool sign;
    public Vector3 startPos;
    public Vector3 endPos;
    private Rigidbody rb;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (behavior != "still" && behavior != "warning")
        {
            //Switch to going up
            if (behavior.Equals("crushDown") && (transform.position.y > endPos.y) != sign)
            {
                behavior = "crushUp";
                sign = transform.position.y < startPos.y;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            //Going down
            else if (behavior.Equals("crushDown"))
                rb.AddForce((endPos-transform.position)*30f);
            //Stop
            else if (behavior.Equals("crushUp") && (transform.position.y < startPos.y) != sign)
            {
                behavior = "still";
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }
            //Going up
            else if (behavior.Equals("crushUp"))
                rb.AddForce((startPos-transform.position)*30f);
        }
    }

    public void Crush(float timeDown)
    {
        this.timeDown = timeDown;
        //Crush beginning
        behavior = "warning";
        transform.parent.parent.GetComponent<CrusherLevelRef>().cubeModules.GetComponent<Levels>().WarningSign(transform.position.x,transform.position.z);
        sign = transform.position.y > endPos.y;
        
        Invoke(nameof(CrushDownOn), this.timeDown*2f);
    }

    public void CrushDownOn()
    {
        behavior = "crushDown";
        rb.isKinematic = false;
    }

}
