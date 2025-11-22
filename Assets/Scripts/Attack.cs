using UnityEngine;
using UnityEngine.EventSystems;

public class Attack : MonoBehaviour, IPointerDownHandler
{
    public int damageAmount = 20;
    public float attackRange = 0.5f;
    private HP hp;
    private Transform playerTransform;

    void Start()
    {
        hp = GetComponent<HP>();
        if (hp == null)
        {
            Debug.LogError("HP компонент не найден!");
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Игрок не найден!");
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (hp != null && hp.Currenthp > 0 && gameObject.CompareTag("Enemy") && playerTransform != null)
        {
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            if (distance <= attackRange)
            {
                AttackEnemy();
            }
        }
    }
    private void AttackEnemy()
    {
        hp.TakeDamage(damageAmount);
        Debug.Log("Урон нанесён: " + damageAmount);
    }
}
