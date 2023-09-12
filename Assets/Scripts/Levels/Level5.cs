using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : MonoBehaviour
{
    // Start is called before the first frame update
    private List<ModuleScript> modules = new List<ModuleScript>();
    private GameObject bottomModules;
    private bool movingUp = true;
    private float elapsedtime = 0;
    private Vector3 startPosition = new Vector3(0, 0, 0);
    private Vector3 targetPosition = new Vector3(0, 18.6666f, 0);
    void Start()
    {
        Debug.Log("Level 5: Timed Crusher");
        foreach (Transform moduleType in transform)
        {
            foreach (Transform module in moduleType.transform)
            {
                if(module.name.Equals("TopRowModule") || module.name.Equals("MiddleRowModule"))
                    module.GetComponent<ModuleScript>().health = 5;
                else
                    module.GetComponent<ModuleScript>().health = 2;
                module.GetComponent<ModuleScript>().UpdateMaterial();
                modules.Add(module.GetComponent<ModuleScript>());
            }
        }
        bottomModules = transform.GetChild(0).gameObject;
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
            movingUp = false;
            elapsedtime = 0;
            Invoke(nameof(EndLevel),1f);
        }
    }

    void Update()
    {
        elapsedtime += Time.deltaTime;
        if(movingUp)
            bottomModules.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedtime/45f);
        else
            bottomModules.transform.position = Vector3.Lerp(targetPosition, startPosition, elapsedtime/1f);
        if (bottomModules.transform.position == targetPosition)
        {
            GetComponent<Levels>().getDeathScreen().Death("CRUSHED!");
            Debug.Log("You died");
        }
    }

    void EndLevel()
    {
        GetComponent<Levels>().LoadNextLevel();
    }
}