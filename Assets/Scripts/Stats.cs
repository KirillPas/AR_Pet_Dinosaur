using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [SerializeField] private Button look;
    [SerializeField] private Button close;
    [SerializeField] private TextMeshProUGUI stats;
    void Start()
    {
        Time.timeScale = 1f;
        if (stats != null && look != null && close != null)
        {
            stats.gameObject.SetActive(false);
            close.gameObject.SetActive(false);
            look.onClick.AddListener(Look);
        }
        if (close != null)
        {
            close.onClick.AddListener(Close);
        }
    }
    void Look()
    {
        Time.timeScale = 0f;
        stats.gameObject.SetActive(true);
        close.gameObject.SetActive(true);
        look.gameObject.SetActive(false);
    }
    void Close()
    {
        Time.timeScale = 1f;
        stats.gameObject.SetActive(false);
        close.gameObject.SetActive(false);
        look.gameObject.SetActive(true);
    }
}
