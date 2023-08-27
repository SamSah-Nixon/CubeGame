using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Levels : MonoBehaviour
{
    public AudioScript audioScript;
    public int currentLevel = 0;

    void Start()
    {

    }

    void Update()
    {
        
    }


    Color GenerateRandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0, 1f));
    }

    public void CubeFlashAnim()
    {
        Invoke(nameof(CubeFlash),0.0f);
        Invoke(nameof(CubeFlash),0.4f);
        Invoke(nameof(CubeFlash),0.8f);
        Invoke(nameof(ResetColors), 1.2f);
    }


    void CubeFlash()
    {
        foreach (Transform moduleType in transform )
        {
            foreach (Transform module in moduleType.transform)
            {
                module.GetComponent<Renderer>().material.color = GenerateRandomColor();
                
            }
        }
        audioScript.playFlashSFX();
    }

    void ResetColors()
    {
        foreach (Transform moduleType in transform)
        {
            foreach (Transform module in moduleType.transform)
            {
                module.GetComponent<Renderer>().material.color = module.GetComponent<ModuleScript>().GetDefaultColor();
            }
        }
        audioScript.playStartSFX();
    }

    public void LoadNextLevel()
    {
        UnLoadLevel();
        currentLevel++;
        CubeFlashAnim();
        Invoke("LoadLevel",1.2f);
    }

    public void UnLoadLevel()
    {
        switch (currentLevel)
        {
            case 1:
                GetComponent<Level1>().enabled = false;
                break;
            case 2:
                //GetComponent<Level2>().enabled = false;
                break;
        }
    }
    public void LoadLevel()
    {
        
        Debug.Log("Displaying level " + currentLevel);
        
        switch (currentLevel)
        {
            case 1:
                GetComponent<Level1>().enabled = true;
                break;
            case 2:
                //GetComponent<Level2>().enabled = true;
                break;
        }
    }
}
