using UnityEngine;
using UnityEngine.UI;

public class Dino : MonoBehaviour
{
    public Button dino;
    public Canvas canvas;

    void Start()
    {
        canvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
        if (dino != null)
            dino.onClick.AddListener(StartGame);
    }
    void StartGame()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
