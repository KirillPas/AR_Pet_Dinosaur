using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    [Header("Ответная атака врага")]
    public int damageToPlayer = 15;
    public float counterDelay = 0.15f;

    public HpPlayer playerHP;
    public HpEnemy enemyHp;
    public Animator enemyAnimator;

    public static bool isbool = false;

    void Start()
    {
        if (playerHP == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                playerHP = player.GetComponent<HpPlayer>();
        }

        if (enemyHp == null)
            enemyHp = GetComponent<HpEnemy>();
    }
    public void OnPlayerHitEnemy()
    {
        if (enemyHp == null || enemyHp.currentHealth <= 0)
            return;

        if (isbool)
            return;
        if (enemyAnimator != null)
            enemyAnimator.SetTrigger("Attack");

        StartCoroutine(CounterAttackRoutine());
    }
    private IEnumerator CounterAttackRoutine()
    {
        isbool = true;

        yield return new WaitForSeconds(counterDelay);

        if (enemyHp == null || enemyHp.currentHealth <= 0)
        {
            isbool = false;
            yield break;
        }

        if (playerHP != null && playerHP.currentHp > 0)
        {
            playerHP.TakeDamage(damageToPlayer);
            Debug.Log($"[Enemy] Ответный удар: {damageToPlayer}, HP игрока: {playerHP.currentHp}");
        }
        isbool = false;
    }
}