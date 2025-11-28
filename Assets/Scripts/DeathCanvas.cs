using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathCanvas : MonoBehaviour
{
    public Canvas deathScreen;
    public Button restart;
    public Button menu;
    public static string previousSceneName;

    void Start()
    {
        deathScreen.gameObject.SetActive(true);
        menu.onClick.AddListener(OnMenuClicked);
        restart.onClick.AddListener(OnRestartClicked);
    }
    void OnMenuClicked()
    {
        SceneManager.LoadScene("Menu");
    }
    void OnRestartClicked()
    {
        SceneManager.LoadScene(previousSceneName);
    }
}
