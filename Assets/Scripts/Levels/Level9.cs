using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level9 : MonoBehaviour
{
    // Start is called before the first frame update
    private List<ModuleScript> modules = new List<ModuleScript>();
    private float lastActive = 0f;
    private float cooldown = 2.5f;
    private float timeDown = 0.5f;
    void Start()
    {
        Debug.Log("Level 9: 2 Crushers! and WALLs");
        foreach (Transform moduleType in transform)
        {
            foreach (Transform module in moduleType.transform)
            {
                module.GetComponent<ModuleScript>().health = 2;
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

    void Update()
    {
        if (Time.time > lastActive + cooldown)
        {
            lastActive = Time.time;
            GetComponent<Levels>().getCrushers().transform.GetChild(Random.Range(0, 2)).GetChild(Random.Range(0, 9)).gameObject.GetComponent<Crusher>().Crush(timeDown);
        }
    }
}