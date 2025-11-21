using UnityEngine;
using UnityEngine.UI;
public class Exit : MonoBehaviour
{
    public Button exitButton;
    void Start()
    {
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);
        }
        else
        {
            Debug.LogWarning("Exit Button is not assigned in the inspector.");
        }
    }

    public void ExitGame()
    {
        Debug.Log("Выход из игры по нажатию кнопки.");
        Application.Quit();

#if UNITY_EDITOR
        // Для редактора Unity останавливаем режим Play
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
