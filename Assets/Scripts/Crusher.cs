using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{ 
    private float elapsedTime = 0f;
    private string behavior = "still";
    private float timeDown = 0.5f;
    public Vector3 startPos;
    public Vector3 endPos;


    // Update is called once per frame
    void Update()
    {
        if (behavior != "still" && behavior != "warning")
        {
            elapsedTime += Time.deltaTime;
            //Switch to going up
            if (behavior.Equals("crushDown") && floatEquals(transform.position.y, endPos.y))
            {
                elapsedTime = 0f;
                behavior = "crushUp";
            }
            //Going down
            else if (behavior.Equals("crushDown"))
                transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / this.timeDown);
            //Stop
            else if (behavior.Equals("crushUp") && floatEquals(transform.position.y, startPos.y))
                behavior = "still";
            //Going up
            else if (behavior.Equals("crushUp"))
                transform.position = Vector3.Lerp(endPos, startPos, elapsedTime / this.timeDown/4);
        }
    }

    public void Crush(float timeDown)
    {
        this.timeDown = timeDown;
        //Crush beginning
        behavior = "warning";
        elapsedTime = 0f;
        transform.parent.parent.transform.GetChild(0).position = new Vector3(transform.position.x, 1f, transform.position.z);
        transform.parent.parent.GetComponent<CrusherLevelRef>().cubeModules.GetComponent<Levels>().WarningSign();
        Invoke(nameof(CrushDownOn), this.timeDown*2f);
    }

    public void CrushDownOn()
    {
        behavior = "crushDown";
        elapsedTime = 0f;
    }

    public bool floatEquals(float float1, float float2)
    {
        if (float1 + 1 > float2 && float1 - 1 < float2)
        {
            return true;
        }
        return false;
    }

}
