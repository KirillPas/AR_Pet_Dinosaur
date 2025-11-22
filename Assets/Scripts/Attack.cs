using UnityEngine;
using UnityEngine.EventSystems;

public class Attack : MonoBehaviour, IPointerDownHandler
{
    public int damageAmount = 20;
    private HP hp;
    
    void Start()
    {
        hp = GetComponent<HP>();
        if (hp == null)
        {
            Debug.LogError("HP компонент не найден!");
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (hp != null && hp.Currenthp > 0 && gameObject.CompareTag("Enemy"))
        {
            AttackEnemy();
        }
    }
    private void AttackEnemy()
    {
        hp.TakeDamage(damageAmount);
        Debug.Log("Урон нанесён: " + damageAmount);
    }
}
