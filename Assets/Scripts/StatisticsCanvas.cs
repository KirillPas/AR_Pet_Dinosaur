using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatisticsCanvas : MonoBehaviour
{
    [SerializeField] private Button back;
    public static string backWinOrRestart;

    void Start()
    {
        back.onClick.AddListener(BackScene);
    }
    void BackScene()
    {
        SceneManager.LoadScene(backWinOrRestart);
    }
}
