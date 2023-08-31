using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level6 : MonoBehaviour
{
    // Start is called before the first frame update
    private List<ModuleScript> modules = new List<ModuleScript>();
    private float lastActive = 0f;
    private float cooldown = 5f;
    private float elapsedTime = 0f;
    private String behavior = "still";
    private Vector3 startPos;
    private Vector3 endPos;
    private GameObject crusher;
    void Start()
    {
        Debug.Log("Level 6: Top Crushers");
        foreach (Transform moduleType in transform)
        {
            foreach (Transform module in moduleType.transform)
            {
                //Ternary
                if (Random.Range(0, 100) > 50)
                {
                    if (Random.Range(0, 100) > 50)
                    {
                        module.GetComponent<ModuleScript>().health = 3;
                    }
                    else
                    {
                        module.GetComponent<ModuleScript>().health = 2;
                    }
                }
                else
                {
                    module.GetComponent<ModuleScript>().health = 1;
                }
                module.GetComponent<ModuleScript>().UpdateMaterial();
                modules.Add(module.GetComponent<ModuleScript>());
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (modules.TrueForAll(module => module.isLit))
        {
            foreach (var module in modules)
            {
                module.LightDown();
            }
            GetComponent<Levels>().LoadNextLevel();
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (Time.time > lastActive + cooldown)
        {
            behavior = "warning";
            lastActive = Time.time;
            crusher = GetComponent<Levels>().crushers.transform.GetChild(1).GetChild(Random.Range(0, 8)).gameObject;
            startPos = new Vector3(crusher.transform.position.x, 43.33333f, crusher.transform.position.z);
            endPos = new Vector3(crusher.transform.position.x, 6.66666f, crusher.transform.position.z);
            elapsedTime = 0f;
            GetComponent<Levels>().crushers.transform.GetChild(0).position = new Vector3(crusher.transform.position.x, 1f, crusher.transform.position.z);
            GetComponent<Levels>().WarningSign();
            Invoke(nameof(CrushDownOn),1.0f);
            Debug.Log("Crush Started: " + crusher);
        }

        if (behavior.Equals("crushDown") && crusher.transform.position.y <= 6.66666f)
        {
            elapsedTime = 0f;
            behavior = "crushUp";
        }
        else if(behavior.Equals("crushDown"))
            crusher.transform.position = Vector3.Lerp(startPos, endPos, elapsedTime/0.5f);
        else if (behavior.Equals("crushUp") && crusher.transform.position.y >= 43.33333f)
            behavior = "still";
        else if (behavior.Equals("crushUp"))
            crusher.transform.position = Vector3.Lerp(endPos, startPos, elapsedTime/2f);
    }

    public void CrushDownOn()
    {
        behavior = "crushDown";
        elapsedTime = 0f;
    }
}