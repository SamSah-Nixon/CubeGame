using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeModules : MonoBehaviour
{
    public GameObject cubePrefab;
    public float cubeSize = 1f;


    public ArrayList CreateFloorCubes(Vector3 startCorner, int xSize, int zSize, Transform parentGameObject)
    {
        ArrayList floorCubes = new ArrayList();
        for (int x = 0; x < xSize; x++)
        {
            for (int z = 0; z < zSize; z++)
            {
                GameObject cube = Instantiate(cubePrefab, parentGameObject);
                cube.transform.position = new Vector3(startCorner.x + x * cubeSize + cubeSize / 2, startCorner.y, startCorner.z + z * cubeSize + cubeSize / 2);
                floorCubes.Add(cube);
            }
        }
        return floorCubes;
    }
}
