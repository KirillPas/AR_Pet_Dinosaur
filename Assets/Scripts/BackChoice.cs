using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackChoice : MonoBehaviour
{
    [SerializeField] private Button back;
    void Start()
    {
        if (back != null)
            back.onClick.AddListener(Back);
    }
    void Back()
    {
        SceneManager.LoadScene("Choice");
    }
}
