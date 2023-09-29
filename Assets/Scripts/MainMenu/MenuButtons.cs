using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private LocalData localData;
    [SerializeField] private TextMeshProUGUI highestLevelText;

    public void Start()
    {
        int highestLvl = PlayerPrefs.GetInt("highest");
        highestLevelText.text = "(Level " + highestLvl+")";
    }
    public void OnQuitPress()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void OnPlayPress()
    {
        Debug.Log("Loading Game");
        localData.SetLevel(PlayerPrefs.GetInt("highest"));
        SceneManager.LoadScene(1);
    }

    public void OnOptionsPress()
    {
        Debug.Log("Loading Options");
        this.gameObject.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void OnLevelSelectPress()
    {
        this.gameObject.SetActive(false);
        levelSelectMenu.SetActive(true);
        Debug.Log("Loading Level Select");
    }
}
