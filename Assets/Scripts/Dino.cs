using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dino : MonoBehaviour
{
    public Button dino;
    public Button dino2;
    public Button dino3;
    public Button next1;
    public Button next2;
    public Button next3;
    public Canvas canvas;
    public Canvas canvas2;
    public Canvas canvas3;


    void Start()
    {
        canvas.gameObject.SetActive(true);
        if (dino != null)
            dino.onClick.AddListener(StartGame);
        if (dino2 != null)
            dino2.onClick.AddListener(StartGame2);
        if (dino3 != null)
            dino3.onClick.AddListener(StartGame3);
        if (next1 != null)
            next1.onClick.AddListener(NextDino);
        if (next2 != null)
            next2.onClick.AddListener(NextDino2);
        if (next3 != null)
            next3.onClick.AddListener(NextDino3);
    }
    void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    void StartGame2()
    {
        SceneManager.LoadScene("Level1.2");
    }
    void StartGame3()
    {
        SceneManager.LoadScene("Level1.3");
    }
    void NextDino()
    {
        canvas.gameObject.SetActive(false);
        canvas2.gameObject.SetActive(true);
    }
    void NextDino2()
    {
        canvas2.gameObject.SetActive(false);
        canvas3.gameObject.SetActive(true);
    }
    void NextDino3()
    {
        canvas3.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
    }
}
