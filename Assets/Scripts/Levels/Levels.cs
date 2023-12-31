using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class Levels : MonoBehaviour
{
    [SerializeField] private DeathScreen deathScreen;
    [SerializeField] private AudioScript audioScript;
    [SerializeField] private int currentLevel = 0;
    [SerializeField] private Material armor1Material;
    [SerializeField] private Material armor2Material;
    [SerializeField] private GameObject walls;
    [SerializeField] private GameObject crushers;
    [SerializeField] private GameObject warningSignPrefab;
    [SerializeField] private GameObject fire;
    [SerializeField] private TextMeshProUGUI levelPanel;
    [SerializeField] private Image winScreen;
    [SerializeField] private WinScreen winScreenScript;
    private bool timedRun = false;
    private float timeStart;
    private List<GameObject> warningSigns = new List<GameObject>();
    public void Start()
    {
        timedRun = false;
        Time.timeScale = 1;
        setStartAndEndSpotsCrusher();
        try
        {
            currentLevel = GameObject.Find("LocalTransfer").GetComponent<LocalData>().GetLevel() - 1;
        } catch (Exception e)
        {
            Debug.Log("No Set Level Found "+e);
        }
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
        if (PlayerPrefs.GetInt("highest") < currentLevel + 1)
            PlayerPrefs.SetInt("highest", currentLevel + 1);
        levelPanel.text = "Level " + (currentLevel + 1);
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
                GetComponent<Level2>().enabled = false;
                break;
            case 3:
                GetComponent<Level3>().enabled = false;
                break;
            case 4:
                GetComponent<Level4>().enabled = false;
                break;
            case 5:
                GetComponent<Level5>().enabled = false;
                break;
            case 6:
                GetComponent<Level6>().enabled = false;
                break;
            case 7:
                GetComponent<Level7>().enabled = false;
                break;
            case 8:
                GetComponent<Level8>().enabled = false;
                break;
            case 9:
                GetComponent<Level9>().enabled = false;
                break;
            case 10:
                GetComponent<Level10>().enabled = false;
                break;
            case 11:
                GetComponent<Level11>().enabled = false;
                break;
            case 12:
                GetComponent<Level12>().enabled = false;
                break;
            case 13:
                GetComponent<Level13>().enabled = false;
                break;
            case 14:
                GetComponent<Level14>().enabled = false;
                break;
            case 15:
                GetComponent<Level15>().enabled = false;
                break;
        }
    }
    public void LoadLevel()
    {
        
        Debug.Log("Displaying level " + currentLevel);

      switch (currentLevel)
        {
            case 1:
                timedRun = true;
                timeStart = Time.time;
                GetComponent<Level1>().enabled = true;
                break;
            case 2:
                GetComponent<Level2>().enabled = true;
                break;
            case 3:
                GetComponent<Level3>().enabled = true;
                break;
            case 4:
                GetComponent<Level4>().enabled = true;
                break;
            case 5:
                GetComponent<Level5>().enabled = true;
                break;
            case 6:
                GetComponent<Level6>().enabled = true;
                break;
            case 7:
                GetComponent<Level7>().enabled = true;
                break;
            case 8:
                GetComponent<Level8>().enabled = true;
                break;
            case 9:
                GetComponent<Level9>().enabled = true;
                break;
            case 10:
                GetComponent<Level10>().enabled = true;
                break;
            case 11:
                GetComponent<Level11>().enabled = true;
                break;
            case 12:
                GetComponent<Level12>().enabled = true;
                break;
            case 13:
                GetComponent<Level13>().enabled = true;
                break;
            case 14:
                GetComponent<Level14>().enabled = true;
                break;
            case 15:
                GetComponent<Level15>().enabled = true;
                break;
            case 16:
                Cursor.lockState = CursorLockMode.None;
                winScreen.gameObject.SetActive(true);
               
                if (timedRun)
                {
                    float bestTime;
                    try
                    {
                        
                        float.TryParse(PlayerPrefs.GetString("bestTime", "RunNoTimed999999999999999999").Substring(10), out bestTime);
                        if (bestTime > (Time.time - timeStart))
                        {
                            winScreenScript.SetBestTime("Best Time "+(Time.time - timeStart));
                            PlayerPrefs.SetString("bestTime", "Best Time: " + (Time.time - timeStart));
                        }
                        else
                        {
                            winScreenScript.SetBestTime(PlayerPrefs.GetString("bestTime", "No Best Time"));
                        }
                            
                    }
                    catch (Exception e)
                    {
                        Debug.Log("No Best Time Found "+e);
                    }
                    winScreenScript.SetTime("Time: "+(Time.time - timeStart));
                    
                }
                else
                {
                    winScreenScript.SetTime("Run Not Timed");
                    winScreenScript.SetBestTime(PlayerPrefs.GetString("bestTime", "No Best Time"));
                }
                break;
        }
    }

    public void Death(string message)
    {
        UnLoadLevel();
        deathScreen.Death(message);
    }

    public void EnableDangerSign()
    {
        audioScript.playWarningSFX();
        foreach (GameObject warningSign in warningSigns)
        {
            warningSign.SetActive(true);
        }
    }

    public void DisableDangerSign()
    {
        audioScript.stopAllSFX();
        foreach (GameObject warningSign in warningSigns)
        {
            warningSign.SetActive(false);
        }
    }

    public void WarningSign(float x, float z)
    {
        GameObject warningSign = Instantiate(warningSignPrefab, new Vector3(x, 1f, z), Quaternion.identity);
        warningSigns.Add(warningSign);
        Invoke(nameof(EnableDangerSign),0.0f);
        Invoke(nameof(DisableDangerSign),0.2f);
        Invoke(nameof(EnableDangerSign),0.4f);
        Invoke(nameof(DisableDangerSign),0.6f);
        Invoke(nameof(EnableDangerSign),0.8f);
        Invoke(nameof(DisableDangerSign),1.0f);
        Invoke(nameof(EnableDangerSign),1.2f);
        Invoke(nameof(DestroySign),1.4f);
    }

    private void DestroySign()
    {
        GameObject sign = warningSigns[0];
        warningSigns.RemoveAt(0);
        Destroy(sign);
    }

    public void setStartAndEndSpotsCrusher()
    {
        foreach (Transform topCrusher in crushers.transform.GetChild(0))
        {
            topCrusher.GetComponent<Crusher>().startPos = new Vector3(topCrusher.transform.position.x, 43.66666f, topCrusher.transform.position.z);
            topCrusher.GetComponent<Crusher>().endPos = new Vector3(topCrusher.transform.position.x, 6.66666f, topCrusher.transform.position.z);
        }

        foreach (Transform bottomCrusher in crushers.transform.GetChild(1))
        {
            bottomCrusher.GetComponent<Crusher>().startPos = new Vector3(bottomCrusher.transform.position.x, -23.33333f, bottomCrusher.transform.position.z);
            bottomCrusher.GetComponent<Crusher>().endPos = new Vector3(bottomCrusher.transform.position.x, 10f, bottomCrusher.transform.position.z);
        }
    }

    public Material getArmor1Material()
    {
        return armor1Material;
    }

    public Material getArmor2Material()
    {
        return armor2Material;
    }

    public GameObject getWalls()
    {
        return walls;
    }

    public GameObject getCrushers()
    {
        return crushers;
    }

    public DeathScreen getDeathScreen()
    {
        return deathScreen.GetComponent<DeathScreen>();
    }

    public int getCurrentLevel()
    {
        return currentLevel;
    }

    public GameObject getFire(){
        return fire;
    }

    public void setCurrentLevel(int level)
    {
        currentLevel = level;
    }

    public bool getTimedRun()
    {
        return timedRun;
    }
}
