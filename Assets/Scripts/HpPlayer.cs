using UnityEngine;
using UnityEngine.SceneManagement;

public class HpPlayer : MonoBehaviour
{
    [SerializeField] PlayerAnimator animator;
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
    private void Start()
    {
        currentHp = maxhp;
    }
    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Death();
        }
    }
    public void Death() 
    {
        animator.DeathAnimation();
        SceneManager.LoadScene("Menu");
    }
}
