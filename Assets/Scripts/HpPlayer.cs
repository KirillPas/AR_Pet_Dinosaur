using UnityEngine;

public class HpPlayer : MonoBehaviour
{
    [SerializeField] private int maxhp = 100;
    private int currentHp;
    public int Maxhp
    {
        get { return maxhp; }
        set { maxhp = value; }
    }
    public int Currenthp
    {
        get { return currentHp; }
        set { currentHp = value; }
    }

}
