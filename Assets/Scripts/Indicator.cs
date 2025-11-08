using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public Slider healthSlider;
    public TextMeshProUGUI Hp;
    public HP x;
    void Update()
    {
        if (Hp != null)
            Hp.text = ((float)x.Currenthp).ToString();
        if (x != null)
            healthSlider.value = ((float)x.Currenthp / x.Maxhp);
    }
}
