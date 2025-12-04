using TMPro;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    public TextMeshProUGUI countenemy;
    public TextMeshProUGUI timer;
    void Update()
    {
        if (KillManager.Instance != null)
        {
            countenemy.text = KillManager.Instance.kills.ToString();
            timer.text = KillManager.Instance.lastLevelTime.ToString();
        }
    }
}
