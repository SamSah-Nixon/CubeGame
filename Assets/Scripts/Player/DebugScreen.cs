using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugScreen : MonoBehaviour
{
    [SerializeField] private Canvas debugScreen;
    [SerializeField] private TMP_InputField timeScaleInput;
    [SerializeField] private GameObject pauseTimeButton;
    [SerializeField] private GameObject goToButton;
    private Levels levels;

    public void Awake()
    {
        debugScreen.enabled = false;
        levels = GameObject.Find("CubeModules").GetComponent<Levels>();
        try
        {
            timeScaleInput.onEndEdit.AddListener((s) =>
            {
                try
                { 
                    Time.timeScale = float.Parse(timeScaleInput.text);
                }
                catch (Exception e)
                {
                    Debug.Log("Enter a number" + e);
                }
                
            });
            pauseTimeButton.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                if (Time.timeScale == 0f)
                    try
                    { 
                        timeScaleInput.onEndEdit.Invoke("");
                    }
                    catch (Exception e)
                    {
                        Debug.Log("Enter a number" + e);
                        Time.timeScale = 1f;
                    }
                    
                else
                    Time.timeScale = 0f;
            });
            goToButton.GetComponentInChildren<TMP_InputField>().onEndEdit.AddListener((s) =>
            {
                
                levels.setCurrentLevel(int.Parse(goToButton.GetComponentInChildren<TMP_InputField>().text) - 1);
            });
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
    }
}
