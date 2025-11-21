using UnityEngine;
using UnityEngine.UI;
public class Levels : MonoBehaviour
{
    public Canvas CanvasLevel;
    public Canvas CanvasMenu;
    public Button levels;

    void Start()
    {
        CanvasMenu.gameObject.SetActive(true);
        CanvasLevel.gameObject.SetActive(false);
        if (CanvasLevel != null)
            levels.onClick.AddListener(ChangeCanvas);
    }

    void ChangeCanvas()
    {
        CanvasLevel.gameObject.SetActive(true);
        CanvasMenu.gameObject.SetActive(false);
    }
}
