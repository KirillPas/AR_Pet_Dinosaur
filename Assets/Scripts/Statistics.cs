using System;
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
            if (KillManager.Instance.lastWinTime > 0)
                timer.text = (Math.Round(KillManager.Instance.lastWinTime)).ToString();
            if (KillManager.Instance.lastLoseTime > 0)
                timer.text = (Math.Round(KillManager.Instance.lastLoseTime)).ToString();
        }
    }
}
