using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public int damageAmount = 15;               // Урон врага
    public float attackDelay = 0.3f;            // Задержка перед нанесением урона
    public float attackCooldown = 1f;           // Кулдаун между атаками

    public Animator enemyAnimator;

    private HP playerHP;
    private bool canAttack = true;               // Можно ли атаковать
    private bool isWaitingToAttack = false;     // Флаг ожидания задержки перед уроном
    private float attackTimer = 0f;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerHP = player.GetComponent<HP>();
        else
            Debug.LogError("Игрок не найден!");
    }
    void Update()
    {
        if (isWaitingToAttack)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0f)
            {
                PerformDamage();
                isWaitingToAttack = false;
                attackTimer = attackCooldown;
            }
        }
        else if (!canAttack) // В период кулдауна
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0f)
            {
                canAttack = true;
            }
        }
    }
    public void OnDamageTaken()
    {
        if (canAttack)
        {
            canAttack = false;
            isWaitingToAttack = true;
            attackTimer = attackDelay;
            if (enemyAnimator != null)
            {
                enemyAnimator.SetBool("Attack", true);
            }
        }
    }
    private void PerformDamage()
    {
        if (playerHP != null && playerHP.Currenthp > 0)
        {
            playerHP.TakeDamage(damageAmount);
            Debug.Log("Враг нанёс урон игроку: " + damageAmount);
        }

        if (enemyAnimator != null)
        {
            enemyAnimator.SetBool("Attack", false);
        }
    }
}
