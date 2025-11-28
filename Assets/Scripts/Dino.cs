using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dino : MonoBehaviour
{
    public Button dino;
    public Canvas canvas;

    void Start()
    {
        canvas.gameObject.SetActive(true);
        if (dino != null)
            dino.onClick.AddListener(StartGame);
    }
    void StartGame()
    {
        canvas.gameObject.SetActive(false);
        SceneManager.LoadScene("Level1");
    }
}
