using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public class HpEnemy : MonoBehaviour
{
    [Header("Настройки здоровья")]
    public int maxHealth = 100;
    public int currentHealth = 100;


    [Header("Эффекты")]
    public AudioClip deathSound;
    public AudioSource death;
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
            currentHealth = 0;
            KillManager.Instance.AddKill();
            Die();
        }
    }
    void Die()
    {
        if (deathSound != null)
        {
            death.PlayOneShot(deathSound);
        }
        animator.SetTrigger("Death");
        Destroy(gameObject, 7f);

        Debug.Log("Противник уничтожен!");
    }
}
