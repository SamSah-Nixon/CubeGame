using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI bestTimeText;
    public void SetTime(string time)
    {
        timeText.text = time;
    }

    public void SetBestTime(string time)
    {
        bestTimeText.text = time;
    }
}
