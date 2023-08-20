using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLvl1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Material white;
    public Material green;
    public Material red;
    public Material blue;
    public Material orange;
    public Material yellow;
    void Start()
    {
        CubeModules moduleCreator = transform.GetComponent<CubeModules>();
        var floorModule = transform.GetChild(0);
        var wallModule = transform.GetChild(1);
        var wallModule2 = transform.GetChild(2);
        var wallModule3 = transform.GetChild(3);
        var wallModule4 = transform.GetChild(4);
        var ceilingModule = transform.GetChild(5);
        moduleCreator.CreateFloorCubes(new Vector3(-10, -3.333334f, -10), 3, 3, floorModule);
        moduleCreator.CreateWallCubes(new Vector3(-10, 0, -10), 3, 3, true, wallModule);
        moduleCreator.CreateWallCubes(new Vector3(-10, 0, -10), 3, 3, false, wallModule2);
        moduleCreator.CreateWallCubes(new Vector3(-10, 0, 16.666667f), 3, 3, true, wallModule3);
        moduleCreator.CreateWallCubes(new Vector3(16.666667f, 0, -10), 3, 3, false, wallModule4);
        moduleCreator.CreateFloorCubes(new Vector3(-10, 23.333334f, -10), 3, 3, ceilingModule);
        foreach (var modules in floorModule.GetComponentsInChildren<Renderer>())
            modules.material = white;
        foreach (var modules in wallModule.GetComponentsInChildren<Renderer>())
            modules.material = green;
        foreach (var modules in wallModule2.GetComponentsInChildren<Renderer>())
            modules.material = red;
        foreach (var modules in wallModule3.GetComponentsInChildren<Renderer>())
            modules.material = blue;
        foreach (var modules in wallModule4.GetComponentsInChildren<Renderer>())
            modules.material = orange;
        foreach (var modules in ceilingModule.GetComponentsInChildren<Renderer>())
            modules.material = yellow;




    }


    Color GenerateRandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0, 1f));
    }
}
