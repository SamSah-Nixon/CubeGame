using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLvl1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CubeModules moduleCreator = transform.GetComponent<CubeModules>(); 
        moduleCreator.CreateFloorCubes(new Vector3(-10, -1, -10), 10, 10, transform.GetChild(0));

        Transform floorModule = transform.GetChild(0);
        for(int i = 0; i < floorModule.childCount; i++)
        {
            Transform child = floorModule.GetChild(i);
            Debug.Log(child.name);
            if (child.name.Equals("CubeModule(Clone)"))
            {
                child.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}
