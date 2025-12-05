using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button ButtonPause;
    [SerializeField] private Button ButtonPlay;
    [SerializeField] private Button Exit;
    [SerializeField] private Button Play;
    void Start()
    {
        Time.timeScale = 1f;
        if (Exit != null && Play != null && ButtonPlay != null)
        {
            Play.gameObject.SetActive(false);
            Exit.gameObject.SetActive(false);
            ButtonPlay.gameObject.SetActive(false);
        }

        if (ButtonPause != null)
        {
            ButtonPause.onClick.AddListener(InPause);
        }
        if (ButtonPlay != null)
        {
            ButtonPlay.onClick.AddListener(InPlay);
        }
        if (Play != null)
        {
            Play.onClick.AddListener(InPlay);
        }
    }
    void InPause()
    {
        Time.timeScale = 0f;
        Play.gameObject.SetActive(true);
        Exit.gameObject.SetActive(true);
        ButtonPlay.gameObject.SetActive(true);
        ButtonPause.gameObject.SetActive(false);
    }
    void InPlay()
    {
        Time.timeScale = 1f;
        Play.gameObject.SetActive(false);
        Exit.gameObject.SetActive(false);
        ButtonPlay.gameObject.SetActive(false);
        ButtonPause.gameObject.SetActive(true);
    }
}
