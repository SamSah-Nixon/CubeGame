using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level8 : MonoBehaviour
{
    // Start is called before the first frame update
    private List<ModuleScript> modules = new List<ModuleScript>();
    private float lastActive = 0f;
    private float cooldown = 2.5f;
    private float timeDown = 0.5f;
    void Start()
    {
        Debug.Log("Level 8: 2 Crushers!!!");
        foreach (Transform moduleType in transform)
        {
            foreach (Transform module in moduleType.transform)
            {
                //Ternary
                if (Random.Range(0, 100) > 50)
                {
                    if (Random.Range(0, 100) > 50)
                    {
                        module.GetComponent<ModuleScript>().health = 4;
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
        if (Time.time > lastActive + cooldown)
        {
            lastActive = Time.time;
            GetComponent<Levels>().getCrushers().transform.GetChild(Random.Range(0,2)).GetChild(Random.Range(0,9)).gameObject.GetComponent<Crusher>().Crush(timeDown);
            GetComponent<Levels>().getCrushers().transform.GetChild(Random.Range(0,2)).GetChild(Random.Range(0,9)).gameObject.GetComponent<Crusher>().Crush(timeDown);
        }
    }
}