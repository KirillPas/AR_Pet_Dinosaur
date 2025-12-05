using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.PackageManager;
public class ChangeLevel : MonoBehaviour
{
    public Button level1;
    public Button level2;
    public Button level3;
    public Canvas CanvasLevel;

    void Start()
    {
        if (level1 != null)
        {
            level1.onClick.AddListener(OnLevel1);
        }
        if (level2 != null)
        {
            level2.onClick.AddListener(OnLevel2);
        }
        if (level3 != null)
        {
            level3.onClick.AddListener(OnLevel3);
        }
    }
    void OnLevel1()
    {
        Dino.number = 1;
        ChangeScene();
    }
    void OnLevel2()
    {
        Dino.number = 2;
        ChangeScene();
    }
    void OnLevel3()
    {
        Dino.number = 3;
        ChangeScene();
    }
    void ChangeScene()
    {
        CanvasLevel.gameObject.SetActive(false);
        if (CanvasLevel!= null)
            SceneManager.LoadScene("Choice");
    }
}
