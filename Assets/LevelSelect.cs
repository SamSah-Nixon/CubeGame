using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TextMeshProUGUI highestLevelText;
    [SerializeField] LocalData localData;
    [SerializeField] Button goBackButton;
    [SerializeField] Canvas mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        int highestLvl = PlayerPrefs.GetInt("highest");
        highestLevelText.text = "Highest Completed Level: " + highestLvl;
        inputField.onEndEdit.AddListener((s) =>
        {
            int level = int.Parse(s);
            if (level > highestLvl || level < 1 || level > 25)
            {
                //TODO: Tell PLayer NO
                Debug.Log("NO");
                return;
            }
            localData.SetLevel(level);
            SceneManager.LoadScene(1);
            
        });
        goBackButton.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
        });
    }
}
