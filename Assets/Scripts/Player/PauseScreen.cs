using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    public KeyCode pauseKey = KeyCode.Escape;

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
                pauseScreen.SetActive(!pauseScreen.activeSelf);
                Cursor.lockState = (pauseScreen.activeSelf) ? CursorLockMode.None : CursorLockMode.Locked;
                Time.timeScale = (pauseScreen.activeSelf) ? 0f : 1f;
        }
    }
}
