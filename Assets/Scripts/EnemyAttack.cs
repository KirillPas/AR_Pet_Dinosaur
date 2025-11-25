using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public Animator enemyAnimator;
    private HP playerHP;
    private Transform playerTransform;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHP = player.GetComponent<HP>();
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Игрок не найден!");
        }
    }

    // Короутина для ответной атаки, принимает урон, который должен нанести враг
    public IEnumerator EnemyAttackRoutine(int damage)
    {
        if (enemyAnimator != null)
            enemyAnimator.SetBool("Attack", true);

        // Задержка на анимацию и подготовку удара
        yield return new WaitForSeconds(0.3f);

        if (playerHP != null && playerHP.Currenthp > 0)
        {
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            if (distance <= 1.5f)  // можно настроить радиус атаки врага
            {
                playerHP.TakeDamage(damage);
                Debug.Log("Враг нанес урон игроку: " + damage);
            }
        }

        // Дополнительная задержка для кулдауна врага (если нужно)
        yield return new WaitForSeconds(1f);
        if (enemyAnimator != null)
            enemyAnimator.SetBool("Attack", false);
    }
}
