using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public TextMeshProUGUI deathMessage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death(string message)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        deathMessage.text = message;
        gameObject.SetActive(true);
    }

    public void OnMainMenuPress()
    {
        SceneManager.LoadScene(0);
    }
}
