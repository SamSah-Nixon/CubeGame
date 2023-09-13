using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level10 : MonoBehaviour
{
    // Start is called before the first frame update
    private List<ModuleScript> modules = new List<ModuleScript>();
    private float lastActive = 0f;
    private float cooldown = 2.5f;
    private float timeDown = 0.2f;
    private int index = 0;
    void Start()
    {
        Debug.Log("Level 10: Timed Crushers");
        foreach (Transform moduleType in transform)
        {
            foreach (Transform module in moduleType.transform)
            {
                module.GetComponent<ModuleScript>().health = 5;
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
            GetComponent<Levels>().getCrushers().transform.GetChild(Random.Range(0, 2)).GetChild(index*3).gameObject.GetComponent<Crusher>().Crush(timeDown);
            GetComponent<Levels>().getCrushers().transform.GetChild(Random.Range(0, 2)).GetChild(index*3 + 1).gameObject.GetComponent<Crusher>().Crush(timeDown);
            GetComponent<Levels>().getCrushers().transform.GetChild(Random.Range(0, 2)).GetChild(index*3 + 2).gameObject.GetComponent<Crusher>().Crush(timeDown);
            index++;
            if (index == 3)
                index = 0;
        }
    }
}