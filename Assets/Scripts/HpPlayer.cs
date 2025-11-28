using UnityEngine;
using UnityEngine.SceneManagement;

public class HpPlayer : MonoBehaviour
{
    [SerializeField] PlayerAnimator animator;
    public int maxhp = 100;
    public int currentHp = 100;
    void Start()
    {
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
        DeathCanvas.previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Restart");
        currentHp = maxhp;
    }
}
