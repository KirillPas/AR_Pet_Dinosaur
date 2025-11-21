using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChangeLevel : MonoBehaviour
{
    public Button level1;

    void Start()
    {
        if (level1 != null)
            level1.onClick.AddListener(ChangeScene);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
