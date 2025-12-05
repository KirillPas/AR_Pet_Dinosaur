using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dino : MonoBehaviour
{
    public Button dino, dino2, dino3;
    public Button next1, next2, next3;
    public Button look1, look2, look3;
    public Canvas canvas, canvas2, canvas3;
    public static int number;

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
        if (look1 != null)
            look1.onClick.AddListener(Look1);
        if (look2 != null)
            look2.onClick.AddListener(Look2);
        if (look3 != null)
            look3.onClick.AddListener(Look3);
    }
    void StartGame()
    {
        if (number == 1)
            SceneManager.LoadScene("Level1");
        if (number == 2)
            SceneManager.LoadScene("Level2.1");
        if (number == 3)
            SceneManager.LoadScene("Level3.1");
    }
    void StartGame2()
    {
        if (number == 1)
            SceneManager.LoadScene("Level1.2");
        if (number == 2)
            SceneManager.LoadScene("Level2.2");
        if (number == 3)
            SceneManager.LoadScene("Level3.2");
    }
    void StartGame3()
    {
        if (number == 1)
            SceneManager.LoadScene("Level1.3");
        if (number == 2)
            SceneManager.LoadScene("Level2.3");
        if (number == 3)
            SceneManager.LoadScene("Level3.3");
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
    void Look1()
    {
        SceneManager.LoadScene("Viewing1.1");
    }
    void Look2()
    {
        SceneManager.LoadScene("Viewing1.2");
    }
    void Look3()
    {
        SceneManager.LoadScene("Viewing1.3");
    }
}
