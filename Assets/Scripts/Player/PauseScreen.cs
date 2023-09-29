using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private TextMeshProUGUI timedRunText;
    [SerializeField] private TextMeshProUGUI currentLvlText;
    [SerializeField] private Levels levels;
    private CursorLockMode prevlockMode;
    public KeyCode pauseKey = KeyCode.Escape;

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (pauseScreen.activeSelf)
            {
                prevlockMode = Cursor.lockState;
                Cursor.lockState = CursorLockMode.None;
            }
            else
                Cursor.lockState = prevlockMode;

            pauseScreen.SetActive(!pauseScreen.activeSelf);
            
            Time.timeScale = (pauseScreen.activeSelf) ? 0f : 1f;
            timedRunText.text = levels.getTimedRun() ? "Timed Run: Yes" : "Timed Run: No";
            currentLvlText.text = "Current Level: " + (levels.getCurrentLevel());
        }
    }
}
