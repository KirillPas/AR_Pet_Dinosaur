using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChangeLevel : MonoBehaviour
{
    public Button level1;
    public Canvas CanvasLevel;

    void Start()
    {
        if (level1 != null)
            level1.onClick.AddListener(ChangeScene);
    }
    void ChangeScene()
    {
        CanvasLevel.gameObject.SetActive(false);
        if (CanvasLevel!= null)
            SceneManager.LoadScene("Choice");
    }
}
