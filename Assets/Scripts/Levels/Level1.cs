using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    private List<ModuleScript> modules = new List<ModuleScript>();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Level 1: Hit all the cubes!");
        foreach (Transform moduleType in transform)
        {
            foreach (Transform module in moduleType.transform)
            {
                modules.Add(module.GetComponent<ModuleScript>());
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var module in modules)
        {
            if (module.isColliding && !module.isLit)
            {
                module.LightUp();
            }
        }
        if (modules.TrueForAll(module => module.isLit))
        {
            foreach (var module in modules)
            {
                module.LightDown();
            }
            Debug.Log("Level 1: All cubes hit!");
            GetComponent<Levels>().LoadNextLevel();
        }
    }
}
