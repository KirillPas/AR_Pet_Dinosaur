using UnityEngine;

public class MoreDamage : MonoBehaviour
{
    [SerializeField] private int up_damage = 10;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private Attack attack;
    private bool playerInRange = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            attack = other.GetComponent<Attack>();
            if (attack != null)
            {
                playerInRange = true;
                Debug.Log("[MoreDamage] Игрок вошёл в зону увеличения урона");
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (other.GetComponent<HpPlayer>() == attack)
            {
                playerInRange = false;
                attack = null;
                Debug.Log("[MoreDamage] Игрок вышел из зоны увеличения урона");
            }
        }
    }
    void Update()
    {
        if (!playerInRange || attack == null)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            UseMoreDamage();
        }
    }
    public void UseMoreDamage()
    {
        attack.UpDamage(up_damage);
        Debug.Log("[MoreDamage] Увеличения урона использовано");
        Destroy(gameObject);
    }
}
