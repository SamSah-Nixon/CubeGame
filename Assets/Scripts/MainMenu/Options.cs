using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] Button goBackButton;
    [SerializeField] Button resetButton;
    [SerializeField] Slider volume;
    [SerializeField] TextMeshProUGUI volumeText;
    [SerializeField] Canvas mainMenu;

    public void Start()
    {
        var volumeDef = PlayerPrefs.GetFloat("volume", 0.5f);
        AudioListener.volume = volumeDef;
        volumeText.text = (int)(volumeDef * 100) + "%";
        volume.value = 0.5f;
        goBackButton.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
        });
        volume.onValueChanged.AddListener((f) =>
        {
            AudioListener.volume = f;
            volumeText.text = (int)(f * 100) + "%";
            PlayerPrefs.SetFloat("volume", f);
        });
        resetButton.onClick.AddListener(() =>
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Delted Datas");
            GameObject.Find("LocalTransfer").GetComponent<LocalData>().SetLevel(1);
            //Reload Scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }
}
