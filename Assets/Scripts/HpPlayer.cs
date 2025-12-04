using UnityEngine;
using UnityEngine.SceneManagement;

public class HpPlayer : MonoBehaviour
{
    [SerializeField] PlayerAnimator animator;
    public int maxhp = 100;
    public int currentHp = 100;
    public LevelTimer levelTimer;
    void Start()
    {
        currentHp = maxhp;
    }
    public void Heal(int value)
    {
        animator.EatHeal();
        currentHp += value;
        if (currentHp > maxhp)
            currentHp = maxhp;
        Debug.Log("[HpPlayer] Heal: +" + value + ", HP = " + currentHp);
    }
    public void UpMaxHp(int value)
    {
        animator.EatHeal();
        maxhp += value;
        currentHp = maxhp;
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("[HpPlayer] TakeDamage. До урона: " + currentHp + ", урон: " + damage);
        if(currentHp > 0)
            currentHp -= damage;
        if (currentHp < 0) currentHp = 0;

        if (currentHp == 0)
        {
            Debug.Log("[HpPlayer] HP == 0, Death()");
            Death();
        }
        else
        {
            Debug.Log("[HpPlayer] После урона: " + currentHp);
        }
    }
    public void Death()
    {
        levelTimer.StopTimer();
        float time = levelTimer.LevelTime;
        KillManager.Instance.SaveLevelTime(time);
        DeathCanvas.previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Restart");
        currentHp = maxhp;
    }
}