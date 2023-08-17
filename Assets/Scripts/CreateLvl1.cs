using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLvl1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CubeModules moduleCreator = transform.GetComponent<CubeModules>();
        var floorModule = transform.GetChild(0);
        var wallModule = transform.GetChild(1);
        var wallModule2 = transform.GetChild(2);
        var wallModule3 = transform.GetChild(3);
        var wallModule4 = transform.GetChild(4);
        var ceilingModule = transform.GetChild(5);
        moduleCreator.CreateFloorCubes(new Vector3(-10, -1, -10), 10, 10, floorModule);
        moduleCreator.CreateWallCubes(new Vector3(-10, 0, -10), 10, 10, true, wallModule);
        moduleCreator.CreateWallCubes(new Vector3(-10, 0, -10), 10, 10, false, wallModule2);
        moduleCreator.CreateWallCubes(new Vector3(-10, 0, 12), 10, 10, true, wallModule3);
        moduleCreator.CreateWallCubes(new Vector3(12, 0, -10), 10, 10, false, wallModule4);
        moduleCreator.CreateFloorCubes(new Vector3(-10, 21, -10), 10 , 10, ceilingModule);
        foreach (var modules in floorModule.GetComponentsInChildren<Renderer>())
            modules.material.color = Color.red;
        foreach (var modules in wallModule.GetComponentsInChildren<Renderer>())
            modules.material.color = Color.blue;
        foreach (var modules in wallModule2.GetComponentsInChildren<Renderer>())
            modules.material.color = Color.yellow;
        foreach (var modules in wallModule3.GetComponentsInChildren<Renderer>())
            modules.material.color = Color.green;
        foreach (var modules in wallModule4.GetComponentsInChildren<Renderer>())
            modules.material.color = Color.black;
        foreach (var modules in ceilingModule.GetComponentsInChildren<Renderer>())
            modules.material.color = Color.white;




    }


    Color GenerateRandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0, 1f));
    }
}
