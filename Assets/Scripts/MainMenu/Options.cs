using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] Button goBackButton;
    [SerializeField] Slider volume;
    [SerializeField] TextMeshProUGUI volumeText;
    [SerializeField] Canvas mainMenu;

    public void Start()
    {
        goBackButton.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
        });
        volume.onValueChanged.AddListener((f) =>
        {
            AudioListener.volume = f;
            volumeText.text = (int)(f * 100) + "%";
        });
    }
}
