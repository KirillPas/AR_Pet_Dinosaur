using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public TextMeshProUGUI texthp;
    public Slider slider;
    public HpPlayer hp;
    void Update()
    {
        if (texthp != null)
        {
            texthp.text = ((float)hp.currentHp).ToString();
        }
        if (hp != null && slider != null)
        {
            slider.value = (float)hp.currentHp / hp.maxhp;
        }
    }
}
