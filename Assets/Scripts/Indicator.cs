using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public Slider healthSlider;
    public TextMeshProUGUI Hp;
    public HpEnemy x;
    void Update()
    {
        if (Hp != null)
            Hp.text = ((float)x.currentHealth).ToString();
        if (x != null)
            healthSlider.value = ((float)x.currentHealth / x.maxHealth);
    }
}
