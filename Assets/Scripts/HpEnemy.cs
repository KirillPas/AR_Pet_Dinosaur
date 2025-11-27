using UnityEngine;
using System.Collections;
public class HpEnemy : MonoBehaviour
{
    [Header("Настройки здоровья")]
    public int maxHealth = 30;
    public int currentHealth;

    [Header("Эффекты")]
    public GameObject deathEffect;
    public AudioClip deathSound;
    [SerializeField] Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Проверяем смерть противника
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        // Эффект смерти
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        // Звук смерти
        if (deathSound != null)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
        }
        animator.SetBool("Death", true);
        // Уничтожаем объект
        Destroy(gameObject);

        Debug.Log("Противник уничтожен!");
    }
}
