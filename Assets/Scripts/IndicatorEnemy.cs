using TMPro;
using UnityEngine;

public class IndicatorEnemy : MonoBehaviour
{
    public TextMeshProUGUI Hp;
    public HpEnemy hpEnemy;
    void Update()
    {
        if (Hp != null)
            Hp.text = ((float)hpEnemy.currentHealth).ToString();
    }
}
