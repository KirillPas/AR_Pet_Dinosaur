 using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    [Header("Настройки ответа врага")]
    public int damageToPlayer = 15;
    public float attackDelay = 0.3f;
    public float attackCooldown = 1f;

    public Animator enemyAnimator;
    public HpPlayer playerHP;

    private bool canCounterAttack = true;

    void Start()
    {
        if (playerHP == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                playerHP = player.GetComponent<HpPlayer>();
        }
    }
    public void OnPlayerHitEnemy()
    {
        if (!canCounterAttack)
            return;

        StartCoroutine(CounterAttackRoutine());
    }
    private IEnumerator CounterAttackRoutine()
    {
        canCounterAttack = false;

        // Подготовка/анимация
        if (enemyAnimator != null)
            enemyAnimator.SetTrigger("Attack");

        // Ждём, пока “дойдёт” анимация до момента удара
        yield return new WaitForSeconds(attackDelay);

        // Наносим урон игроку
        if (playerHP != null && playerHP.Currenthp > 0)
        {
            playerHP.TakeDamage(damageToPlayer);
            Debug.Log($"[Enemy] Ответный удар по игроку: {damageToPlayer}");
        }
        // КД перед следующим ответом
        yield return new WaitForSeconds(attackCooldown);
        canCounterAttack = true;
    }
}
