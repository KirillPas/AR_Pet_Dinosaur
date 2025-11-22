using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public int damageAmount = 15;
    public Animator enemyAnimator;
    public float attackDelay = 0.3f;
    public float attackCooldown = 1f;

    private HP playerHP;
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerHP = player.GetComponent<HP>();
    }
    public IEnumerator EnemyAttackRoutine()
    {
        if (playerHP == null || playerHP.Currenthp <= 0)
            yield break;

        if (enemyAnimator != null)
            enemyAnimator.SetTrigger("Attack");

        yield return new WaitForSeconds(attackDelay);

        playerHP.TakeDamage(damageAmount);
        Debug.Log("Враг нанес урон игроку: " + damageAmount);

        yield return new WaitForSeconds(attackCooldown);
    }
}
