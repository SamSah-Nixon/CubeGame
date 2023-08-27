using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    private List<ModuleScript> modules = new List<ModuleScript>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Level 2: Armored Cubes!");
        foreach (Transform moduleType in transform)
        {
            foreach (Transform module in moduleType.transform)
            {
                //Ternary
                module.GetComponent<ModuleScript>().health = Random.Range(0, 100) > 75 ? 3 : 1;
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
}