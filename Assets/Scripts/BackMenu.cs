using UnityEngine;
using UnityEngine.UI;

public class BackMenu : MonoBehaviour
{
    public Button BackButton;
    public Canvas CanvasLevel;
    public Canvas CanvasMenu;

    void Start()
    {
        if (BackButton != null)
            BackButton.onClick.AddListener(Back);
    }
    void Back()
    {
        CanvasMenu.gameObject.SetActive(true);
        CanvasLevel.gameObject.SetActive(false);
    }
}
