using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnQuitPress()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void OnPlayPress()
    {
        Debug.Log("Loading Game");
        SceneManager.LoadScene(1);
    }

    public void OnOptionsPress()
    {
        Debug.Log("Loading Options");
    }

    public void OnLevelSelectPress()
    {
        Debug.Log("Loading Level Select");
    }
}
