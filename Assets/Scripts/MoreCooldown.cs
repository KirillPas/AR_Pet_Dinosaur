using UnityEngine;

public class MoreCooldown : MonoBehaviour
{
    [SerializeField] private float up_cooldown = 1f;
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
                Debug.Log("[MoreCooldown] Игрок вошёл в зону увеличения скорости атаки");
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
                Debug.Log("[MoreCooldown] Игрок вышел из зоны увеличения скорости атаки");
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
        attack.UpCooldown(up_cooldown);
        Debug.Log("[MoreCooldown] Увеличения скорости атаки использовано");
        Destroy(gameObject);
    }
}
