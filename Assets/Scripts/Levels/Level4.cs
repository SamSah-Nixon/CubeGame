using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : MonoBehaviour
{
    // Start is called before the first frame update
    private List<ModuleScript> modules = new List<ModuleScript>();

    void Start()
    {
        Debug.Log("Level 4: Armor+");
        foreach (Transform moduleType in transform)
        {
            foreach (Transform module in moduleType.transform)
            {
                //Ternary
                if (Random.Range(0, 100) > 50)
                {
                    if (Random.Range(0, 100) > 50)
                    {
                        module.GetComponent<ModuleScript>().health = 7;
                    }
                    else
                    {
                        module.GetComponent<ModuleScript>().health = 3;
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
        GetComponent<Levels>().getWalls().transform.GetChild(Random.Range(0, 8)).gameObject.SetActive(true);
        GetComponent<Levels>().getWalls().transform.GetChild(Random.Range(0, 8)).gameObject.SetActive(true);
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

            for (int i = 0; i < GetComponent<Levels>().getWalls().transform.childCount; i++)
            {
                GetComponent<Levels>().getWalls().transform.GetChild(i).gameObject.SetActive(false);
            }
            GetComponent<Levels>().LoadNextLevel();
        }
    }
}