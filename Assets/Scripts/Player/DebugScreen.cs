using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugScreen : MonoBehaviour
{
    [SerializeField] private Canvas debugScreen;
    [SerializeField] private TMP_InputField timeScaleInput;

    public void Awake()
    {
        debugScreen.enabled = false;
        try
        {
            timeScaleInput.onEndEdit.AddListener((s) => { Time.timeScale = float.Parse(timeScaleInput.text); });
        }
        catch (Exception e)
        {
            Debug.Log("Enter a number" + e);
        }
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Cursor.lockState = CursorLockMode.None;
            if (debugScreen.enabled)
                Cursor.lockState = CursorLockMode.Locked;
            debugScreen.enabled = !debugScreen.enabled;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 0f)
                timeScaleInput.onEndEdit.Invoke("");
            else
                Time.timeScale = 0f;
                
        }
            
    }

    
}
