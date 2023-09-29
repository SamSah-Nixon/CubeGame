using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalData : MonoBehaviour
{
    static LocalData instance;
    private int currentLevel;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        instance = gameObject.GetComponent<LocalData>();
    }
    public void SetLevel(int level)
    {
        currentLevel = level;
    }

    public int GetLevel()
    {
        return currentLevel;
    }
}
