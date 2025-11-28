using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public class HpEnemy : MonoBehaviour
{
    [Header("Настройки здоровья")]
    public int maxHealth = 100;
    public int currentHealth = 100;

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
        if(currentHealth > 0)
            currentHealth -= damage;

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
        animator.SetTrigger("Death");
        Destroy(gameObject, 7f);

        Debug.Log("Противник уничтожен!");
    }
}
