using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeModules : MonoBehaviour
{
    public GameObject cubePrefab;
    public Material glowMaterial;
    public float cubeSize = 1f;

    public ArrayList CreateFloorCubes(Vector3 startCorner, int length, int width, Transform parentGameObject)
    {
        ArrayList floorCubes = new ArrayList();
        for (int x = 0; x < length; x++)
        {
            for (int z = 0; z < width; z++)
            {
                GameObject cube = Instantiate(cubePrefab, parentGameObject);
                cube.transform.position = new Vector3(startCorner.x + x * cubeSize + cubeSize / 2, startCorner.y, startCorner.z + z * cubeSize + cubeSize / 2);
                floorCubes.Add(cube);
            }
        }
        return floorCubes;
    }

    public ArrayList CreateWallCubes(Vector3 startCorner, int length, int height,bool xDir,Transform parentGameObject)
    {
        int xOffset = 0;
        int zOffset = 0;

        if (xDir)
            xOffset = 1;
        else
            zOffset = 1;
        
        ArrayList wallCubes = new ArrayList();
        for (int x = 0; x < length; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject cube = Instantiate(cubePrefab, parentGameObject);
                cube.transform.position = new Vector3(startCorner.x + x * cubeSize * xOffset - zOffset * cubeSize / 2 + xOffset * cubeSize / 2,
                                                    startCorner.y + y * cubeSize + cubeSize / 2,
                                                    startCorner.z + zOffset * cubeSize * x - xOffset * cubeSize / 2 + zOffset * cubeSize / 2);
                cube.transform.rotation = Quaternion.Euler(0, 90, 0);
                wallCubes.Add(cube);
            }
        }
        return wallCubes;
    }

    public Material GetGlowMat()
    {
        return glowMaterial;
    }

}
